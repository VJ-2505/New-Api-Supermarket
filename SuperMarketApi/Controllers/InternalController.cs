using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using SuperMarketApi.Models.Enum;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel.Design;
/*using System.Linq;*/
namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class InternalController : Controller
    {
        private POSDbContext db;

        public IConfiguration Configuration { get; }
        public TimeZoneInfo India_Standard_Time { get; private set; }

        public InternalController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        //[httpget("getstorelist")]
        //public iactionresult getstorelist(int companyid)
        //{
        //    var response = new
        //    {
        //        storelist = db.Stores.where(x => x.companyid == companyid).include(i => i.plan).tolist(),
        //        cuslist = db.Contacts.where(c => c.companyid == companyid).tolist(),
        //        bankacct = db.BankAccounts.where(b => b.companyid == companyid).tolist()
        //    };
        //    return json(response);
        //}

        //Queen 31-01-2022
        [HttpGet("GetstorebyId")]
        public IActionResult GetstorebyId(int CompanyId, int Id)
        {
            var response = new
            {
                StoreList = db.Stores.Where(x => x.CompanyId == CompanyId && (x.Id == Id || Id == 0)).ToList(),
            };
            return Json(response);
        }

        [HttpGet("getstorelist")]
        public IActionResult getstorelist (int companyid)
        {
            var response = new

            {
                storelist = db.Stores.Where(x => x.CompanyId == companyid).ToList(),
                cuslist = db.Contacts.Where(c => c.CompanyId == companyid).ToList(),
                bankacct = db.BankAccounts.Where(b => b.CompanyId == companyid).ToList()
            };
            return Json(response);
        }



      

     


        [HttpGet("GetInternalproduct")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetInternalproduct(int CompanyId, int StoreId, bool testid)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.addWastage", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CompanyId", CompanyId));
                cmd.Parameters.Add(new SqlParameter("@StoreId", StoreId));
                cmd.Parameters.Add(new SqlParameter("@testid", testid));
                DataSet ds = new DataSet();
                if (testid == false)
                {
                    SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                    sqlAdp.Fill(ds);
                    var response = new
                    {
                        batchprod = ds.Tables[0],

                        status = 200,
                    };
                    return Json(response);

                }
                else
                {
                    SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                    sqlAdp.Fill(ds);
                    var response = new
                    {
                        product = ds.Tables[0],
                        batchprod = ds.Tables[1],
                        status = 200,
                    };
                    return Json(response);

                }

            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 500,
                    error = new Exception(ex.Message, ex.InnerException),
                };
                return Json(response);
            }
        }




        [HttpGet("getContactData")]
        public IActionResult getStoreData(int CompanyId)
        {
            var response =

                 db.Contacts.Where(x => x.CompanyId == CompanyId).ToList();

            return Json(response);
        }

        // [HttpGet("GetProducts")]
        //public IActionResult GetProducts(int companyId)
        //  {
        //      var response = new
        //      {
        //          prdList = (from o in db.Products
        //                          join oi in db.Stores on o.CompanyId equals oi.CompanyId
        //                          where
        //                          o.CompanyId == companyId

        //                          select o.Name,oi.Name).ToList()
        //      };
        //      return Json (response);
        //  }

        [HttpGet("getStoreProducts")]
        public IActionResult getStoreProducts(int storeid)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetStoreProducts", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@storeid", storeid));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    status = 200,
                    products = ds.Tables[0],
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
        [HttpPost("saveIntOrd")]
        public IActionResult saveIntOrd([FromBody] dynamic objData)
        {
            try
            {
                dynamic jsonObj = objData;
                int companyId = jsonObj.compId;
                int? orderId = jsonObj.Id;
                int? contactId = jsonObj.Id;
                int? ordItemId = jsonObj.ordItemId;
                string draft = jsonObj.draft;
                JArray items = jsonObj.Items;
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj);
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.saveinternal", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@orderJson", jsonString));
                cmd.Parameters.Add(new SqlParameter("@companyid", companyId));
                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                cmd.Parameters.Add(new SqlParameter("@ordItemId", ordItemId));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    status = 200,
                    message = " Item Added Successfully",
                    //lastorderno = lastorderno
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


        [HttpPost("saveinternaltransfer")]
        public IActionResult saveinternaltransfer([FromBody] dynamic objData)
        {
            try
            {

                dynamic jsonObj = objData;
                Order order = jsonObj.order.ToObject<Order>();
                int companyId = jsonObj.compId;
                string draft = jsonObj.draft;
                JArray items = jsonObj.Items;
                dynamic itemArray = items.ToList();
                db.Orders.Add(order);

                for (int i = 0; i < items.Count; i++)
                {
                    int productId = itemArray[i].ProductId;
                    double quantity = itemArray[i].OrderQuantity;
                    double? price = itemArray[i].Price;
                    double? tax1 = itemArray[i].Tax1;
                    double? tax2 = itemArray[i].Tax2;
                    double? taxamountitem = itemArray[i].TotalAmount;
                    double? amount = itemArray[i].Amount;
                    double? taxamount = quantity * price * (tax1 + tax2) / 100;

                    OrderItem orderProd = new OrderItem(
                              order.Id, productId, quantity, price, tax1, tax2, 0, taxamountitem, amount, companyId);

                    orderProd.Status = (int)OrderProductStatus.Open;
                    orderProd.CompanyId = companyId;
                    db.OrderItems.Add(orderProd);
                    db.SaveChanges();
                    OrderItemDetail ordProdDetail = new OrderItemDetail(orderProd.Id, null, (int)SuperMarketApi.Models.Enum.OrderItemType.Order, quantity, 0, 0, 0, 0, DateTime.Now, db);
                    ordProdDetail.UnitPrice = price;
                    ordProdDetail.Tax1 = tax1;
                    ordProdDetail.Tax2 = tax2;
                    ordProdDetail.TaxAmount = taxamount;
                    ordProdDetail.Amount = amount;
                    ordProdDetail.CompanyId = companyId;
                    ordProdDetail.OrderItemId = orderProd.Id;
                    db.OrderItemDetails.Add(ordProdDetail);

                    db.SaveChanges();
                }
                //int lastorderno = db.Orders.Where(x => x.StoreId == order.StoreId).Max(x => x.OrderNo);
                var response = new
                {
                    status = 200,
                    message = " Item Added Successfully",
                    //lastorderno = lastorderno
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

        //[httppost("getorderlist")]
        //public iactionresult getorderlist([frombody] dynamic objdata)
        //{
        //    dynamic jsonobj = objdata;
        //    int companyid = jsonobj[0].companyid;
        //    int? searchid = jsonobj[0].searchid;
        //    //int? searchstoreid = jsonobj[0].searchstoreid;
        //    datetime? datefrom = jsonobj[0].datefrom;
        //    datetime? dateto = datetime.now;
        //    //int? orderstatus = jsonobj[0].orderstatus;
        //    //int? dispatchstatus = jsonobj[0].dispatchstatus;
        //    //string wipstatus = jsonobj[0].wipstatus;
        //    //string prodstatus = jsonobj[0].prodstatus;
        //    string numrecords = jsonobj[0].numrecordsstr;
        //    //string specialorder = jsonobj[0].specialorder;
        //    //string productdesc = jsonobj[0].productdesc;
        //    //int? cancelstatus = jsonobj[0].cancelstatus;
        //    //int? receivestatus = jsonobj[0].receivestatus;
        //    //int? productid = jsonobj[0].productid;
        //    //int? billid = jsonobj[0].billid;
        //    //int? searchdispatchsts = jsonobj[0].searchdispatchsts;
        //    //string userid = jsonobj[0].userid;
        //    //int? storeid = jsonobj[0].storeid;
        //    //string ordertype = jsonobj[0].ordertype;

        //    sqlconnection sqlcon = new sqlconnection(configuration.getconnectionstring("myconn"));
        //    sqlcon.open();

        //    sqlcommand cmd = new sqlcommand("dbo.internal", sqlcon);
        //    cmd.commandtype = commandtype.storedprocedure;
        //    //cmd.parameters.add(new sqlparameter("@orderstatus", orderstatus));
        //    //cmd.parameters.add(new sqlparameter("@dispatchstatus", dispatchstatus));
        //    cmd.parameters.add(new sqlparameter("@searchid", searchid));
        //    //cmd.parameters.add(new sqlparameter("@searchstoreid", searchstoreid));
        //    cmd.parameters.add(new sqlparameter("@fromdate", datefrom));
        //    cmd.parameters.add(new sqlparameter("@todate", dateto));
        //    cmd.parameters.add(new sqlparameter("@numrecords", numrecords));
        //    //cmd.parameters.add(new sqlparameter("@sessionstoreid", 0));
        //    //cmd.parameters.add(new sqlparameter("@userid", userid));
        //    //cmd.parameters.add(new sqlparameter("@ordertype", ordertype));
        //    //cmd.parameters.add(new sqlparameter("@cancelstatus", cancelstatus));
        //    //cmd.parameters.add(new sqlparameter("@receivestatus", receivestatus));
        //    //cmd.parameters.add(new sqlparameter("@productid", productid));
        //    //cmd.parameters.add(new sqlparameter("@billid", billid));
        //    //cmd.parameters.add(new sqlparameter("@specialorder", specialorder));
        //    //cmd.parameters.add(new sqlparameter("@wipstatus", wipstatus));
        //    //cmd.parameters.add(new sqlparameter("@prodstatus", prodstatus));
        //    //cmd.parameters.add(new sqlparameter("@searchdispatchsts", searchdispatchsts));
        //    //cmd.parameters.add(new sqlparameter("@productdesc", productdesc));
        //    cmd.parameters.add(new sqlparameter("@companyid", companyid));
        //    dataset ds = new dataset();
        //    sqldataadapter sqladp = new sqldataadapter(cmd);
        //    sqladp.fill(ds);
        //    var response = new
        //    {
        //        order = ds.tables[0]
        //    };
        //    return ok(response);

        //}
        //[HttpGet("getOrderList")]
        //public IActionResult getOrderList(int companyId, int searchId, int numRecords = 25)
        //{
        //    try
        //    {
        //        SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        //        sqlCon.Open();

        //        SqlCommand cmd = new SqlCommand("dbo.Internal", sqlCon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@searchId", searchId));
        //        cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
        //        cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords));
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        //        sqlAdp.Fill(ds);
        //        string Jstring = "";
        //        for(int j = 0; j < ds.Tables[0].Rows.Count; j++)
        //        {
        //            Jstring += ds.Tables[0].Rows[j].ItemArray[0].ToString();
        //        }
        //        var data = new
        //        {
        //            status = 200,
        //            Orders = JsonConvert.DeserializeObject(Jstring)
        //        };
        //        //sqlCon.Close();
        //        return Json(data);
        //    }
        //    catch (Exception e)
        //    {
        //        var error = new
        //        {
        //            error = new Exception(e.Message, e.InnerException),
        //            status = 500,
        //            msg = "Something went wrong  Contact our service provider"
        //        };
        //        return Json(error);
        //    }

        //}


        [HttpGet("getOrderList")]
        public IActionResult getOrderList(int storeId, int? searchId, int numRecords = 25)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.Internal", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@searchId", searchId));
                cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords));
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);

                var response = new
                {
                    order = ds.Tables[0],
                    status = 200,

                };
                return Json(response);
            }
            catch (Exception e)
            {
                var response = new
                {
                    status = 500,
                    error = new Exception(e.Message, e.InnerException)
                };
                return Json(response);
            }
        }



        [HttpGet("GetDispatchList")]
        public IActionResult GetDispatchList(int companyid, int storeid)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.ReceievedOrders", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@companyid", companyid));
                cmd.Parameters.Add(new SqlParameter("@storeid", storeid));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);

                var response = new
                {
                    order = ds.Tables[0],
                    status = 200,

                };
                return Json(response);
            }
            catch (Exception e)
            {
                var response = new
                {
                    status = 500,
                    error = new Exception(e.Message, e.InnerException)
                };
                return Json(response);
            }
        }

        [HttpGet("GetDispatchedorder")]
        public IActionResult GetDispatchedorder(int companyid, int storeid)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.dispatchedorder", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@companyid", companyid));
                cmd.Parameters.Add(new SqlParameter("@storeid", storeid));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);

                var response = new
                {
                    order = ds.Tables[0],
                    status = 200,

                };
                return Json(response);
            }
            catch (Exception e)
            {
                var response = new
                {
                    status = 500,
                    error = new Exception(e.Message, e.InnerException)
                };
                return Json(response);
            }
        }


        [HttpGet("GetDispatch")]
        public IActionResult GetDispatch(int companyId, int StoreId, int numRecords = 25)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.Dispatch", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords));
                cmd.Parameters.Add(new SqlParameter("@StoreId", StoreId));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    order = ds.Tables[0],
                    status = 200,

                };
                return Json(response);
            }
            catch (Exception e)
            {
                var response = new
                {
                    status = 500,
                    error = new Exception(e.Message, e.InnerException)
                };
                return Json(response);
            }
        }

        //[HttpPost("getDispatchList")]
        //public IActionResult getDispatchList([FromBody] dynamic objData)
        //{
        //    dynamic jsonObj = objData;
        //    int CompanyId = jsonObj[0].companyId;
        //    int? billStatus = jsonObj[0].billStatus;
        //    int UserId = jsonObj[0].UserId;
        //    string dispatchType = jsonObj[0].dispatchType;
        //    int? searchStoreId = jsonObj[0].searchStoreId;
        //    int? searchDispatchType = jsonObj[0].searchDispatchType;
        //    int? billId = jsonObj[0].billId;
        //    int? productId = jsonObj[0].productId;
        //    int? orderId = jsonObj[0].orderId;
        //    int? NumRecords = jsonObj[0].NumRecords;
        //    DateTime? fromDate = jsonObj[0].fromDate;
        //    DateTime? ToDate = DateTime.Now;
        //    SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        //    sqlCon.Open();

        //    SqlCommand cmd = new SqlCommand("dbo.DispatchOrdIndex", sqlCon);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("@CompanyId", CompanyId));
        //    if (orderId == 0)
        //        cmd.Parameters.Add(new SqlParameter("@orderId", null));
        //    else
        //        cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
        //    cmd.Parameters.Add(new SqlParameter("@billStatus", billStatus));
        //    cmd.Parameters.Add(new SqlParameter("@searchId", billId));
        //    cmd.Parameters.Add(new SqlParameter("@searchStoreId", searchStoreId));
        //    cmd.Parameters.Add(new SqlParameter("@dispatchType", dispatchType));
        //    cmd.Parameters.Add(new SqlParameter("@SearchDispatchType", searchDispatchType));
        //    cmd.Parameters.Add(new SqlParameter("@sessionStoreID", 0));
        //    cmd.Parameters.Add(new SqlParameter("@fromDate", fromDate));
        //    cmd.Parameters.Add(new SqlParameter("@todate", ToDate));
        //    cmd.Parameters.Add(new SqlParameter("@userId", UserId));
        //    cmd.Parameters.Add(new SqlParameter("@productId", productId));
        //    cmd.Parameters.Add(new SqlParameter("@numRecords", NumRecords));
        //    //cmd.Parameters.Add(new SqlParameter("@suppliedById", null));
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        //    sqlAdp.Fill(ds);
        //    var response = new
        //    {
        //        Order = ds.Tables[0]
        //    };
        //    return Ok(response);

        //}

        [HttpPost("DeleteOrder")]
        public IActionResult DeleteOrder([FromBody] dynamic objData)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    dynamic jsonObj = objData;
                    int companyId = jsonObj.companyId;
                    int id = jsonObj.orderId;
                    Order order = db.Orders.Find(id);

                    List<OrderItem> orderItems = db.OrderItems.Where(o => o.OrderId == order.Id && o.CompanyId == companyId).ToList();
                    order.OrderItems = orderItems;
                    IEnumerable<int> orderProductIds = orderItems.Select(o => o.Id).ToArray();

                    IEnumerable<OrderItemDetail> orderItemDetails = db.OrderItemDetails.Where(o => orderProductIds.Contains(o.OrderItemId) && o.CompanyId == companyId).ToList();
                    db.OrderItemDetails.RemoveRange(orderItemDetails);
                    db.OrderItems.RemoveRange(orderItems);
                    db.Orders.Remove(order);
                    db.SaveChanges();

                    dbContextTransaction.Commit();
                    var data = new
                    {
                        data = " Data deleted Successfully",
                        status = 1
                    };
                    return Json(data);
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    var error = new {
                        data = e.Message,
                        msg = "Contact your service provider",
                        status = 500,
                        error = new Exception(e.Message, e.InnerException)
                    };
                    return Json(error);
                }
            }
        }

        [HttpGet("Delete")]
        public ActionResult Delete(int CompanyId, int ItemId)
        {

            OrderItem orderItem = null;
            orderItem = db.OrderItems.Find(ItemId);
            db.OrderItems.Remove(orderItem);
            //db.SaveChanges();
            //OrderItemDetail orderItemDetail = null;
            IEnumerable<OrderItemDetail> orderItemDetail = db.OrderItemDetails.Where(s => s.OrderItemId == ItemId && s.CompanyId == CompanyId);
            db.OrderItemDetails.RemoveRange(orderItemDetail);
            db.SaveChanges();
            var data = new
            {
                data = "OrderItem Deleted",
                status = 1
            };
            return Json(data);
        }
        public DataTable getOrderItems(int storeid, int companyid)
        {
            System.Diagnostics.Debug.WriteLine("storePaymentTypesTask START: -- " + DateTime.Now.ToString());
            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT spt.Id, spt.Name as Description, spt.MachineId FROM StorePaymentTypes spt
                                            where spt.CompanyId = @companyid AND spt.StoreId = @storeid AND spt.IsActive = 1", sqlCon);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@companyid", companyid));
            cmd.Parameters.Add(new SqlParameter("@storeid", storeid));

            //Task<SqlDataReader> reader = cmd.ExecuteReaderAsync();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            System.Diagnostics.Debug.WriteLine("storePaymentTypesTask END: -- " + DateTime.Now.ToString());
            return table;
        }

        [HttpGet("GetOrderedItems")]
        public IActionResult GetOrderedItems(int CompanyId, int orderId)
        {
            try
            {
                //List<OrderItem> dispatchList = new List<OrderItem>();
                //List<OrderItem> ordItem = new List<OrderItem>();
                //double quantity = 0;
                //Stock supplier = new Stock();
                //StockContainer container = new StockContainer();
                ////double container = 0;
                //Order order = db.Orders.Find(orderId);
                //ordItem = db.OrderItems.Where(o => o.OrderId == orderId && o.CompanyId == CompanyId).ToList();
                //dispatchList = db.OrderItems.Where(s => s.OrderId == orderId && s.CompanyId == CompanyId).Include(x => x.Product).ToList();
                //foreach (OrderItem orderProduct in dispatchList)
                //{
                //    quantity = db.StockBatches.Where(s => s.Stock.ProductId == orderProduct.ProductId
                //                  && s.Stock.StoreId == order.StoreId && s.CompanyId == CompanyId).
                //                  Select(s => s.Quantity).FirstOrDefault();

                //    supplier = db.Stocks.Where(s => s.StoreId == order.StoreId && s.ProductId == orderProduct.ProductId && s.CompanyId == CompanyId).FirstOrDefault();
                //    //if (supplier != null)
                //    //{
                //    //    orderProduct.DispatchStorageName = order.Store.Name;
                //    //    orderProduct.DispatchStorageId = order.StoreId;
                //    //}
                //    container = db.StockContainer.Where(s => s.StoreId == order.StoreId).FirstOrDefault();
                //    if (container != null)
                //    {
                //        orderProduct.Container = container.StockContainerName + " - " + container.ContainerWight + "KG";
                //        orderProduct.ContainerId = container.StockContainerId;
                //        orderProduct.ContainerWeight = container.ContainerWight;
                //    }


                //}
                //var response = new
                //{
                //    dispatchList = dispatchList,
                //    quantity = quantity,
                //    supplier = supplier,
                //    orderProducts = dispatchList,
                //    container = container,
                //    orderItem = ordItem,
                //    Order = order
                //};
                //return Json(response);

                var order = db.Orders.Where(s => s.Id == orderId).Select(s => new {
                    s.Id,
                    s.OrderedDateTime,
                    SuppliedBy = s.SuppliedBy.Name,
                    OrderedBy = s.OrderedBy.Name,
                    SuppliedById = s.SuppliedById,
                    OrderedById = s.OrderedById,
                    StoreId = s.StoreId
                });
                //var orderProd = db.OrderItems.Where(b => b.OrderId == orderId && b.CompanyId == CompanyId).Select(s => new
                //{
                //    s.Product.Name,
                //    maxqty = s.OrderQuantity,
                //    s.Quantity,
                //    s.CancelledQuantity,
                //    s.Tax1,
                //    s.Tax2,
                //    s.Tax3,
                //    s.TaxAmount,
                //    s.Amount,
                //    s.Price,
                //    s.StatusDesc,
                //    s.ProductId,
                //    s.DispatchStorageId,
                //    s.CompanyId,
                //    s.Id,
                //    s.OrderId,
                //    s.OrderQuantity,
                //    s.ReceivedQuantity,
                //    s.ContainerCount,
                //    s.ContainerId,
                //    s.ContainerWeight,
                //    s.Updated,
                //    s.BarcodeId,
                //    BillId = 0,
                //    s.CreatedDate
                //}).ToList();
                var orderProd = from s in db.OrderItems
                                join oid in db.OrderItemDetails on s.Id equals oid.OrderItemId
                                join o in db.Orders on s.OrderId equals o.Id
                                where s.OrderId == orderId
                                select new
                                {
                                    oid.BatchId,
                                    o.BillAmount,                          
                                    //stockQty = sb.Quantity,
                                    oid.StockBatchId,                                                                      
                                    s.Product.Name,
                                    maxqty = s.OrderQuantity,
                                    Orderitemdetail = oid.Id,
                                    s.Quantity,
                                    s.CancelledQuantity,
                                    s.Tax1,
                                    s.Tax2,
                                    s.Tax3,
                                    TaxAmount = s.OrderQuantity * s.Price * (s.Tax1 + s.Tax2) / 100,
                                    s.Amount,
                                    s.Price,
                                    s.StatusDesc,
                                    s.ProductId,
                                    s.DispatchStorageId,
                                    s.CompanyId,
                                    orderItemId =s.Id,
                                    s.OrderId,
                                    s.OrderQuantity,
                                    s.ReceivedQuantity,
                                    s.ContainerCount,
                                    s.ContainerId,
                                    s.ContainerWeight,
                                    s.Updated,
                                    s.BarcodeId,
                                    BillId = 0,
                                    s.CreatedDate
                                };

                var OrdItem = from b in db.OrderItemDetails
                              join c in db.OrderItems on b.OrderItemId equals c.Id
                              where (c.OrderId == orderId && (b.CompanyId == CompanyId))
                              select new
                              {
                                  
                                  c.OrderId,
                                  b.OrderItemId,
                                  b.OrderItemType,
                                  c.OrderQuantity,
                                  c.Price,
                                  c.Product.Name,
                                  c.ProductId,
                                  b.ActualProdId,
                                  b.CompanyId,
                                  b.ContatinerId,
                                  b.ContainerCount,
                                  b.DispatchStorageId,
                                  b.DispatchStorageName,
                                  b.TaxAmount,
                                  b.Quantity,
                                  b.Amount,
                                  b.UnitPrice,
                                  b.Tax1,
                                  b.Tax2,
                                  c.Tax3,
                                  c.Tax4,
                                  b.BatchId,
                                  b.Id,
                                  c.BarcodeId,
                                  c.ContainerWeight,
                                  c.Updated,
                                  b.OrderItemDetailId,
                                  b.OrderItemRefId,
                                  c.RefId,
                                  c.BillId
                              };

                var data = new
                {
                    order = order,
                    orderProd = orderProd,
                    OrderItem = OrdItem
                };
                return Json(data);

            }
            catch (Exception e)
            {
                var error = new { data = e.Message, msg = "Contact your service provider" };
                return Json(error);
            }

        }
        [HttpGet("getStockContainer")]
        public IActionResult getStockContainer(int CompanyId, int StoreId)
        {
            var stockContainer = db.StockContainer.Where(x => x.CompanyId == CompanyId && x.StoreId == StoreId).ToList();

            return Ok(stockContainer);
        }
        [HttpGet("orderitemsbyid")]
        public List<OrderItem> orderitemsbyid(int orderid)
        {
            List<OrderItem> items = db.OrderItems.Where(x => x.OrderId == orderid).Include(x => x.Order).ToList();

            return items;
        }


        [HttpPost("OrdDispatch")]
        public ActionResult OrdDispatch([FromBody] dynamic objData)
        {
            int result = 0;
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {
                    dynamic JsonObj = objData;
                    int userId = JsonObj.userId;
                    int companyId = JsonObj.companyId;  
                    int orderId = JsonObj.OrderId;
                    int? DispatchById = JsonObj.DispatchById;
                    int? OrdDetailId = JsonObj.OrderItemDetailId;
                    Bill bill = new Bill();
                    bill = objData.ToObject<Bill>();
                    bill.BillType = (int)BillTypeEnum.Internal;
                    bill.ReceiveStatus = (int)BillReceiveStatus.Open;
                    bill.DispatchById = DispatchById;
                    bill.DispatchedDate = DateTime.Now;
                    bill.CompanyId = companyId;
                    db.Bill.Add(bill);
                    if (bill.DispatchDateStr != null)
                        bill.DispatchedDate = FormatExt.GetDateTimeSave(bill.DispatchDateStr, bill.DispatchTime);
                    bill.BillDate = bill.DispatchedDate;
                    bill.CreatedDate = DateTime.Now;
                    bill.CreatedBy = bill.CreatedBy;
                    Order order1 = db.Orders.Find(orderId);
                    order1.BillAmount = JsonObj.BillAmount;
                    order1.Tax1= JsonObj.TaxAmount/2;
                    order1.Tax2= JsonObj.TaxAmount/2;
                    order1.Tax3= 0;
                    db.Entry(order1).State = EntityState.Modified;
                    db.SaveChanges();
                    //orderitemsbyid(orderId);
                    JArray items = objData.Items;
                    dynamic itemArray = items.ToList();     
                    
                    JArray ItemDetail = objData.ItemDetail;
                    dynamic ItemDetailArray = ItemDetail.ToList();                    

                    for (int i = 0; i < itemArray.Count; i++)
                    {
                        int productId = itemArray[i].ProductId;
                        int orderQuantity = itemArray[i].OrderQuantity;
                        double dispatchQty = itemArray[i].DispatchedQuantity;
                        string action = itemArray[i].Action;
                        string productname = itemArray[i].ProductName;
                        double price = itemArray[i].Price;
                        double tax1 = itemArray[i].Tax1;
                        double tax2 = itemArray[i].Tax2;
                        int? ordItemId = itemArray[i].OrderItemId;                   
                        double taxamount = dispatchQty * price * (tax1 + tax2) / 100;
                        double amount = dispatchQty * price;
                        double billAmt = amount + taxamount;
                        int? storageId = itemArray[i].StorageStoreId;
                        int? billId = bill.BillId;
                        int stockbatchid = ItemDetailArray[i].stockBatchId;
                        switch (action)
                        {
                            case "Add":
                                var jsonString =Newtonsoft.Json.JsonConvert.SerializeObject(objData);
                                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                                sqlCon.Open();
                                SqlCommand cmd = new SqlCommand("dbo.AddOrdItems", sqlCon);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@orderJson", jsonString));
                                cmd.Parameters.Add(new SqlParameter("@companyid", companyId));
                                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                                cmd.Parameters.Add(new SqlParameter("@ordItemId", ordItemId));
                                cmd.Parameters.Add(new SqlParameter("@billId", bill.BillId));
                                DataSet ds = new DataSet();
                                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                                sqlAdp.Fill(ds);                                
                                break;
                            case "Chk":
                                var jsonString1 = Newtonsoft.Json.JsonConvert.SerializeObject(objData);
                                SqlConnection sqlCon1 = new SqlConnection(Configuration.GetConnectionString("myconn"));
                                sqlCon1.Open();
                                SqlCommand comd = new SqlCommand("dbo.UpdateInternal", sqlCon1);
                                comd.CommandType = CommandType.StoredProcedure;
                                comd.Parameters.Add(new SqlParameter("@orderData", jsonString1));
                                comd.Parameters.Add(new SqlParameter("@companyid", companyId));
                                comd.Parameters.Add(new SqlParameter("@orderId", orderId));
                                comd.Parameters.Add(new SqlParameter("@ordItemId", ordItemId));
                                comd.Parameters.Add(new SqlParameter("@OrdDetailId", OrdDetailId));
                                comd.Parameters.Add(new SqlParameter("@BillId", bill.BillId));
                                DataSet ds1 = new DataSet();
                                SqlDataAdapter sqlAdp1 = new SqlDataAdapter(comd);
                                sqlAdp1.Fill(ds1);
                                //orderitemsbyid(orderId);
                                break;
                        }
                        StockBatch stockBatch = db.StockBatches.Find(stockbatchid);
                        stockBatch.Quantity = stockBatch.Quantity - orderQuantity;
                        db.Entry(stockBatch).State = EntityState.Modified;
                        db.SaveChanges();
                        //SqlConnection sqlCon2 = new SqlConnection(Configuration.GetConnectionString("myconn"));
                        //sqlCon2.Open();
                        //SqlCommand cmd2 = new SqlCommand("dbo.DispatchStockUpdate", sqlCon2);
                        //cmd2.Parameters.Add(new SqlParameter("@stockbatchid", stockbatchid));
                        //cmd2.Parameters.Add(new SqlParameter("@quantity", orderQuantity));
                        //DataSet ds2 = new DataSet();
                        //SqlDataAdapter sqlAdp2 = new SqlDataAdapter(cmd2);
                        //sqlAdp2.Fill(ds2);
                        //sqlCon2.Close();
                    }


                    Order order = db.Orders.Where(x => x.Id == orderId).FirstOrDefault();
                    JArray jsonArray = new JArray();
                    var Orderitemsitems = db.OrderItems.Where(x => x.OrderId == orderId).Include(x => x.Product).ToList();
                    foreach (OrderItem item in Orderitemsitems)
                    {
                        string jsn = JsonConvert.SerializeObject(item);
                        JObject itm = JObject.Parse(jsn);
                        itm["Order"] = null;
                        itm["Product"] = item.Product.Name;
                        jsonArray.Add(itm);
                    }

                    order.ItemJson = JsonConvert.SerializeObject(jsonArray);
                    order.DispatchStatus = 2;
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();

                    //}
                    scope.Complete();
                    var response = new
                    {
                        status = 200,
                        billId = bill.BillId,
                        data = "Dispatched Successfully"
                    };
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    var response = new
                    {
                        status = 0,
                        msg = "Something went wrong",
                        error = new Exception(ex.Message, ex.InnerException)
                    };

                    return Ok(response);
                }
            }
        }


        [HttpPost("Dispatch")]
        public ActionResult Dispatch([FromBody] dynamic objData)
        {
            int result = 0;
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {
                    int userId = objData.userId;
                    int companyId = objData.companyId;

                    Bill bill = new Bill();
                    bill = objData.ToObject<Bill>();
                    bill.BillType = (int)BillTypeEnum.Internal;
                    bill.ReceiveStatus = (int)BillReceiveStatus.Open;
                    bill.CompanyId = companyId;
                    db.Bill.Add(bill);

                    //if (bill.DispatchType == null)
                    //    bill.DispatchType = (int)SuperMarketApi.Models.Enum.DispatchTypeEnum.Normal_Dispatch;
                    if (bill.DispatchDateStr != null)
                        bill.DispatchedDate = FormatExt.GetDateTimeSave(bill.DispatchDateStr, bill.DispatchTime);
                    bill.BillDate = bill.DispatchedDate;
                    bill.CreatedDate = DateTime.Now;
                    bill.CreatedBy = bill.CreatedBy;
                    db.SaveChanges();
                    OrderItem orderItem = null;
                    JArray items = objData.items;
                    dynamic itemArray = items.ToList();

                    for (int i = 0; i < itemArray.Count; i++)
                    {

                        int productId = itemArray[i].ProductId;
                        int? containerId = itemArray[i].containerId;
                        double? containerCount = itemArray[i].containerCount;
                        int dispatchProductId = itemArray[i].DispatchProductId;
                        double openQty = itemArray[i].OpenQty;
                        double dispatchQty = itemArray[i].DispatchQty;
                        int? batchNum = itemArray[i].BatchNum;
                        string action = itemArray[i].Action;
                        double? grossQty = itemArray[i].GrossQty;
                        double price = itemArray[i].Price;
                        double tax1 = itemArray[i].Tax1;
                        double tax2 = itemArray[i].Tax2;
                        int? orderItemId = itemArray[i].OrderItemId;
                        int orderId = itemArray[i].OrderId;
                        int? storageId = itemArray[i].StorageStoreId;

                        double taxamount = dispatchQty * price * (tax1 + tax2) / 100;
                        double amount = dispatchQty * price;
                        double billAmt = amount + taxamount;

                        var batch = db.Batches.Where(b => b.BatchNo == batchNum && b.CompanyId == companyId).FirstOrDefault();

                        if (storageId == null)
                            storageId = bill.StoreId;

                        orderItem = db.OrderItems.Find(orderItemId);

                        if (action == "Chk" || action == "AddBatch")
                        {
                            var dispatchProd = db.Products.Where(p => p.Id == dispatchProductId && p.CompanyId == companyId).FirstOrDefault();
                            double orderProdQty = 0;
                            //if (orderProd.Product.IsBasic)
                            //    orderProdQty = orderProd.Product.Factor * dispatchProd.Factor * dispatchQty;
                            //else
                            //    orderProdQty = dispatchProd.Factor * dispatchQty / orderItem.Product.Factor;

                            if (orderItem.DispatchedQuantity == null)
                                orderItem.DispatchedQuantity = orderProdQty;       //dispatchQty;
                            else
                                orderItem.DispatchedQuantity += orderProdQty; // dispatchQty;

                            if (orderItem.DispatchedQuantity >= orderItem.OrderQuantity)
                                orderItem.Status = (int)OrderProductStatus.Dispatched;
                            else
                                orderItem.Status = (int)OrderProductStatus.Partial;

                            db.Entry(orderItem).State = EntityState.Modified;

                            OrderItemDetail ordItemDetail = new OrderItemDetail();
                            ordItemDetail = objData.ToObject<OrderItemDetail>();

                            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                            sqlCon.Open();
                            SqlCommand cmd = new SqlCommand("dbo.UpdateStockNSubStore", sqlCon);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@storeId", ordItemDetail.StorageStoreId));
                            cmd.Parameters.Add(new SqlParameter("@productId", ordItemDetail.ActualProdId));
                            cmd.Parameters.Add(new SqlParameter("@quantity", dispatchQty));
                            cmd.Parameters.Add(new SqlParameter("@batchId", ordItemDetail.BatchId));
                            cmd.Parameters.Add(new SqlParameter("@billId", bill.BillId));
                            cmd.Parameters.Add(new SqlParameter("@dispDate", bill.DispatchedDate));
                            cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                            //if (bill.DispatchType == (int)DispatchTypeEnum.Normal_Dispatch)
                            //    cmd.Parameters.Add(new SqlParameter("@parentType", (int)ParentType.Dispatch));
                            //else if (bill.DispatchType == (int)DispatchTypeEnum.Wastage_Dispatch)
                            //    cmd.Parameters.Add(new SqlParameter("@parentType", (int)ParentType.Wastage));
                            //else if (bill.DispatchType == (int)DispatchTypeEnum.Return_Dispatch)
                            //    cmd.Parameters.Add(new SqlParameter("@parentType", (int)ParentType.Return));
                            //cmd.Connection.Open();
                            //cmd.ExecuteNonQuery();
                            if (bill.DispatchType == 3)
                            {
                                WastageQtyAlert(companyId, ordItemDetail.OrderItemDetailId, orderItem.ProductId, ordItemDetail.StorageStoreId, "ADD");
                            }
                            //OrdersControllerExt.RemoveStock(db, (int)ordItemDetail.ActualProdId, (int)ordItemDetail.StorageStoreId, dispatchQty);
                        }
                        else if (action == "Add")
                        {

                            orderItem = new OrderItem();
                            orderItem = objData.ToObject<OrderItem>();
                            orderItem.CompanyId = objData.companyId;
                            orderItem.ProductId = productId;
                            orderItem.OrderQuantity = dispatchQty;
                            orderItem.Price = price;
                            orderItem.Tax1 = tax1;
                            orderItem.Tax2 = tax2;
                            db.OrderItems.Add(orderItem);
                            db.SaveChanges();
                            OrderItemDetail ordItemDetail = new OrderItemDetail();
                            ordItemDetail = objData.ToObject<OrderItemDetail>();
                            ordItemDetail.OrderItemId = orderItem.Id;
                            ordItemDetail.CompanyId = objData.companyId;
                            ordItemDetail.ActualProdId = productId;
                            ordItemDetail.Quantity = dispatchQty;
                            ordItemDetail.GrossQuantity = dispatchQty;
                            ordItemDetail.UnitPrice = price;
                            ordItemDetail.Tax1 = tax1;
                            ordItemDetail.Tax2 = tax2;
                            ordItemDetail.StorageStoreId = storageId;
                            ordItemDetail.BillId = bill.BillId;
                            ordItemDetail.OrderItemType = 2;
                            ordItemDetail.ContatinerId = containerId;
                            ordItemDetail.CreatedBy = bill.CreatedBy;
                            // ordItemDetail ordItemDetail = new ordItemDetail(orderProd.OrderProductId, bill.BillId, (int)OrderProductType.Dispatch, dispatchQty, 0, 0, 0, 0, (DateTime)bill.DispatchedDate);

                            db.OrderItemDetails.Add(ordItemDetail);
                            db.SaveChanges();

                            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                            sqlCon.Open();
                            SqlCommand cmd = new SqlCommand("dbo.UpdateStockNSubStore", sqlCon);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@storeId", ordItemDetail.StorageStoreId));
                            cmd.Parameters.Add(new SqlParameter("@productId", ordItemDetail.ActualProdId));
                            cmd.Parameters.Add(new SqlParameter("@quantity", dispatchQty));
                            cmd.Parameters.Add(new SqlParameter("@batchId", ordItemDetail.BatchId));
                            cmd.Parameters.Add(new SqlParameter("@billId", bill.BillId));
                            cmd.Parameters.Add(new SqlParameter("@dispDate", bill.DispatchedDate));
                            cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                            //if (bill.DispatchType == (int)DispatchTypeEnum.Normal_Dispatch)
                            //    cmd.Parameters.Add(new SqlParameter("@parentType", (int)ParentType.Dispatch));
                            //else if (bill.DispatchType == (int)DispatchTypeEnum.Wastage_Dispatch)
                            //    cmd.Parameters.Add(new SqlParameter("@parentType", (int)ParentType.Wastage));
                            //else if (bill.DispatchType == (int)DispatchTypeEnum.Return_Dispatch)
                            //    cmd.Parameters.Add(new SqlParameter("@parentType", (int)ParentType.Return));
                            //cmd.Connection.Open();
                            //cmd.ExecuteNonQuery();

                            if (bill.DispatchType == 3)
                            {
                                WastageQtyAlert(companyId, ordItemDetail.OrderItemDetailId, orderItem.ProductId, ordItemDetail.StorageStoreId, "ADD");
                            }
                            //OrdersControllerExt.RemoveStock(db, (int)ordItemDetail.ActualProdId, (int)ordItemDetail.StorageStoreId, dispatchQty);

                        }

                        //    if (orderProd.OrderId != null)
                        //        OrdersControllerExt.DispatchComplete(db, (int)orderProd.OrderId, (int)OrderType.Internal);
                    }
                    //bill.ReceiveStatus = (int)BillReceiveStatus.Open;

                    db.SaveChanges();
                    scope.Complete();
                    var response = new
                    {
                        status = 200,
                        billId = bill.BillId,
                        data = "Dispatched Successfully"
                    };
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    var response = new
                    {
                        status = 0,
                        msg = "Something went wrong",
                        error = new Exception(ex.Message, ex.InnerException)
                    };
                    return Ok(response);
                }
            }

        }
        [HttpPost("ReceiveDispatch")]
        public ActionResult ReceiveDispatch([FromBody] dynamic objData)

        {
            try
            {
                int companyId = objData[0].companyId;
                int billId = objData[0].billId;
                var bill = db.Bill.Where(s => s.BillId == billId).Select(b => new
                {
                    BillId = b.BillId,
                    b.ProviderId,
                    Provider = b.Provider.Name,
                    b.ReceiverId,
                    Receiver = b.Receiver.Name,
                    b.DispatchedDate,
                    b.BillAmount,
                    b.BillAmountNoTax,
                    b.TaxAmount,
                    b.BillDate,
                    b.DispatchType,
                    //b.OrderId,
                    b.DispatchById

                }).FirstOrDefault();
                var ordItemDetails = db.OrderItemDetails.Where(op => op.BillId == billId && op.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Dispatch && op.CompanyId == companyId).Include(o => o.OrderItem).ToList();
                var storageStrList = new List<StorageStrList>();
                var receiveProductList = new List<ReceiveProductList>();
                dynamic orderProductDetList = null;
                foreach (OrderItemDetail ordItemDetail in ordItemDetails)
                {

                    var receiveProducts = db.Products.Where(p => (p.Id == ordItemDetail.ActualProdId && p.CompanyId == companyId)
                                                  ).Select(p => new { p.Id, p.Description });

                    foreach (var receiveProduct in receiveProducts)
                    {
                        ReceiveProductList product = new ReceiveProductList();
                        product.ReceiveProductId = receiveProduct.Id;
                        product.ReceiveProduct = receiveProduct.Description;
                        //product.StockQuantity = quantity;
                        product.OrderProductId = ordItemDetail.OrderItemId;
                        receiveProductList.Add(product);
                    }
                    var receiver = db.Stocks.Where(s => s.ProductId == ordItemDetail.ActualProdId && s.StorageStoreId != null && s.CompanyId == companyId).FirstOrDefault();
                    if (receiver != null)
                    {
                        //ordItemDetail.ReceiveStorageName = receiver.StorageStore.Name;
                        ordItemDetail.ReceiveStorageId = receiver.StorageStoreId;
                    }
                    var storageStrs = db.Stores.Where(s => (s.Id == bill.ReceiverId || s.ParentStoreId == bill.ReceiverId && s.ParentStoreId != null) && s.CompanyId == companyId).ToList();
                    foreach (var storageStr in storageStrs)
                    {
                        StorageStrList store = new StorageStrList();
                        store.StoreId = storageStr.Id;
                        if (ordItemDetail.ReceiveStorageId == storageStr.Id)
                            store.IsSelected = true;
                        else store.IsSelected = false;
                        store.StoreName = storageStr.Name;
                        store.OrderProductId = ordItemDetail.OrderItemId;
                        storageStrList.Add(store);
                    }

                    if (ordItemDetail.ContatinerId != null)
                        ordItemDetail.GrossQuantity = ordItemDetail.Quantity;
                }

                orderProductDetList = ordItemDetails.Select(op => new
                {
                    op.ActualProdId,
                    op.CompanyId,
                    op.ContatinerId,
                    op.ContainerCount,
                    op.DispatchStorageId,
                    op.DispatchStorageName,
                    op.TaxAmount,
                    op.OrderItemId,
                    op.Quantity,
                    op.Amount,
                    op.UnitPrice,
                    op.Tax1,
                    op.Tax2,
                    op.Id,
                    op.BillId,


                });
                var OrdItem = from b in db.OrderItemDetails
                              join c in db.OrderItems on b.OrderItemId equals c.Id
                              where (b.BillId == bill.BillId &&
  (b.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Dispatch && b.CompanyId == companyId))
                              orderby b.BillId descending
                              select new
                              {
                                  c.OrderId,
                                  b.OrderItemId,
                                  b.OrderItemType,
                                  c.OrderQuantity,
                                  c.Price,
                                  c.Product.Description,
                                  c.ProductId,
                                  b.ActualProdId,
                                  b.CompanyId,
                                  b.ContatinerId,
                                  b.ContainerCount,
                                  b.DispatchStorageId,
                                  b.DispatchStorageName,
                                  b.TaxAmount,
                                  b.Quantity,
                                  b.Amount,
                                  b.UnitPrice,
                                  b.Tax1,
                                  b.Tax2,
                                  c.Tax3,
                                  c.Tax4,
                                  b.BatchId,
                                  b.Id,
                                  c.BarcodeId,
                                  c.ContainerWeight,
                                  c.Updated,
                                  b.OrderItemDetailId,
                                  b.OrderItemRefId,
                                  c.RefId,
                                  c.BillId
                              };

                var data = new
                {
                    bill = bill,
                    receiveProductList = receiveProductList,
                    orderProductDetList = orderProductDetList,
                    storageStrList = storageStrList,
                    OrdItem = OrdItem

                };
                return Json(data);
            }
            catch (Exception e)
            {
                var error = new { data = e.Message, msg = "Contact your service provider" };
                return Json(error);
            }
        }
        [HttpPost("OrdUpdate")]
        public IActionResult OrdUpdate([FromBody] dynamic objData)
        {
            int result = 0;
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {
                   
                    JArray items = objData.Items;
                    dynamic itemArray = items.ToList();
                    int orderId = itemArray[0].OrderId;

                    for (int i = 0; i < itemArray.Count; i++)
                    {

                        int productId = itemArray[i].ProductId;                     
                        int orderQuantity = itemArray[i].OrderQuantity;
                        double dispatchQty = itemArray[i].DispatchQty;
                        string action = itemArray[i].Action;
                        string productname = itemArray[i].ProductName;
                        double price = itemArray[i].Price;
                        double tax1 = itemArray[i].Tax1;
                        double tax2 = itemArray[i].Tax2;
                        int? ordItemId = itemArray[i].OrderItemId;
                        int? OrdDetailId = itemArray[i].OrdDetailId;
                        int? companyId = objData.CompanyId;
                        double taxamount = dispatchQty * price * (tax1 + tax2) / 100;
                        double amount = dispatchQty * price;
                        double billAmt = amount + taxamount;
                        switch (action)
                        {
                            case "Add":
                                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(objData);
                                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                                sqlCon.Open();
                                SqlCommand cmd = new SqlCommand("dbo.AddOrdItems", sqlCon);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@orderJson", jsonString));
                                cmd.Parameters.Add(new SqlParameter("@companyid", companyId));
                                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                                cmd.Parameters.Add(new SqlParameter("@ordItemId", ordItemId));
                                cmd.Parameters.Add(new SqlParameter("@billId", null));
                                DataSet ds = new DataSet();
                                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                                sqlAdp.Fill(ds);
                                break;
                            case "Chk":
                                var jsonString1 = Newtonsoft.Json.JsonConvert.SerializeObject(objData);
                                SqlConnection sqlCon1 = new SqlConnection(Configuration.GetConnectionString("myconn"));
                                sqlCon1.Open();
                                SqlCommand comd = new SqlCommand("dbo.UpdateInternal", sqlCon1);
                                comd.CommandType = CommandType.StoredProcedure;
                                comd.Parameters.Add(new SqlParameter("@orderData", jsonString1));
                                comd.Parameters.Add(new SqlParameter("@companyid", companyId));
                                comd.Parameters.Add(new SqlParameter("@orderId", orderId));
                                comd.Parameters.Add(new SqlParameter("@ordItemId", ordItemId));
                                comd.Parameters.Add(new SqlParameter("@OrdDetailId", OrdDetailId));
                                DataSet ds1 = new DataSet();
                                SqlDataAdapter sqlAdp1 = new SqlDataAdapter(comd);
                                sqlAdp1.Fill(ds1);
                                break;

                        }
                    }
                    Order order = db.Orders.Where(x => x.Id == orderId).FirstOrDefault();
                    List<OrderItem> _items = db.OrderItems.Where(x => x.OrderId == orderId).Include(i => i.Product).ToList();
                    JArray jsonArray = new JArray();

                    foreach (OrderItem item in _items)
                    {
                        string jsn = JsonConvert.SerializeObject(item);
                        JObject itm = JObject.Parse(jsn);
                        itm["Order"] = null;
                        itm["Product"] = item.Product.Name;
                        jsonArray.Add(itm);
                    }
                    order.ItemJson = JsonConvert.SerializeObject(jsonArray);
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();     
                    scope.Complete();
                    var response = new
                    {
                        status = 200,
                        msg = "data Updated Successfully"
                    };
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    var response = new
                    {
                        status = 0,
                        msg = "Something went wrong",
                        error = new Exception(ex.Message, ex.InnerException)
                    };
                    return Ok(response);
                }
            }
        }

        [HttpPost("OrdReceive")]
        public IActionResult OrdReceive([FromBody] int orderId)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.receiveordersave", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));            
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    status = 200,
                    data = "Received Successfully"
                    //lastorderno = lastorderno
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

        //[HttpPost("OrdReceive")]
        //public IActionResult OrdReceive([FromBody] dynamic objData)
        //{
        //    using (var scope = SQLExt.CreateTransScope())
        //    {
        //        try
        //        {
        //            dynamic jsonObj = objData;
        //            int billId = jsonObj.billId;
        //            int companyId = jsonObj.compId;
        //            int receivedById = jsonObj.receivedById;
        //            DateTime receiveDate = DateTime.Now;
        //            DateTime receiveTime = DateTime.Now;
        //            float billAmountNoTax = jsonObj.billAmountNoTax;
        //            float taxAmount = jsonObj.taxAmount;
        //            float billAmount = jsonObj.billAmount;
        //            JArray items = jsonObj.Items;
        //            dynamic itemArray = items.ToList();
        //            int? orderId = jsonObj.OrderId;
        //            Bill bill = db.Bill.Find(billId);
        //            bill.BillType = (int)BillTypeEnum.Internal;
        //            bill.CompanyId = companyId;
        //            bill.ReceivedDate = DateTime.Now;
        //            bill.BillAmountNoTax = billAmountNoTax;
        //            bill.TaxAmount = taxAmount;
        //            bill.BillAmount = billAmount;
        //            bill.ReceivedById = receivedById;
        //            bill.ReceiveStatus = 3;
        //            db.SaveChanges();
        //            SqlConnection conString = new SqlConnection(Configuration.GetConnectionString("myconn"));
        //            bool isClose = true;
        //            for (int i = 0; i < itemArray.Count; i++)
        //            {
        //                string action = itemArray[i].Action;
        //                int ordItemId = itemArray[i].OrderItemId;
        //                int productId = itemArray[i].ProductId;
        //                double dispatchQty = itemArray[i].DispatchQty;
        //                int? batchNum = itemArray[i].BatchNum;
        //                int? storageId = itemArray[i].StorageStoreId;
        //                int? OrdDetailId = jsonObj.OrderItemDetailId;
                   
                     
        //            }
        //            //}
        //            scope.Complete();
        //            var response = new
        //            {
        //                status = 200,
        //                bill = billId,
        //                data = "Received Successfully"
        //            };
        //            return Ok(response);
        //        }
        //        catch (Exception ex)
        //        {
        //            var response = new
        //            {
        //                status = 0,
        //                msg = "Something went wrong",
        //                error = new Exception(ex.Message, ex.InnerException)
        //            };
        //            return Ok(response);
        //        }
        //    }
        //}

        [Route("Receive")]
        [HttpPost]
        public IActionResult Receive([FromBody] dynamic objData)
        {
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {
                    dynamic jsonObj = objData;
                    int billId = jsonObj.billId;
                    int companyId = jsonObj.compId;
                    int receivedById = jsonObj.receivedById;
                    DateTime receiveDate = DateTime.Now;
                    DateTime receiveTime = DateTime.Now;
                    float billAmountNoTax = jsonObj.billAmountNoTax;
                    float taxAmount = jsonObj.taxAmount;
                    float billAmount = jsonObj.billAmount;
                    //DateTime receiveDateTime = FbBatterController.GetDateTimeSave(receiveDate, receiveTime);
                    JArray items = jsonObj.items;
                    dynamic itemArray = items.ToList();

                    Bill bill = db.Bill.FirstOrDefault();
                    bill.BillType = (int)BillTypeEnum.Internal;
                    //bill.ReceiveStatus = (int)BillReceiveStatus.Open;
                    bill.CompanyId = companyId;
                    bill.ReceivedDate = DateTime.Now;
                    bill.BillAmountNoTax = billAmountNoTax;
                    bill.TaxAmount = taxAmount;
                    bill.BillAmount = billAmount;
                    bill.ReceivedById = receivedById;
                    SqlConnection conString = new SqlConnection(Configuration.GetConnectionString("myconn"));
                    bool isClose = true;
                    //Bill bill = null;
                    for (int i = 0; i < itemArray.Count; i++)
                    {
                        int prodId = itemArray[i].ProductId;
                        string action = itemArray[i].Action;
                        double qty = itemArray[i].Quantity;
                        double? tax1 = itemArray[i].Tax1;
                        double? tax2 = itemArray[i].Tax2;
                        double? tax3 = itemArray[i].Tax3;
                        double? price = itemArray[i].Price;
                        int orderProdId = itemArray[i].OrderItemId;
                        int? ordItemDetailId = itemArray[i].OrdItemDetailId;
                        int? storageStoreId = itemArray[i].StorageStoreId;

                        if (tax1 == null) tax1 = 0;
                        if (tax2 == null) tax3 = 0;
                        if (tax3 == null) tax2 = 0;
                        if (price == null) price = 0;
                        double? taxamount = qty * price * (tax1 + tax2 + tax3) / 100;
                        double? amount = qty * price;
                        double? billAmt = amount + taxamount;


                        //if (storageStoreId == null)
                        //    storageStoreId = bill.ReceiverId;
                        OrderItem orderProd;
                        if (action == "Chk" || action == "AddBatch")
                        {
                            orderProd = db.OrderItems.Find(orderProdId);

                            var receiveProd = db.Products.Where(p => p.Id == prodId && p.CompanyId == companyId).FirstOrDefault();
                            double orderProdQty = 0;
                            //if (orderProd.Product.IsBasic)
                            //    orderProdQty = orderProd.Product.Factor * receiveProd.Factor * qty;
                            //else
                            //    orderProdQty = receiveProd.Factor * qty / orderProd.Product.Factor;

                            //if (orderProd.ReceivedQuantity == null)
                            //    orderProd.ReceivedQuantity = orderProdQty;
                            //else
                            //    orderProd.ReceivedQuantity += orderProdQty;

                            //if (orderProd.OpenQuantity <= 0 && orderProd.ReceivedQuantity >= orderProd.DispatchedQuantity)
                            //    orderProd.Status = (int)OrderProductStatus.Closed;
                            //else
                            //    orderProd.Status = (int)OrderProductStatus.Partial;

                            orderProd.Price = price;
                            orderProd.Tax1 = tax1;
                            orderProd.Tax2 = tax2;
                            orderProd.BillId = billId;
                            db.Entry(orderProd).State = EntityState.Modified;
                            db.SaveChanges();
                            OrderItemDetail ordItemDetail = new OrderItemDetail(orderProdId, bill.BillId, (int)Models.Enum.OrderItemType.Receive, qty, 0, 0, 0, 0, (DateTime)bill.ReceivedDate,
                                db);
                            ordItemDetail.ActualProdId = prodId;
                            //if (batch != null)
                            //    ordItemDetail.BatchId = batch.BatchId;
                            ordItemDetail.StorageStoreId = (int)storageStoreId;
                            ordItemDetail.OrderItemType = (int)Models.Enum.OrderItemType.Receive;
                            ordItemDetail.Amount = amount;
                            ordItemDetail.Tax1 = tax1;
                            ordItemDetail.Tax2 = tax2;
                            ordItemDetail.UnitPrice = price;
                            ordItemDetail.TaxAmount = taxamount;
                            ordItemDetail.OrderItemId = orderProdId;
                            ordItemDetail.CompanyId = companyId;
                            db.OrderItemDetails.Add(ordItemDetail);
                            db.SaveChanges();
                            //SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                            //sqlCon.Open();
                            //SqlCommand cmd = new SqlCommand("dbo.UpdateStock", sqlCon);
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.Add(new SqlParameter("@storeId", ordItemDetail.StorageStoreId));
                            //cmd.Parameters.Add(new SqlParameter("@productId", ordItemDetail.ActualProdId));
                            //cmd.Parameters.Add(new SqlParameter("@quantity", ordItemDetail.Quantity));
                            //cmd.Parameters.Add(new SqlParameter("@batchId", ordItemDetail.BatchId));
                            //cmd.Parameters.Add(new SqlParameter("@dateTime", bill.ReceivedDate));
                            //cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                            //cmd.Connection.Open();
                            //cmd.ExecuteNonQuery();
                            //cmd.Connection.Close();
                            //OrdersControllerExt.AddStock(db, (int)ordItemDetail.ActualProdId, (int)ordItemDetail.StorageStoreId, receiveQty);

                            //if (ordItemDetail.Quantity < (CalcDispatchQty(db, billId, orderProdId) - CalcReturnQty(db, bill, orderProdId)))
                            //    isClose = false;

                        }
                        else if (action == "Add")
                        {
                            orderProd = new OrderItem(
                                    null, prodId, null, price, tax1, tax2, 0, 0, 0, companyId);
                            orderProd.ReceivedQuantity = qty;
                            //if ((orderProd.OpenQuantity <= 0 && orderProd.ReceivedQuantity >= orderProd.DispatchedQuantity) || (orderProd.DispatchedQuantity == null && orderProd.ReceivedQuantity > 0))
                            //    orderProd.Status = (int)OrderProductStatus.Closed;
                            //else
                            //    orderProd.Status = (int)OrderProductStatus.Partial;
                            orderProd.CompanyId = companyId;
                            orderProd.BillId = billId;
                            db.OrderItems.Add(orderProd);
                            db.SaveChanges();

                            OrderItemDetail ordProdDetail = new OrderItemDetail(orderProd.Id, bill.BillId, (int)Models.Enum.OrderItemType.Receive, qty, 0, 0, 0, 0, (DateTime)bill.ReceivedDate, db);
                            ordProdDetail.ActualProdId = prodId;
                            ordProdDetail.StorageStoreId = (int)storageStoreId;
                            ordProdDetail.OrderItemType = (int)Models.Enum.OrderItemType.Receive;
                            //ordProdDetail.StorageStoreId = orderProd.DispatchStorageId;
                            ordProdDetail.Amount = amount;
                            ordProdDetail.Tax1 = tax1;
                            ordProdDetail.Tax2 = tax2;
                            ordProdDetail.UnitPrice = price;
                            ordProdDetail.TaxAmount = taxamount;
                            ordProdDetail.OrderItemId = orderProd.Id;
                            ordProdDetail.CompanyId = companyId;
                            db.OrderItemDetails.Add(ordProdDetail);
                            db.SaveChanges();


                            //orderProd = new OrderItem();
                            //orderProd.ReceivedQuantity = qty;
                            //if ((orderProd.OpenQuantity <= 0 && orderProd.ReceivedQuantity >= orderProd.DispatchedQuantity) || (orderProd.DispatchedQuantity == null && orderProd.ReceivedQuantity > 0))
                            //    orderProd.Status = (int)OrderProductStatus.Closed;
                            //else
                            //    orderProd.Status = (int)OrderProductStatus.Partial;
                            //orderProd.CompanyId = companyId;
                            //orderProd.Price = price;
                            //orderProd.Tax1 = tax1;
                            //orderProd.Tax2 = tax2;
                            //orderProd.OrderQuantity = qty;
                            //orderProd.Price = price;
                            //db.OrderItems.Add(orderProd);
                            //db.SaveChanges();
                            //orderProd = new OrderItem();
                            //orderProd.OrderId = 8858;
                            //orderProd.CompanyId = companyId;
                            //orderProd.ProductId = prodId;
                            //orderProd.OrderQuantity = qty;
                            //orderProd.Price = price;
                            //orderProd.Tax1 = tax1;
                            //orderProd.Tax2 = tax2;
                            //orderProd.Tax3 = tax2;
                            //orderProd.BillId = billId;
                            //orderProd = objData.ToObject<OrderItem>();
                            //orderProd.ContainerCount = containerCount;
                            //orderProd.ContainerId = containerId;
                            //orderProd.ContainerWeight = containerCount;
                            //db.OrderItems.Add(orderProd);
                            //db.SaveChanges();

                            //OrderItemDetail ordItemDetail = new OrderItemDetail(orderProd.Id, bill.BillId, (int)Models.Enum.OrderItemType.Receive, qty, 0, 0, 0, 0, (DateTime)bill.ReceivedDate,db);
                            //ordItemDetail.ActualProdId = prodId;
                            //ordItemDetail.StorageStoreId = (int)storageStoreId;
                            //ordItemDetail.Amount = amount;
                            //ordItemDetail.Tax1 = tax1;
                            //ordItemDetail.Tax2 = tax2;
                            //ordItemDetail.UnitPrice = price;
                            //ordItemDetail.TaxAmount = taxamount;
                            //ordItemDetail.CompanyId = companyId;
                            //db.OrderItemDetails.Add(ordItemDetail);
                            //db.SaveChanges();

                            //SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                            //sqlCon.Open();
                            //SqlCommand cmd = new SqlCommand("dbo.UpdateStock", sqlCon);
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.Add(new SqlParameter("@storeId", ordItemDetail.StorageStoreId));
                            //cmd.Parameters.Add(new SqlParameter("@productId", ordItemDetail.ActualProdId));
                            //cmd.Parameters.Add(new SqlParameter("@quantity", ordItemDetail.Quantity));
                            //cmd.Parameters.Add(new SqlParameter("@batchId", ordItemDetail.BatchId));
                            //cmd.Parameters.Add(new SqlParameter("@dateTime", bill.ReceivedDate));
                            //cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                            //cmd.Connection.Open();
                            //cmd.ExecuteNonQuery();
                            //cmd.Connection.Close();
                            //OrdersControllerExt.AddStock(db, (int)ordItemDetail.ActualProdId, (int)ordItemDetail.StorageStoreId, receiveQty);

                        }
                        //orderProd = db.OrderItems.Find(orderProdId);

                        //orderProd.ReceivedQuantity = 0;
                        //db.Entry(orderProd).State = EntityState.Modified;

                        //OrderItemDetail ordItemDetail = new OrderItemDetail(orderProd.OrderItemId, bill.BillId, (int)Models.Enum.OrderItemType.Receive, 0, 0, 0, 0, 0, (DateTime)bill.ReceivedDate,db);
                        //ordItemDetail.ActualProdId = prodId;
                        //ordItemDetail.StorageStoreId = (int)storageStoreId;
                        //ordItemDetail.CompanyId = companyId;
                        //db.OrderItemDetails.Add(ordItemDetail);

                        //OrdersControllerExt.AddStock(db, orderProd.ProductId, bill.ReceiverId, 0);

                        //if (ordItemDetail.Quantity < (CalcDispatchQty(db, billId, orderProdId) - CalcReturnQty(db, bill, orderProdId)))
                        //    isClose = false;
                    }
                    //    if (orderProd.OrderId != null)
                    //        OrderComplete(db, (int)orderProd.OrderId, (int)OrderType.Internal, companyId);
                    //}
                    //if (isClose)
                    //    bill.ReceiveStatus = (int)BillReceiveStatus.Closed;
                    //else
                    //    bill.ReceiveStatus = (int)BillReceiveStatus.Partial;
                    bill.ReceiveStatus = (int)BillReceiveStatus.Closed;

                    db.Entry(bill).State = EntityState.Modified;
                    db.SaveChanges();
                    scope.Complete();
                    var error = new { data = "", msg = "Data Received Successfully" };
                    return Json(error);
                }
                catch (Exception e)
                {
                    var error = new Exception(e.Message, e.InnerException);
                    return Json(error);
                }

            }
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] dynamic objData)
        {
            int result = 0;
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {
                    int companyId = objData.companyId;
                    OrderItem orderItem = null;
                    Order order = null;
                    JArray items = objData.items;
                    dynamic itemArray = items.ToList();

                    for (int i = 0; i < itemArray.Count; i++)
                    {

                        int productId = itemArray[i].ProductId;
                        int? containerId = itemArray[i].ContainerId;
                        double? containerCount = itemArray[i].ContainerCount;
                        int dispatchProductId = itemArray[i].DispatchProductId;
                        double openQty = itemArray[i].OpenQty;
                        double dispatchQty = itemArray[i].DispatchQty;
                        int? batchNum = itemArray[i].BatchNum;
                        string action = itemArray[i].Action;
                        double? grossQty = itemArray[i].GrossQty;
                        double price = itemArray[i].Price;
                        double tax1 = itemArray[i].Tax1;
                        double tax2 = itemArray[i].Tax2;
                        int? orderItemId = itemArray[i].OrderItemId;
                        int orderId = itemArray[i].OrderId;
                        int? storageId = itemArray[i].StorageStoreId;

                        double taxamount = dispatchQty * price * (tax1 + tax2) / 100;
                        double amount = dispatchQty * price;
                        double billAmt = amount + taxamount;
                        orderItem = db.OrderItems.Find(orderItemId);

                        if (action == "Chk" || action == "AddBatch")
                        {
                            db.Entry(orderItem).State = EntityState.Modified;
                            order = db.Orders.Find(orderId);
                            order.SuppliedById = objData.SuppliedById;
                            order.OrderedById = objData.OrderedById;
                            //order.WipStatus = objData.WipStatus;
                            db.Entry(orderItem).State = EntityState.Modified;
                        }
                        else if (action == "Add")
                        {

                            orderItem = new OrderItem();
                            orderItem = objData.ToObject<OrderItem>();
                            orderItem.CompanyId = objData.companyId;
                            orderItem.ProductId = productId;
                            orderItem.OrderQuantity = dispatchQty;
                            orderItem.Price = price;
                            orderItem.Tax1 = tax1;
                            orderItem.Tax2 = tax2;
                            db.OrderItems.Add(orderItem);
                            db.SaveChanges();
                        }
                    }
                    db.SaveChanges();
                    scope.Complete();
                    var response = new
                    {
                        status = 200,
                        msg = "data Updated Successfully"
                    };
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    var response = new
                    {
                        status = 0,
                        msg = "Something went wrong",
                        error = new Exception(ex.Message, ex.InnerException)
                    };
                    return Ok(response);
                }
            }
        }
        [HttpPost("EditReceive")]
        public IActionResult EditReceive([FromBody] dynamic objData)
        {
            try
            {
                int billId = objData[0].billId;
                int companyId = objData[0].compId;
                var bill = db.Bill.Where(s => s.BillId == billId).Select(b => new
                {
                    BillId = b.BillId,
                    b.ProviderId,
                    Provider = b.Provider.Name,
                    b.ReceiverId,
                    Receiver = b.Receiver.Name,
                    b.DispatchedDate,
                    b.BillAmount,
                    b.BillAmountNoTax,
                    b.TaxAmount,
                    b.BillDate,
                    b.DispatchType,
                    //b.OrderId,
                    b.ReceivedById,
                    b.CompanyId,
                    b.ReceivedBy,
                    b.ReceivedBy.Name,
                    b.ReceivedDate
                    //b.ordItemDetails
                }).FirstOrDefault();


                var ordItemDetails = db.OrderItemDetails.Where(op => op.BillId == bill.BillId && op.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Receive && op.CompanyId == companyId).ToList();
                var storageStrList = new List<StorageStrList>();
                var receiveProductList = new List<ReceiveProductList>();
                dynamic orderProductDetList = null;

                foreach (OrderItemDetail ordItemDetail in ordItemDetails)
                {

                    var receiveProducts = db.Products.Where(p => (p.Id == ordItemDetail.ActualProdId && p.CompanyId == companyId)
                                                 ).Select(p => new { p.Id, p.Description });

                    foreach (var receiveProduct in receiveProducts)
                    {
                        ReceiveProductList product = new ReceiveProductList();
                        product.ReceiveProductId = receiveProduct.Id;
                        product.ReceiveProduct = receiveProduct.Description;
                        product.OrderProductId = ordItemDetail.OrderItemId;
                        receiveProductList.Add(product);
                    }

                    if (ordItemDetail.StorageStore != null)
                    {
                        ordItemDetail.ReceiveStorageName = ordItemDetail.StorageStore.Name;
                        ordItemDetail.ReceiveStorageId = ordItemDetail.StorageStoreId;
                    }
                    var storageStrs = db.Stores.Where(s => (s.Id == bill.ReceiverId || s.ParentStoreId == bill.ReceiverId && s.ParentStoreId != null) && s.CompanyId == companyId).ToList();
                    foreach (var storageStr in storageStrs)
                    {
                        StorageStrList store = new StorageStrList();
                        store.StoreId = storageStr.Id;
                        if (ordItemDetail.ReceiveStorageId == storageStr.Id)
                            store.IsSelected = true;
                        else store.IsSelected = false;
                        store.StoreName = storageStr.Name;
                        store.OrderProductId = ordItemDetail.OrderItemId;
                        storageStrList.Add(store);
                    }
                }
                orderProductDetList = ordItemDetails.ToList();
                var OrdItem = from b in db.OrderItemDetails
                              join c in db.OrderItems on b.OrderItemId equals c.Id
                              where (b.BillId == bill.BillId &&
  (b.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Receive && b.CompanyId == companyId))
                              orderby b.BillId descending
                              select new
                              {
                                  c.OrderId,
                                  b.OrderItemId,
                                  b.OrderItemType,
                                  c.OrderQuantity,
                                  c.Price,
                                  c.Product.Description,
                                  c.ProductId,
                                  b.ActualProdId,
                                  b.CompanyId,
                                  b.ContatinerId,
                                  b.ContainerCount,
                                  b.DispatchStorageId,
                                  b.DispatchStorageName,
                                  b.TaxAmount,
                                  b.Quantity,
                                  b.Amount,
                                  b.UnitPrice,
                                  b.Tax1,
                                  b.Tax2,
                                  c.Tax3,
                                  c.Tax4,
                                  b.BatchId,
                                  b.Id,
                                  c.BarcodeId,
                                  c.ContainerWeight,
                                  c.Updated,
                                  b.OrderItemDetailId,
                                  b.OrderItemRefId,
                                  c.RefId,
                                  c.BillId
                              };

                var data = new
                {
                    bill = bill,
                    receiveProductList = receiveProductList,
                    orderProductDetList = orderProductDetList,
                    storageStrList = storageStrList,
                    OrderItem = OrdItem
                };
                return Json(data);

            }
            catch (Exception e)
            {
                var error = new { data = e.Message, msg = "Contact your service provider" };
                return Json(error);
            }
        }
        [HttpPost("UpdateReceiveOrd")]
        public IActionResult UpdateReceiveOrd([FromBody] dynamic objData)
        {
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {
                    dynamic jsonObj = objData;
                    int billId = jsonObj.billId;
                    int companyId = jsonObj.companyId;
                    int? receivedById = jsonObj.receivedById;
                    string receiveDate = jsonObj.receiveDate;
                    string receiveTime = jsonObj.receiveTime;
                    double billAmountNoTax = jsonObj.billAmountNoTax;
                    double taxAmount = jsonObj.taxAmount;
                    double billAmount = jsonObj.billAmount;
                    JArray items = jsonObj.Items;
                    dynamic itemArray = items.ToList();
                    Bill bill = db.Bill.Where(d => d.BillId == billId && d.CompanyId == companyId).FirstOrDefault();
                    bill.ReceivedDate = DateTime.Now;
                    bill.ReceivedById = receivedById;
                    bill.BillAmount = billAmount;
                    bill.BillAmountNoTax = billAmountNoTax;
                    bill.TaxAmount = taxAmount;
                    db.SaveChanges();
                    bool isClose = true;
                    for (int i = 0; i < itemArray.Count; i++)
                    {
                        //for (int j = 0; i < DetailArray.Count; j++)
                        //{
                        string action = itemArray[i].Action;
                        int ordItemId = itemArray[i].OrderItemId;
                        int productId = itemArray[i].ProductId;
                        double dispatchQty = itemArray[i].DispatchQty;
                        int? batchNum = itemArray[i].BatchNum;
                        int? orderId = itemArray[i].OrderId;
                        int? storageId = itemArray[i].StorageStoreId;
                        int? OrdDetailId = jsonObj.OrderItemDetailId;
                        switch (action)
                        {
                            case "Add":
                                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(objData);
                                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                                sqlCon.Open();
                                SqlCommand cmd = new SqlCommand("dbo.AddOrdItems", sqlCon);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@orderJson", jsonString));
                                cmd.Parameters.Add(new SqlParameter("@companyid", companyId));
                                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                                cmd.Parameters.Add(new SqlParameter("@ordItemId", ordItemId));
                                cmd.Parameters.Add(new SqlParameter("@billId", billId));
                                DataSet ds = new DataSet();
                                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                                sqlAdp.Fill(ds);
                                break;
                            case "Chk":
                                var jsonString1 = Newtonsoft.Json.JsonConvert.SerializeObject(objData);
                                SqlConnection sqlCon1 = new SqlConnection(Configuration.GetConnectionString("myconn"));
                                sqlCon1.Open();
                                SqlCommand comd = new SqlCommand("dbo.UpdateInternal", sqlCon1);
                                comd.CommandType = CommandType.StoredProcedure;
                                comd.Parameters.Add(new SqlParameter("@orderData", jsonString1));
                                comd.Parameters.Add(new SqlParameter("@companyid", companyId));
                                comd.Parameters.Add(new SqlParameter("@orderId", orderId));
                                comd.Parameters.Add(new SqlParameter("@ordItemId", ordItemId));
                                comd.Parameters.Add(new SqlParameter("@OrdDetailId", OrdDetailId));
                                DataSet ds1 = new DataSet();
                                SqlDataAdapter sqlAdp1 = new SqlDataAdapter(comd);
                                sqlAdp1.Fill(ds1);
                                break;

                        }
                    }
                    //}
                    scope.Complete();
                    var response = new
                    {
                        status = 200,
                        bill = billId,
                        data = "Received Successfully"
                    };
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    var response = new
                    {
                        status = 0,
                        msg = "Something went wrong",
                        error = new Exception(ex.Message, ex.InnerException)
                    };
                    return Ok(response);
                }
            }
        }


        [HttpPost("UpdateReceive")]
        public IActionResult UpdateReceive([FromBody] dynamic objData)
        {
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {
                    dynamic jsonObj = objData;
                    int billId = jsonObj.billId;
                    int companyId = jsonObj.companyId;
                    int? receivedById = jsonObj.receivedById;
                    string receiveDate = jsonObj.receiveDate;
                    string receiveTime = jsonObj.receiveTime;
                    double billAmountNoTax = jsonObj.billAmountNoTax;
                    double taxAmount = jsonObj.taxAmount;
                    double billAmount = jsonObj.billAmount;
                    //DateTime receiveDateTime = FbBatterController.GetDateTimeSave(receiveDate, receiveTime);
                    JArray items = jsonObj.items;
                    dynamic itemArray = items.ToList();
                    Bill bill = db.Bill.Where(d => d.BillId == billId && d.CompanyId == companyId).FirstOrDefault();
                    bill.ReceivedDate = DateTime.Now;
                    bill.ReceivedById = receivedById;
                    bill.BillAmount = billAmount;
                    bill.BillAmountNoTax = billAmountNoTax;
                    bill.TaxAmount = taxAmount;
                    db.SaveChanges();
                    OrderItem orderProd = null;
                    bool isClose = true;

                    SqlConnection conString = new SqlConnection(Configuration.GetConnectionString("myconn"));

                    for (int i = 0; i < itemArray.Count; i++)
                    {
                        int prodId = itemArray[i].ProductId;
                        string action = itemArray[i].Action;
                        double qty = itemArray[i].OrderQuantity;
                        double? tax1 = itemArray[i].Tax1;
                        double? tax2 = itemArray[i].Tax2;
                        double? tax3 = itemArray[i].Tax3;
                        double? price = itemArray[i].Price;
                        int orderProdId = itemArray[i].OrderItemId;
                        int? ordItemDetailId = itemArray[i].OrdItemDetailId;
                        int? storageStoreId = itemArray[i].StoragestoreId;

                        if (tax1 == null) tax1 = 0;
                        if (tax2 == null) tax3 = 0;
                        if (tax3 == null) tax2 = 0;
                        if (price == null) price = 0;
                        double? taxamount = qty * price * (tax1 + tax2 + tax3) / 100;
                        double? amount = qty * price;
                        double? billAmt = amount + taxamount;

                        if (storageStoreId == null)
                            storageStoreId = bill.ReceiverId;

                        if (action == "Chk")
                        {
                            orderProd = db.OrderItems.Find(orderProdId);
                            var receiveProd = db.Products.Where(p => p.Id == prodId && p.CompanyId == companyId).FirstOrDefault();
                            double orderProdQty = 0;
                            //if (orderProd.Product.IsBasic)
                            //    orderProdQty = orderProd.Product.Factor * ordItemDetail.ActualProduct.Factor * ordItemDetail.Quantity;
                            //else
                            //    orderProdQty = ordItemDetail.ActualProduct.Factor * ordItemDetail.Quantity / orderProd.Product.Factor;

                            if (orderProd.ReceivedQuantity == orderProdQty)
                                orderProd.ReceivedQuantity = 0;
                            else
                                orderProd.ReceivedQuantity -= orderProdQty;
                            orderProd.Price = price;
                            orderProd.Tax1 = tax1;
                            orderProd.Tax2 = tax2;
                            //orderProd.Status = (int)OrderProductStatus.Open;

                            //SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                            //sqlCon.Open();
                            //SqlCommand cmd = new SqlCommand("dbo.UpdateStock", sqlCon);
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.Add(new SqlParameter("@storeId", ordItemDetail.StorageStoreId));
                            //cmd.Parameters.Add(new SqlParameter("@productId", ordItemDetail.ActualProdId));
                            //cmd.Parameters.Add(new SqlParameter("@quantity", -ordItemDetail.Quantity));
                            //cmd.Parameters.Add(new SqlParameter("@batchId", ordItemDetail.BatchId));
                            //cmd.Parameters.Add(new SqlParameter("@dateTime", bill.ReceivedDate));
                            //cmd.Connection.Open();
                            //cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                            //cmd.ExecuteNonQuery();
                            //cmd.Connection.Close();

                            //if (orderProd.DispatchedQuantity == null)
                            //{
                            //    db.Entry(orderProd).State = EntityState.Deleted;
                            //db.Entry(ordItemDetail).State = EntityState.Deleted;
                            //}
                            //else
                            // {
                            db.Entry(orderProd).State = EntityState.Modified;
                            //db.SaveChanges();
                            OrderItemDetail ordItemDetail = db.OrderItemDetails.Find(ordItemDetailId);
                            //ordItemDetail.Quantity = 0;
                            //ordItemDetail.StorageStoreId = (int)storageStoreId;
                            //ordItemDetail.Quantity = qty;
                            //ordItemDetail.OrderItemId = orderProdId;
                            //ordItemDetail.ActualProdId = prodId;

                            db.Entry(ordItemDetail).State = EntityState.Modified;
                            //if (ordItemDetail.Quantity < CalcDispatchQty(db, billId, orderProdId))
                            //    isClose = false;
                            // }

                            //if (orderProd.OrderId != null)
                            //    OrderComplete(db, (int)orderProd.OrderId, (int)OrderType.Internal, companyId);
                        }
                        //else if (action == "spa")
                        //{
                        //    orderProd = db.OrderItems.Find(orderProdId);
                        //    OrderItemDetail ordItemDetail = db.OrderItemDetails.Find(ordItemDetailId);

                        //    double oldOrdProdQty = 0;
                        //    //if (orderProd.Product.IsBasic)
                        //    //    oldOrdProdQty = orderProd.Product.Factor * ordItemDetail.ActualProduct.Factor * ordItemDetail.Quantity;
                        //    //else
                        //    //    oldOrdProdQty = ordItemDetail.ActualProduct.Factor * ordItemDetail.Quantity / orderProd.Product.Factor;

                        //    SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                        //    sqlCon.Open();
                        //    SqlCommand cmd = new SqlCommand("dbo.UpdateStock", sqlCon);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.Parameters.Add(new SqlParameter("@storeId", ordItemDetail.StorageStoreId));
                        //    cmd.Parameters.Add(new SqlParameter("@productId", ordItemDetail.ActualProdId));
                        //    cmd.Parameters.Add(new SqlParameter("@quantity", -ordItemDetail.Quantity));
                        //    cmd.Parameters.Add(new SqlParameter("@batchId", ordItemDetail.BatchId));
                        //    cmd.Parameters.Add(new SqlParameter("@dateTime", bill.ReceivedDate));
                        //    cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                        //    cmd.Connection.Open();
                        //    cmd.ExecuteNonQuery();
                        //    cmd.Connection.Close();
                        //    //OrdersControllerExt.RemoveStock(db, (int)ordItemDetail.ActualProdId, (int)ordItemDetail.StorageStoreId, ordItemDetail.Quantity);

                        //    var receiveProd = db.Products.Where(p => p.Id == prodId && p.CompanyId == companyId).FirstOrDefault();
                        //    double orderProdQty = 0;
                        //    //if (orderProd.Product.IsBasic)
                        //    //    orderProdQty = orderProd.Product.Factor * receiveProd.Factor * qty;
                        //    //else
                        //    //    orderProdQty = receiveProd.Factor * qty / orderProd.Product.Factor;

                        //    orderProd.ReceivedQuantity += orderProdQty - oldOrdProdQty;

                        //    //orderProd.ReceivedQuantity += receiveQty - oldQty;
                        //    if (orderProd.OpenQuantity <= 0 && orderProd.ReceivedQuantity >= orderProd.DispatchedQuantity)
                        //        orderProd.Status = (int)OrderProductStatus.Closed;
                        //    else
                        //        orderProd.Status = (int)OrderProductStatus.Partial;

                        //    orderProd.Price = price;
                        //    orderProd.Tax1 = tax1;
                        //    orderProd.Tax2 = tax2;
                        //    db.Entry(orderProd).State = EntityState.Modified;
                        //    db.SaveChanges();
                        //    //OrderItemDetail ordItemDetail = db.OrderItemDetails.Find(ordItemDetailId);

                        //    ordItemDetail.Quantity = qty;
                        //    ordItemDetail.ActualProdId = prodId;
                        //    ordItemDetail.StorageStoreId = (int)storageStoreId;

                        //    sqlCon.Open();
                        //    SqlCommand cmd = new SqlCommand("dbo.UpdateStock", sqlCon);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.Parameters.Add(new SqlParameter("@storeId", ordItemDetail.StorageStoreId));
                        //    cmd.Parameters.Add(new SqlParameter("@productId", ordItemDetail.ActualProdId));
                        //    cmd.Parameters.Add(new SqlParameter("@quantity", ordItemDetail.Quantity));
                        //    cmd.Parameters.Add(new SqlParameter("@batchId", ordItemDetail.BatchId));
                        //    cmd.Parameters.Add(new SqlParameter("@dateTime", bill.ReceivedDate));
                        //    cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                        //    cmd.Connection.Open();
                        //    cmd.ExecuteNonQuery();
                        //    cmd.Connection.Close();

                        //    //OrdersControllerExt.AddStock(db, (int)ordItemDetail.ActualProdId, (int)ordItemDetail.StorageStoreId, receiveQty);

                        //    //if (containerId != null && containerCount != null)
                        //    //{
                        //    //    ordItemDetail.ContatinerId = (int)containerId;
                        //    //    ordItemDetail.ContainerCount = (int)containerCount;
                        //    //}

                        //    db.Entry(ordItemDetail).State = EntityState.Modified;
                        //    db.SaveChanges();
                        //    //if (ordItemDetail.Quantity < CalcDispatchQty(db, billId, orderProdId))
                        //    //    isClose = false;

                        //    //if (orderProd.OrderId != null)
                        //    //    OrderComplete(db, (int)orderProd.OrderId, (int)OrderType.Internal, companyId);
                        //}
                        else if (action == "Add")
                        {
                            orderProd = new OrderItem(
                                    null, prodId, null, 0, 0, 0, 0, 0, 0, companyId);
                            orderProd.ReceivedQuantity = qty;
                            orderProd.Status = (int)OrderProductStatus.Closed;
                            orderProd.CompanyId = companyId;
                            db.OrderItems.Add(orderProd);
                            db.SaveChanges();

                            OrderItemDetail ordItemDetail = new OrderItemDetail(orderProd.Id, bill.BillId, (int)Models.Enum.OrderItemType.Receive, 0, 0, 0, 0, 0, (DateTime)bill.ReceivedDate, db);
                            ordItemDetail.ActualProdId = prodId;
                            ordItemDetail.StorageStoreId = (int)storageStoreId;

                            //if (containerId != null && containerCount != null)
                            //{
                            //    ordItemDetail.ContatinerId = (int)containerId;
                            //    ordItemDetail.ContainerCount = (int)containerCount;
                            //}
                            ordItemDetail.CompanyId = companyId;
                            db.OrderItemDetails.Add(ordItemDetail);
                            db.SaveChanges();

                            //SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                            //sqlCon.Open();
                            //SqlCommand cmd = new SqlCommand("dbo.UpdateStock", sqlCon);
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.Add(new SqlParameter("@storeId", ordItemDetail.StorageStoreId));
                            //cmd.Parameters.Add(new SqlParameter("@productId", ordItemDetail.ActualProdId));
                            //cmd.Parameters.Add(new SqlParameter("@quantity", ordItemDetail.Quantity));
                            //cmd.Parameters.Add(new SqlParameter("@batchId", ordItemDetail.BatchId));
                            //cmd.Parameters.Add(new SqlParameter("@dateTime", bill.ReceivedDate));
                            //cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                            //cmd.Connection.Open();
                            //cmd.ExecuteNonQuery();
                            //cmd.Connection.Close();

                            //OrdersControllerExt.AddStock(db, (int)ordItemDetail.ActualProdId, (int)ordItemDetail.StorageStoreId, receiveQty);

                            //if (orderProd.OrderId != null)
                            //    OrderComplete(db, (int)orderProd.OrderId, (int)OrderItemType.Internal, companyId);
                        }
                        else
                        {
                            OrderItemDetail ordItemDetail = db.OrderItemDetails.Find(ordItemDetailId);
                            //if (ordItemDetail.Quantity < CalcDispatchQty(db, billId, orderProdId))
                            //    isClose = false;
                        }
                    }

                    //if (isClose)
                    //    bill.ReceiveStatus = (int)BillReceiveStatus.Closed;
                    //else
                    //    bill.ReceiveStatus = (int)BillReceiveStatus.Partial;
                    db.Entry(bill).State = EntityState.Modified;

                    db.SaveChanges();
                    scope.Complete();
                    var error = new { data = bill.BillId, msg = "Data Updated Successfully" };
                    return Json(error);
                }
                catch (Exception e)
                {
                    var error = new { data = e.Message, msg = "Contact your service provider" };
                    return Json(error);
                }
            }
        }


        public void WastageQtyAlert(int companyId, int ordPdtDetId, int productId, int? storeId, string type)
        {
            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            sqlCon.Open();
            SqlCommand cmd2 = new SqlCommand("dbo.WastageQtyAlert", sqlCon);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@storeId", storeId));
            cmd2.Parameters.Add(new SqlParameter("@ordPdtDetId", ordPdtDetId));
            cmd2.Parameters.Add(new SqlParameter("@productId", productId));
            cmd2.Parameters.Add(new SqlParameter("@type", type));
            cmd2.Parameters.Add(new SqlParameter("@companyId", companyId));
            cmd2.Connection.Open();
            cmd2.ExecuteNonQuery();
        }

        [HttpGet("getStoreListbyid")]
        public IActionResult getStoreListbyid(int storeId)
        {
            return Json(db.Stores.Find(storeId));
        }
        [HttpPost("addstore")]
        public IActionResult addstore([FromBody] Store store)
        {
            try
            {
                db.Stores.Add(store);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Store added successfully"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something went wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }
        [HttpPost("updateStore")]
        public IActionResult updateStore([FromBody] Store store)
        {
            try
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "store updated successfully"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something went wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }
        [HttpGet("EditInternalOrd")]
        public IActionResult EditInternalOrd(int id)
        {
            Order InternalOrd = db.Orders.Find(id);
            InternalOrd.ReceiveStatus = 1;
            db.Entry(InternalOrd).State = EntityState.Modified;
            db.SaveChanges();
            var data = new
            {
                data = "Received Status Updated",
                status = 1
            };
            return Json(data);

        }

        // GET: StoreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
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

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
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

        // GET: StoreController/Delete/5

        // POST: StoreController/Delete/5
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

        [HttpGet("internalordbyid")]
        public IActionResult Gettestdata(int orderId)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.OrderIdbyInternal", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var data = new
                {
                    receipts = ds.Tables[0],
                };
                sqlCon.Close();
                return Ok(data);
            }
            catch (Exception e)
            {
                var error = new
                {
                    error = new Exception(e.Message, e.InnerException),
                    status = 0,
                    msg = "Something went wrong  Contact our service provider"
                };
                return Json(error);
            }

        }

        [HttpGet("receivebyid")]
        public IActionResult receivebyid(int orderId)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.receivedorderbyId", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var data = new
                {
                    receipts = ds.Tables[0],
                };
                sqlCon.Close();
                return Ok(data);
            }
            catch (Exception e)
            {
                var error = new
                {
                    error = new Exception(e.Message, e.InnerException),
                    status = 0,
                    msg = "Something went wrong  Contact our service provider"
                };
                return Json(error);
            }

        }

        [HttpPost("GetOrderItems")]

        public IActionResult GetOrderItems([FromBody] JObject objData)
        {
            try
            {
                dynamic jsonObj = objData;
                int? supplierId = jsonObj.SuppliedById;
                int? orderedById = jsonObj.OrderedById;
                int dispatchTypeId = jsonObj.dispatchType;
                int companyId = jsonObj.companyId;

                List<OrderItem> orderProducts = null;
                dynamic orderProductList = null;
                int count = 0;
                var dispatchProductList = new List<DispatchProductList>();
                var storageStrList = new List<StorageStrList>();

                //if (dispatchTypeId == (int)DispatchTypeEnum.Normal_Dispatch)
                //{
                orderProducts = GetOrderProducts(db, supplierId, orderedById, companyId);

                foreach (OrderItem orderProduct in orderProducts)
                {

                    var dispatchProducts = db.Products.Where(p => p.Id == orderProduct.ProductId
                                          && p.isactive == true).Select(p => new { p.Id, p.Description, p.Price });
                    double quantity = db.StockBatches.Where(s => s.Stock.ProductId == orderProduct.ProductId
                              && s.Stock.StoreId == supplierId).
                              Select(s => s.Quantity).FirstOrDefault();

                    foreach (var dispatchProduct in dispatchProducts)
                    {
                        DispatchProductList product = new DispatchProductList();
                        product.DispatchProductId = dispatchProduct.Id;
                        product.DispatchProduct = dispatchProduct.Description;
                        product.StockQuantity = quantity;
                        product.OrderProductId = orderProduct.Id;
                        dispatchProductList.Add(product);
                    }


                    //var provider = db.SaleStoreProd.Where(s => s.StoreId == (int)supplier && s.ProductId == orderProduct.ProductId && s.StorageSubStoreId != null).FirstOrDefault();
                    var provider = db.Stocks.Where(s => s.StoreId == (int)supplierId && s.ProductId == orderProduct.ProductId && s.StorageStoreId != null).FirstOrDefault();
                    if (provider != null)
                    {
                        orderProduct.DispatchStorageName = provider.StorageStore.Name;
                        orderProduct.DispatchStorageId = provider.StorageStoreId;
                    }
                    var storageStrs = db.Stores.Where(s => (s.Id == supplierId || s.ParentStoreId == supplierId && s.ParentStoreId != null)).ToList();
                    foreach (var storageStr in storageStrs)
                    {
                        StorageStrList store = new StorageStrList();
                        store.StoreId = storageStr.Id;
                        if (orderProduct.DispatchStorageId == storageStr.Id)
                            store.IsSelected = true;
                        else store.IsSelected = false;
                        store.StoreName = storageStr.Name;
                        store.OrderProductId = orderProduct.Id;
                        storageStrList.Add(store);
                    }

                    var container = db.StockContainers.Where(s => s.Store.Id == supplierId && s.ProductId == orderProduct.ProductId).FirstOrDefault();
                    if (container != null)
                    {
                        orderProduct.Container = container.StockContainerName + " - " + container.ContainerWight + "KG";
                        orderProduct.ContainerId = container.StockContainerId;
                        orderProduct.ContainerWeight = container.ContainerWight;
                    }
                }

                count = orderProducts.Count();
                //orderProductList = orderProducts.ToList();
                orderProductList = orderProducts.Select(op => new
                {
                    op.ProductId,
                    op.Product.Description,
                    op.CompanyId,
                    op.ContainerId,
                    op.Container,
                    op.ContainerCount,
                    op.ContainerWeight,
                    op.DispatchStorageId,
                    op.DispatchStorageName,
                    op.OrderId,
                    op.OrderItemId,
                    op.PendingQty,
                    op.Price,
                    op.Amount,
                    op.Quantity,
                    op.Tax1,
                    op.Tax2,
                    op.TaxAmount,
                    op.Id
                });

                var orderProds = from op in db.OrderItems
                                 join o in db.Orders on op.OrderId equals o.Id
                                 join p in db.Products on op.ProductId equals p.Id
                                 join oid in db.OrderItemDetails on op.Id equals oid.OrderItemId
                                 where (o.SuppliedById == supplierId) &&
                                  op.Status < (int)OrderProductStatus.Closed &&
                                 (o.OrderedById == orderedById && (o.CompanyId == companyId))
                                 select new
                                 {
                                     op.ProductId,
                                     op.Product.Description,
                                     op.CompanyId,
                                     op.ContainerId,
                                     op.Container,
                                     op.ContainerCount,
                                     op.ContainerWeight,
                                     op.DispatchStorageId,
                                     op.DispatchStorageName,
                                     op.OrderId,
                                     op.PendingQty,
                                     op.Price,
                                     op.Amount,
                                     op.Quantity,
                                     op.Tax1,
                                     op.Tax2,
                                     op.TaxAmount,
                                     oid.Id,
                                     oid.OrderItemRefId,
                                     op.RefId,
                                     oid.OrderItemType,
                                     oid.OrderItemId
                                 };

                var data = new
                {
                    count = count,
                    dispatchProductList = dispatchProductList,
                    orderProducts = orderProductList,
                    storageStrList = storageStrList,
                    orderProd = orderProds
                };
                return Json(data);
            }
            catch (Exception e)
            {
                var error = new { data = e.Message, msg = "Contact your service provider" };
                return Json(error);
            }
        }
        public static List<OrderItem> GetOrderProducts(POSDbContext db, int? vendorId, int? storeId, int companyId)
        {
            List<OrderItem> orderProducts = null;
            if (storeId == -1)
            {
                orderProducts = (from op in db.OrderItems
                                 join o in db.Orders on op.OrderId equals o.Id
                                 where o.SuppliedById == vendorId
                                  && o.CompanyId == companyId
                                 orderby op.ProductId
                                 select op).ToList();
            }
            else
            {
                orderProducts = (from op in db.OrderItems
                                 join o in db.Orders on op.OrderId equals o.Id
                                 join p in db.Products on op.ProductId equals p.Id
                                 join oid in db.OrderItemDetails on op.Id equals oid.OrderItemId
                                 where o.SuppliedById == vendorId &&
                                  op.Status < (int)OrderProductStatus.Closed &&
                                 o.OrderedById == storeId && o.CompanyId == companyId
                                 select op).Include(x => x.Product).ToList();
            }
            for (int i = 0; i < orderProducts.Count(); i++)
            {
                orderProducts[i].Quantity = (int)orderProducts[i].OrderQuantity;
                //orderProducts[i].Product.BaseProduct = null;
            }
            return orderProducts;
        }
        public class ReceiveProductList
        {
            public int OrderProductId;
            public int ReceiveProductId;
            public string ReceiveProduct;
        }

        public class DispatchProductList
        {
            public int OrderProductId;
            public int DispatchProductId;
            public string DispatchProduct;
            public double StockQuantity;
        }
        public class StorageStrList
        {
            public int OrderProductId;
            public int StoreId;
            public string StoreName;
            public bool IsSelected;

        }
    }
}


