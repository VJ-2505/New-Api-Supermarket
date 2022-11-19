using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public PurchaseController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        // GET: PurchaseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PurchaseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PurchaseController/Create
        public ActionResult Create()
        {
            return View();
        }
       [HttpPost("Purchase")]
        public IActionResult Purchase([FromBody] dynamic payload)
        {
            try
            {
               
                Order order = new Order();
                order = payload.ToObject<Order>();
                db.Orders.Add(order);
                db.SaveChanges();
                List<Batch> batches = new List<Batch>();
                List<StockBatch> stockBatches = new List<StockBatch>();
                int batchno = 0;
                if(db.Batches.Where(x => x.CompanyId == order.CompanyId).Any())
                {
                    batchno = db.Batches.Where(x => x.CompanyId == order.CompanyId).Max(x => x.BatchNo);
                }
                foreach (var item in payload.Items)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem = item.ToObject<OrderItem>();
                    orderItem.OrderId = order.Id;
                    orderItem.CompanyId = order.CompanyId;
                    db.OrderItems.Add(orderItem);
                    db.SaveChanges();
                    int? barcodeid = orderItem.BarcodeId;
                    //Batch batch = new Batch();
                    //batch.BarcodeId = (int)(int?)orderItem.BarcodeId;
                    //batch.BatchNo = batchno;
                    //batch.CompanyId = order.CompanyId;
                    //batch.EntryDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    //batch.Price = (double)(double?)orderItem.Price;
                    //batch.ProductId = orderItem.ProductId;
                    //batch.StoreId = (int)order.StoreId;
                    //batch.Quantity = (int)orderItem.OrderQuantity;
                    //db.Batches.Add(batch);
                    //db.SaveChanges();
                    //batches.Add(batch);
                    //StockBatch stockBatch = new StockBatch();
                    //stockBatch.BatchId = batch.BatchId;
                    //stockBatch.CompanyId = batch.CompanyId;
                    //stockBatch.CreatedBy = order.OrderedById;
                    //stockBatch.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    //stockBatch.Quantity = batch.Quantity;
                    //stockBatch.StockId = db.Stocks.Where(x => x.StoreId == order.StoreId && x.BarcodeId == batch.BarcodeId).FirstOrDefault().StockId;
                    //stockBatch.Updated = true;
                    //stockBatch.ProductName = getBarcodeProductName(batch.BarcodeId, batch.ProductId);
                    //db.StockBatches.Add(stockBatch);
                    //db.SaveChanges();
                    //stockBatches.Add(stockBatch);
                    //OrderItemDetail orderItemDetail = new OrderItemDetail();
                    //orderItemDetail.ActualProdId = orderItem.ProductId;
                    //orderItemDetail.Amount = (double)orderItem.TotalAmount;
                    //orderItemDetail.BatchId = batch.BatchId;
                    //orderItemDetail.CompanyId = order.CompanyId;
                    //orderItemDetail.CreatedBy = order.OrderedById;
                    //orderItemDetail.CreatedDate = order.CreatedDate;
                    //orderItemDetail.DiscAmount = (double)orderItem.DiscAmount;
                    //orderItemDetail.DiscPercent = (double)orderItem.DiscPercent;
                    //orderItemDetail.DiscPerQty = (double)(orderItem.DiscAmount / orderItem.OrderQuantity);
                    //orderItemDetail.OrderItemId = orderItem.Id;
                    //orderItemDetail.OrderItemType = 1;
                    //orderItemDetail.Quantity = (double)orderItem.OrderQuantity;
                    //orderItemDetail.StorageStoreId = order.StoreId;
                    //orderItemDetail.Tax1 = (double)orderItem.Tax1;
                    //orderItemDetail.Tax2 = (double)orderItem.Tax2;
                    //orderItemDetail.TaxAmount = (double)orderItem.TaxAmount;
                    //orderItemDetail.UnitPrice = (double)(orderItem.TotalAmount / orderItem.OrderQuantity);
                    //db.OrderItemDetails.Add(orderItemDetail);
                    //db.SaveChanges();
                }
                int lastorderno = db.Orders.Where(x => x.StoreId == order.StoreId).Max(x => x.OrderNo);
                var response = new
                {
                    status = 200,
                    message = "Purchase Item Added Successfully",
                    lastorderno = lastorderno
                    //batches = batches,
                    //stockBatches = stockBatches
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status  = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }
        [HttpPost("updatePurchase")]
        public IActionResult updatePurchase([FromBody] dynamic payload)
        {
            try
            {
                Order order = new Order();
                order = payload.ToObject<Order>();
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                List<OrderItem> olditems = db.OrderItems.Where(x => x.OrderId == order.Id).AsNoTracking().ToList();
                List<OrderItem> newItems = payload.Items.ToObject<List<OrderItem>>();
                foreach(OrderItem orderItem in olditems)
                {
                    if(newItems.Where(x => x.BarcodeId == orderItem.BarcodeId && x.Price == orderItem.Price).Any())
                    {
                        OrderItem oi = newItems.Where(x => x.BarcodeId == orderItem.BarcodeId).FirstOrDefault();
                        oi.OrderId = order.Id;
                        oi.Id = orderItem.Id;
                        db.Entry(oi).State = EntityState.Modified;
                        db.SaveChanges();
                        OrderItemDetail orderItemDetail = db.OrderItemDetails.Where(x => x.OrderItemId == oi.Id).FirstOrDefault();
                        orderItemDetail.Quantity = (double)oi.OrderQuantity;
                        orderItemDetail.Amount = oi.TotalAmount;
                        orderItemDetail.UnitPrice = oi.Price;
                        db.Entry(oi).State = EntityState.Modified;
                        db.SaveChanges();
                        //Batch batch = db.Batches.Find(orderItemDetail.BatchId);
                        //batch.Price = (double)oi.Price;
                        //batch.Quantity = (double)oi.OrderQuantity;
                        //db.Entry(batch).State = EntityState.Modified;
                        //db.SaveChanges();
                        //StockBatch stockBatch = db.StockBatches.Where(x => x.BatchId == batch.BatchId).FirstOrDefault();
                        //stockBatch.Quantity = batch.Quantity;
                        //db.Entry(stockBatch).State = EntityState.Modified;
                        //db.SaveChanges();
                    }
                    else
                    {
                        db.OrderItemDetails.Remove(db.OrderItemDetails.Where(x => x.Id == orderItem.Id).FirstOrDefault());
                        db.SaveChanges();
                        db.OrderItems.Remove(orderItem);
                        db.SaveChanges();
                     }
                }
                int batchno = 0;
                if (db.Batches.Where(x => x.CompanyId == order.CompanyId).Any())
                {
                    batchno = db.Batches.Where(x => x.CompanyId == order.CompanyId).Max(x => x.BatchNo);
                }
                foreach (OrderItem orderItem1 in newItems)
                {
                    if(!olditems.Where(x => x.BarcodeId == orderItem1.BarcodeId && x.Price == orderItem1.Price).Any())
                    {
                        orderItem1.Id = 0;
                        orderItem1.OrderId = order.Id;
                        db.OrderItems.Add(orderItem1);
                        db.SaveChanges();
                        int? barcodeid = orderItem1.BarcodeId;
                        Batch batch = new Batch();
                        batch.BarcodeId = (int)(int?)orderItem1.BarcodeId;
                        batch.BatchNo = batchno;
                        batch.CompanyId = order.CompanyId;
                        batch.EntryDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                        batch.Price = (double)(double?)orderItem1.Price;
                        batch.ProductId = orderItem1.ProductId;
                        batch.StoreId = (int)order.StoreId;
                        batch.Quantity = (int)orderItem1.OrderQuantity;
                        db.Batches.Add(batch);
                        db.SaveChanges();
                        StockBatch stockBatch = new StockBatch();
                        stockBatch.BatchId = batch.BatchId;
                        stockBatch.CompanyId = batch.CompanyId;
                        stockBatch.CreatedBy = order.OrderedById;
                        stockBatch.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                        stockBatch.Quantity = batch.Quantity;
                        stockBatch.StockId = db.Stocks.Where(x => x.StoreId == order.StoreId && x.BarcodeId == batch.BarcodeId).FirstOrDefault().StockId;
                        stockBatch.Updated = true;
                        stockBatch.ProductName = getBarcodeProductName(batch.BarcodeId, batch.ProductId);
                        db.StockBatches.Add(stockBatch);
                        db.SaveChanges();

                        OrderItemDetail orderItemDetail = new OrderItemDetail();
                        orderItemDetail.ActualProdId = orderItem1.ProductId;
                        orderItemDetail.Amount = (double)orderItem1.TotalAmount;
                        orderItemDetail.BatchId = batch.BatchId;
                        orderItemDetail.CompanyId = order.CompanyId;
                        orderItemDetail.CreatedBy = order.OrderedById;
                        orderItemDetail.CreatedDate = order.CreatedDate;
                        orderItemDetail.DiscAmount = (double)orderItem1.DiscAmount;
                        orderItemDetail.DiscPercent = (double)orderItem1.DiscPercent;
                        orderItemDetail.DiscPerQty = (double)(orderItem1.DiscAmount / orderItem1.OrderQuantity);
                        orderItemDetail.Id = orderItem1.Id;
                        orderItemDetail.OrderItemType = 1;
                        orderItemDetail.Quantity = (double)orderItem1.OrderQuantity;
                        orderItemDetail.StorageStoreId = order.StoreId;
                        orderItemDetail.Tax1 = (double)orderItem1.Tax1;
                        orderItemDetail.Tax2 = (double)orderItem1.Tax2;
                        orderItemDetail.TaxAmount = (double)orderItem1.TaxAmount;
                        orderItemDetail.UnitPrice = (double)(orderItem1.TotalAmount / orderItem1.OrderQuantity);
                        db.OrderItemDetails.Add(orderItemDetail);
                        db.SaveChanges();
                    }
                }
                //List<OrderItem> orderItems = db.OrderItems.Where(x => x.OrderId == order.Id).AsNoTracking().ToList();
                //List<OrderItemDetail> orderItemDetails = db.OrderItemDetails.Where(x => orderItems.Where(oi => oi.Id == x.OrderItemId).Any()).AsNoTracking().ToList();
                //List<StockBatch> stockBatches = db.StockBatches.Where(x => orderItemDetails.Where(oid => oid.BatchId == x.BatchId).Any()).AsNoTracking().ToList();
                //foreach(StockBatch sb in stockBatches)
                //{
                //    Batch batch = db.Batches.Find(sb.BatchId);
                //    sb.ProductName = getBarcodeProductName(batch.BarcodeId, batch.ProductId);
                //    sb.Batch = batch;
                //}
                var response = new
                {
                    status = 200,
                    message = "Purchase Item Updated Successfully",
                    //stockBatches = stockBatches
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }



        [HttpGet("getVendorOrders")]
        public IActionResult getVendorOrders(int companyid, int storeid, int vendorid)
        {
            try
            {
                
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.VendorOrders", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@vendorid", vendorid));
                cmd.Parameters.Add(new SqlParameter("@companyid", companyid));
                cmd.Parameters.Add(new SqlParameter("@storeid", storeid));

                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    Order = ds.Tables[0],
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }

        }
        [HttpGet("getReceivedOrders")]
        public IActionResult getReceivedOrders(int companyid, int storeid)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.ReceievedOrders", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@vendorid", vendorid));
                cmd.Parameters.Add(new SqlParameter("@companyid", companyid));
                cmd.Parameters.Add(new SqlParameter("@storeid", storeid));

                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    ReceivedOrder = ds.Tables[0],
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }

        }
        [HttpPost("updatereceiveItem")]
        public IActionResult updatereceiveItem(int orderid, int userid, [FromBody]dynamic items)
        {
            try
            {
                Order order = db.Orders.Find(orderid);
                order.ReceiveStatus = 1;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                Bill bill = new Bill();
                bill.BillAmount = order.BillAmount;
                bill.OrderId = order.Id;
                bill.BillDate = order.BillDate;
                bill.BillAmountNoTax = order.BillAmount - (order.Tax1 + order.Tax2 + order.Tax3);
                bill.BillType = 1;
                bill.CompanyId = order.CompanyId;
                bill.CreatedDate = order.CreatedDate;
                bill.DiscAmount = order.DiscAmount;
                bill.DiscPercent = order.DiscPercent;
                bill.InVoiceNum = order.InvoiceNo;
                bill.OrderItemDetails = order.OrderItemDetails;
                bill.OrderItems = order.OrderItems;
                bill.PaidAmount = order.PaidAmount;
                //bill.PaymentStoreId = order.StoreId;
                bill.ProviderId = order.SuppliedById;
                bill.ReceivedById = userid;
                bill.ReceivedDate = DateTime.Now;
                bill.ReceiveLater = false;
                bill.ReceiverId = (int)order.OrderedById;
                bill.ReceiveStatus = 1;
                bill.ShowAllProd = false;
                bill.ShowBatch = false;
                bill.ShowDiscount = false;
                bill.ShowProdReturn = false;
                bill.ShowRelatedOdr = false;
                bill.TaxAmount = order.Tax1 + order.Tax2 + order.Tax3;
                //bill.TotalDiscount = order.disc
                db.Bill.Add(bill);
                db.SaveChanges();

                List<OrderItem> orderItems = items.ToObject<List<OrderItem>>();
                List<Batch> batches = new List<Batch>();
                List<StockBatch> stockBatches = new List<StockBatch>();
                int batchno = 0;
                if (db.Batches.Where(x => x.CompanyId == order.CompanyId).Any())
                {
                    batchno = db.Batches.Where(x => x.CompanyId == order.CompanyId).Max(x => x.BatchNo);
                }
                foreach (OrderItem item in orderItems)
                {
                    if(item.Id > 0)
                    {
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        item.OrderId = orderid;
                        item.CompanyId = order.CompanyId;
                        db.OrderItems.Add(item);
                        db.SaveChanges();
                    }
                    int? barcodeid = item.BarcodeId;
                    Batch batch = new Batch();
                    batch.BarcodeId = (int)(int?)item.BarcodeId;
                    batch.BatchNo = batchno;
                    batch.CompanyId = order.CompanyId;
                    batch.EntryDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    batch.Price = (double)(double?)item.Price;
                    batch.ProductId = item.ProductId;
                    batch.StoreId = (int)order.StoreId;
                    batch.Quantity = (int)item.ReceivedQuantity;
                    db.Batches.Add(batch);
                    db.SaveChanges();
                    StockBatch stockBatch = new StockBatch();
                    stockBatch.BatchId = batch.BatchId;
                    stockBatch.CompanyId = batch.CompanyId;
                    stockBatch.CreatedBy = order.OrderedById;
                    stockBatch.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    stockBatch.Quantity = batch.Quantity;
                    stockBatch.StockId = db.Stocks.Where(x => x.StoreId == order.StoreId && x.BarcodeId == batch.BarcodeId).FirstOrDefault().StockId;
                    stockBatch.Updated = true;
                    stockBatch.ProductName = getBarcodeProductName(batch.BarcodeId, batch.ProductId);
                    db.StockBatches.Add(stockBatch);
                    db.SaveChanges();
                    OrderItemDetail orderItemDetail = new OrderItemDetail();
                    orderItemDetail.OrderItemId = item.Id;
                    orderItemDetail.ActualProdId = item.ProductId;
                    orderItemDetail.Amount = (double)item.TotalAmount;
                    orderItemDetail.BatchId = batch.BatchId;
                    orderItemDetail.CompanyId = order.CompanyId;
                    orderItemDetail.CreatedBy = order.OrderedById;
                    orderItemDetail.CreatedDate = order.CreatedDate;
                    orderItemDetail.DiscAmount = (double)item.DiscAmount;
                    orderItemDetail.DiscPercent = (double)item.DiscPercent;
                    orderItemDetail.DiscPerQty = (double)(item.DiscAmount / item.OrderQuantity);
                    orderItemDetail.OrderItemType = 3;
                    orderItemDetail.Quantity = (double)item.OrderQuantity;
                    orderItemDetail.StorageStoreId = order.StoreId;
                    orderItemDetail.Tax1 = (double)item.Tax1;
                    orderItemDetail.Tax2 = (double)item.Tax2;
                    orderItemDetail.TaxAmount = (double)item.TaxAmount;
                    orderItemDetail.UnitPrice = (double)(item.TotalAmount / item.OrderQuantity);
                    orderItemDetail.BillId = bill.BillId;
                    db.OrderItemDetails.Add(orderItemDetail);
                    db.SaveChanges();
                }
                List<OrderItem> orderItems1 = db.OrderItems.Where(x => x.OrderId == order.Id).AsNoTracking().ToList();
                List<OrderItemDetail> orderItemDetails = db.OrderItemDetails.Where(x => orderItems.Where(oi => oi.Id == x.OrderItemId).Any()).AsNoTracking().ToList();
                List<StockBatch> stockBatches2 = db.StockBatches.Where(x => orderItemDetails.Where(oid => oid.BatchId == x.BatchId).Any()).AsNoTracking().ToList();
                foreach (StockBatch sb in stockBatches2)
                {
                    Batch batch = db.Batches.Find(sb.BatchId);
                    sb.ProductName = getBarcodeProductName(batch.BarcodeId, batch.ProductId);
                    sb.Batch = batch;
                }

                var response = new
                {
                    status = 200,
                    message = "Received Successfully",
                    stockBatches = stockBatches2
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                 };
                return Ok(response);
            }

        }
        public string getBarcodeProductName(int barcodeid, int productid)
        {
            string productName = db.Products.Find(productid).Name;
            List<BarcodeVariant> barcodeVariants = db.BarcodeVariants.Where(x => x.BarcodeId == barcodeid).ToList();
            foreach(BarcodeVariant barcodeVariant in barcodeVariants)
            {
                productName += "/" + db.Variants.Find(barcodeVariant.VariantId).Name;
            }
            return productName;
        }
        [HttpPost("directReceiveItem")]
        public IActionResult directReceiveItem(int userid,[FromBody]dynamic payload)
        { 
            try
            {

                Order order1 = new Order();
                order1 = payload.ToObject<Order>();
                order1.ReceiveStatus = 1;
                db.Orders.Add(order1);
                db.SaveChanges();
                Bill bill = new Bill();
                bill.BillAmount = order1.BillAmount;
                bill.OrderId = order1.Id;
                bill.BillDate = order1.BillDate;
                bill.BillAmountNoTax = order1.BillAmount - (order1.Tax1 + order1.Tax2 + order1.Tax3);
                bill.BillType = 1;
                bill.CompanyId = order1.CompanyId;
                bill.CreatedDate = order1.CreatedDate;
                bill.DiscAmount = order1.DiscAmount;
                bill.DiscPercent = order1.DiscPercent;
                bill.InVoiceNum = order1.InvoiceNo;
                bill.OrderItemDetails = order1.OrderItemDetails;
                bill.OrderItems = order1.OrderItems;
                bill.PaidAmount = order1.PaidAmount;
                //bill.PaymentStoreId = order.StoreId;
                bill.ProviderId = order1.SuppliedById;
                bill.ReceivedById = userid;
                bill.ReceivedDate = DateTime.Now;
                bill.ReceiveLater = false;
                bill.ReceiverId = (int)order1.OrderedById;
                bill.ReceiveStatus = 1;
                bill.ShowAllProd = false;
                bill.ShowBatch = false;
                bill.ShowDiscount = false;
                bill.ShowProdReturn = false;
                bill.ShowRelatedOdr = false;
                bill.TaxAmount = order1.Tax1 + order1.Tax2 + order1.Tax3;
                //bill.TotalDiscount = order.disc
                db.Bill.Add(bill);
                db.SaveChanges();
                List<Batch> batches = new List<Batch>();
                List<StockBatch> stockBatches = new List<StockBatch>();
                int batchno = 0;
                if (db.Batches.Where(x => x.CompanyId == order1.CompanyId).Any())
                {
                    batchno = db.Batches.Where(x => x.CompanyId == order1.CompanyId).Max(x => x.BatchNo);
                }
                
                foreach (var item in payload.Items)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem = item.ToObject<OrderItem>();
                    orderItem.OrderId = order1.Id;
                    orderItem.CompanyId = order1.CompanyId;
                    db.OrderItems.Add(orderItem);
                    db.SaveChanges();
                    int? barcodeid = orderItem.BarcodeId;
                    Batch batch = new Batch();
                    batch.BarcodeId = (int)(int?)orderItem.BarcodeId;
                    batch.BatchNo = batchno;
                    batch.CompanyId = order1.CompanyId;
                    batch.EntryDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    batch.Price = (double)(double?)orderItem.Price;
                    batch.ProductId = orderItem.ProductId;
                    batch.StoreId = (int)order1.StoreId;
                    batch.Quantity = (int)orderItem.OrderQuantity;
                    db.Batches.Add(batch);
                    db.SaveChanges();
                    batches.Add(batch);
                    StockBatch stockBatch = new StockBatch();
                    stockBatch.BatchId = batch.BatchId;
                    stockBatch.CompanyId = batch.CompanyId;
                    stockBatch.CreatedBy = order1.OrderedById;
                    stockBatch.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    stockBatch.Quantity = batch.Quantity;
                    stockBatch.StockId = db.Stocks.Where(x => x.StoreId == order1.StoreId && x.BarcodeId == batch.BarcodeId).FirstOrDefault().StockId;
                    stockBatch.Updated = true;
                    stockBatch.ProductName = getBarcodeProductName(batch.BarcodeId, batch.ProductId);
                    db.StockBatches.Add(stockBatch);
                    db.SaveChanges();
                    stockBatches.Add(stockBatch);
                    

                    //List<OrderItem> orderItems = payload.Items.ToObject<List<OrderItem>>();
                    //int batchno = 0;
                    //if (db.batches.where(x => x.companyid == order.companyid).any())
                    //{
                    //    batchno = db.batches.where(x => x.companyid == order.companyid).max(x => x.batchno);
                    //}
                        //int? barcodeid = item1.BarcodeId;
                        //Batch batch= new Batch();
                        OrderItemDetail orderItemDetail = new OrderItemDetail();
                        orderItemDetail.ActualProdId = orderItem.ProductId;
                        orderItemDetail.Amount = (double)orderItem.TotalAmount;
                        orderItemDetail.BatchId = batch.BatchId;
                        orderItemDetail.CompanyId = order1.CompanyId;
                        orderItemDetail.CreatedBy = order1.OrderedById;
                        orderItemDetail.CreatedDate = order1.CreatedDate;
                        orderItemDetail.DiscAmount = (double)orderItem.DiscAmount;
                        orderItemDetail.DiscPercent = (double)orderItem.DiscPercent;
                        orderItemDetail.DiscPerQty = (double)(orderItem.DiscAmount / orderItem.OrderQuantity);
                        orderItemDetail.OrderItemId = orderItem.Id;
                        orderItemDetail.OrderItemType = 3;
                        orderItemDetail.Quantity = (double)orderItem.OrderQuantity;
                        orderItemDetail.StorageStoreId = order1.StoreId;
                        orderItemDetail.Tax1 = (double)orderItem.Tax1;
                        orderItemDetail.Tax2 = (double)orderItem.Tax2;
                        orderItemDetail.TaxAmount = (double)orderItem.TaxAmount;
                        orderItemDetail.UnitPrice = (double)(orderItem.TotalAmount / orderItem.OrderQuantity);
                        orderItemDetail.BillId = bill.BillId;
                        db.OrderItemDetails.Add(orderItemDetail);
                        db.SaveChanges();

                    }
                
                int lastorderno = db.Orders.Where(x => x.StoreId == order1.StoreId).Max(x => x.OrderNo);
                var response = new
                {
                    status = 200,
                    message = "Received  Successfully",
                    lastorderno = lastorderno,
                    batches = batches,
                    stockBatches = stockBatches
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }

        [HttpGet("getVendorOrderProduct")]
        public IActionResult getVendorOrderProduct(int orderId)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.VendorOrderProduct", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));

                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    Orderproduct = ds.Tables[0],
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }

        }
        [HttpGet("getVendorReceivedOrder")]
        public IActionResult getVendorReceivedOrder(int companyid, int storeid, int orderid)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.UpdateReceivedOrder", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@orderid", orderid));
                cmd.Parameters.Add(new SqlParameter("@companyid", companyid));
                cmd.Parameters.Add(new SqlParameter("@storeid", storeid));

                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    ReceivedOrder = ds.Tables[0],
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }

        }

        [HttpPost("UpdateReceiveOrder")]
        public IActionResult UpdateReceiveOrder(int orderid, int userid, [FromBody]dynamic orderjson)
        {
            try
            {
                Order order = orderjson.ToObject<Order>();
                order.ReceiveStatus = 1;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                Bill bill = db.Bill.Where(x => x.OrderId == order.Id).FirstOrDefault();
                bill.BillAmount = order.BillAmount;
                bill.PaidAmount = order.PaidAmount;
                bill.DiscAmount = order.DiscAmount;
                bill.DiscPercent = order.DiscPercent;
                bill.ReceivedDate = DateTime.Now;
                bill.BillAmountNoTax = order.BillAmount - (order.Tax1 + order.Tax2 + order.Tax3);
                bill.TaxAmount = order.Tax1 + order.Tax2 + order.Tax3;
                bill.BillDate = order.BillDate;
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                List<OrderItem> oldItems = db.OrderItems.Where(x => x.OrderId == order.Id).AsNoTracking().ToList();
                List<OrderItemDetail> oldItemDetails = db.OrderItemDetails.Where(x => oldItems.Where(y => y.Id == x.OrderItemId).Any()).AsNoTracking().ToList();
                List<OrderItem> orderItems = orderjson.Items.ToObject<List<OrderItem>>();
                List<Batch> batches = new List<Batch>();
                List<StockBatch> stockBatches = new List<StockBatch>();
                foreach (OrderItem orderItem in orderItems)
                {
                    int batchno = 0;
                    if (db.Batches.Where(x => x.CompanyId == order.CompanyId).Any())
                    {
                        batchno = db.Batches.Where(x => x.CompanyId == order.CompanyId).Max(x => x.BatchNo);
                    }
                    if (orderItem.Id > 0) 
                    {
                        double oldquantity = (double)db.OrderItems.Where(x => x.Id == orderItem.Id).AsNoTracking().FirstOrDefault().ReceivedQuantity;
                        double newquantity = (double)orderItem.ReceivedQuantity;
                        double diff = newquantity - oldquantity;
                        orderItem.ReturnedQuantity += diff < 0 ? diff * -1 : 0;
                        db.Entry(orderItem).State = EntityState.Modified;
                        db.SaveChanges();
                        if(diff != 0)
                        {
                            int batchid = (int)db.OrderItemDetails.Where(x => x.OrderItemId == orderItem.Id && x.BatchId != null).FirstOrDefault().BatchId;
                            OrderItemDetail orderItemDetail = new OrderItemDetail();
                            orderItemDetail.Quantity = diff > 0 ? diff : diff * -1;
                            orderItemDetail.ActualProdId = orderItem.ProductId;
                            orderItemDetail.Amount = (double)orderItem.TotalAmount;
                            orderItemDetail.CompanyId = order.CompanyId;
                            orderItemDetail.CreatedBy = order.OrderedById;
                            orderItemDetail.CreatedDate = order.CreatedDate;
                            orderItemDetail.DiscAmount = (double)orderItem.DiscAmount;
                            orderItemDetail.DiscPercent = (double)orderItem.DiscPercent;
                            orderItemDetail.DiscPerQty = (double)(orderItem.DiscAmount / orderItem.ReceivedQuantity);
                            orderItemDetail.OrderItemId = orderItem.Id;
                            if (diff > 0) orderItemDetail.OrderItemType = 3;
                            if (diff < 0) orderItemDetail.OrderItemType = 4;
                            orderItemDetail.StorageStoreId = order.StoreId;
                            orderItemDetail.Tax1 = (double)orderItem.Tax1;
                            orderItemDetail.Tax2 = (double)orderItem.Tax2;
                            orderItemDetail.TaxAmount = (double)orderItem.TaxAmount;
                            orderItemDetail.UnitPrice = (double)(orderItem.TotalAmount / orderItem.ReceivedQuantity);
                            orderItemDetail.BillId = bill.BillId;
                            orderItemDetail.BatchId = batchid;
                            db.OrderItemDetails.Add(orderItemDetail);
                            db.SaveChanges();
                            Batch batch = db.Batches.Find(batchid);
                            batch.Price = (double)orderItemDetail.UnitPrice;
                            batch.Quantity = (double)orderItem.ReceivedQuantity;
                            db.Entry(batch).State = EntityState.Modified;
                            db.SaveChanges();
                            StockBatch stockBatch = db.StockBatches.Where(x => x.BatchId == batchid).FirstOrDefault();
                            stockBatch.Quantity = (double)orderItem.ReceivedQuantity;
                            db.Entry(stockBatch).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        oldItems.Remove(oldItems.Where(oi => oi.Id == orderItem.Id).FirstOrDefault());
                        oldItemDetails.RemoveAll(oid => oid.OrderItemId == orderItem.Id);
                    }
                    else
                    {
                        orderItem.OrderId = order.Id;
                        orderItem.CompanyId = order.CompanyId;
                        db.OrderItems.Add(orderItem);
                        db.SaveChanges();
                        int? barcodeid = orderItem.BarcodeId;
                        Batch batch = new Batch();
                        batch.BarcodeId = (int)(int?)orderItem.BarcodeId;
                        batch.BatchNo = batchno;
                        batch.CompanyId = order.CompanyId;
                        batch.EntryDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                        batch.Price = (double)(double?)orderItem.Price;
                        batch.ProductId = orderItem.ProductId;
                        batch.StoreId = (int)order.StoreId;
                        batch.Quantity = (int)orderItem.OrderQuantity;
                        db.Batches.Add(batch);
                        db.SaveChanges();
                        StockBatch stockBatch = new StockBatch();
                        stockBatch.BatchId = batch.BatchId;
                        stockBatch.CompanyId = batch.CompanyId;
                        stockBatch.CreatedBy = order.OrderedById;
                        stockBatch.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                        stockBatch.Quantity = batch.Quantity;
                        stockBatch.StockId = db.Stocks.Where(x => x.StoreId == order.StoreId && x.BarcodeId == batch.BarcodeId).FirstOrDefault().StockId;
                        stockBatch.Updated = true;
                        stockBatch.ProductName = getBarcodeProductName(batch.BarcodeId, batch.ProductId);
                        db.StockBatches.Add(stockBatch);
                        db.SaveChanges();


                        //List<OrderItem> orderItems = payload.Items.ToObject<List<OrderItem>>();
                        //int batchno = 0;
                        //if (db.batches.where(x => x.companyid == order.companyid).any())
                        //{
                        //    batchno = db.batches.where(x => x.companyid == order.companyid).max(x => x.batchno);
                        //}
                        //int? barcodeid = item1.BarcodeId;
                        //Batch batch= new Batch();
                        OrderItemDetail orderItemDetail = new OrderItemDetail();
                        orderItemDetail.ActualProdId = orderItem.ProductId;
                        orderItemDetail.Amount = (double)orderItem.TotalAmount;
                        orderItemDetail.BatchId = batch.BatchId;
                        orderItemDetail.CompanyId = order.CompanyId;
                        orderItemDetail.CreatedBy = order.OrderedById;
                        orderItemDetail.CreatedDate = order.CreatedDate;
                        orderItemDetail.DiscAmount = (double)orderItem.DiscAmount;
                        orderItemDetail.DiscPercent = (double)orderItem.DiscPercent;
                        orderItemDetail.DiscPerQty = (double)(orderItem.DiscAmount / orderItem.OrderQuantity);
                        orderItemDetail.OrderItemId = orderItem.Id;
                        orderItemDetail.OrderItemType = 3;
                        orderItemDetail.Quantity = (double)orderItem.OrderQuantity;
                        orderItemDetail.StorageStoreId = order.StoreId;
                        orderItemDetail.Tax1 = (double)orderItem.Tax1;
                        orderItemDetail.Tax2 = (double)orderItem.Tax2;
                        orderItemDetail.TaxAmount = (double)orderItem.TaxAmount;
                        orderItemDetail.UnitPrice = (double)(orderItem.TotalAmount / orderItem.OrderQuantity);
                        orderItemDetail.BillId = bill.BillId;
                        db.OrderItemDetails.Add(orderItemDetail);
                        db.SaveChanges();

                    }
                    
                }
                db.OrderItemDetails.RemoveRange(oldItemDetails);
                db.OrderItems.RemoveRange(oldItems);
                db.SaveChanges();
                List<OrderItem> orderItems1 = db.OrderItems.Where(x => x.OrderId == order.Id).AsNoTracking().ToList();
                List<OrderItemDetail> orderItemDetails = db.OrderItemDetails.Where(x => orderItems.Where(oi => oi.Id == x.OrderItemId).Any()).AsNoTracking().ToList();
                List<StockBatch> stockBatches2 = db.StockBatches.Where(x => orderItemDetails.Where(oid => oid.BatchId == x.BatchId).Any()).AsNoTracking().ToList();
                foreach(StockBatch sb in stockBatches2)
                {
                    Batch batch = db.Batches.Find(sb.BatchId);
                    sb.ProductName = getBarcodeProductName(batch.BarcodeId, batch.ProductId);
                    sb.Batch = batch;
                }
                var response = new
                {
                    status = 200,
                    message = "Updated Received  Successfully",
                    batches = batches,
                    stockBatches = stockBatches2
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }

        }


        // POST: PurchaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
