using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Cors;

using Microsoft.Extensions.Configuration;
//using Quobject.SocketIoClientDotNet.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;

using System.Net.Mail;
using System.Text;
using System.Net;
using SuperMarketApi.Models;
using Microsoft.AspNetCore.Http;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class SaleController : Controller
    {
        private int OrderId;
        private object Order;
        private int CustomerId;
        private int CustomerNo;
        private string CustomerPhone;
        private POSDbContext db;
        private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        private object _uhubContext;

        public IConfiguration Configuration { get; }
        public SaleController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }


        [HttpPost("saveorder_3")]
        public IActionResult saveorder_3([FromBody] OrderPayload payload)
        {
            int? storeid = null;
            int? companyid = null;
            try
            {
                int orderid = 0;
                dynamic data = new { };
                string message = "";
                int status = 200;
                dynamic orderjson = JsonConvert.DeserializeObject(payload.OrderJson);
                string invoiceno = orderjson.InvoiceNo.ToString();
                long createdtimestamp = 0;
                if (orderjson.createdtimestamp != null)
                {
                    createdtimestamp = (long)orderjson.createdtimestamp;
                }
                int paymenttypeid = (int)orderjson.PaymentTypeId;
                int? storepaymenttypeid = null;
                storeid = (int)orderjson.StoreId;
                companyid = (int)orderjson.CompanyId;
                if (orderjson.StorePaymentTypeId != null)
                {
                    storepaymenttypeid = (int)orderjson.StorePaymentTypeId;
                }
                string cphone = orderjson.CustomerDetails.PhoneNo.ToString();
                storeid = (int)orderjson.StoreId;
                companyid = (int)orderjson.CompanyId;
                int customerid = -1;
                int last_orderno = 0;
                if (db.Orders.Where(x => x.StoreId == storeid && x.OrderedDate == TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time).Date).Any())
                {
                    last_orderno = db.Orders.Where(x => x.StoreId == storeid && x.OrderedDate == TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time).Date).Max(x => x.OrderNo);
                }
                int current_orderno = (int)orderjson.OrderNo;
                int orderno_diff = current_orderno - last_orderno;
                if (orderno_diff > 1)
                {
                    //Store store = db.Stores.Find(storeid);
                    //Alert alert = new Alert();
                    //alert.AlertDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    //alert.AlertName = "orderno_skip";
                    //alert.CompanyId = (int)companyid;
                    //alert.StoreId = (int)storeid;
                    //string mailbody = store.Name + " has faced an orderno_skip event @" + alert.AlertDateTime + ". Last orderno is " + last_orderno.ToString() + " and Current orderno is " + current_orderno;
                    //alert.Note = mailbody;
                    ////db.Alerts.Add(alert);
                    //db.SaveChanges();
                    //send_alert_email(mailbody);
                }
                if (db.Orders.Where(x => x.InvoiceNo == invoiceno && x.CreatedTimeStamp == createdtimestamp).Any())
                {
                    message = "It is a duplicate Order!";
                    status = 409;
                    OrderLog orderLog = new OrderLog();
                    orderLog.CompanyId = (int)companyid;
                    orderLog.StoreId = (int)storeid;
                    orderLog.Payload = payload.OrderJson;
                    orderLog.Error = "It is a Duplicate Order";
                    orderLog.LoggedDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    db.OrderLogs.Add(orderLog);
                    //db.SaveChanges();
                }
                else
                {
                    if (cphone != "" && cphone != null)
                    {
                        customerid = db.Customers.Where(x => x.PhoneNo == cphone).Any() ? db.Customers.Where(x => x.PhoneNo == cphone).FirstOrDefault().Id : 0;
                    }
                    using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("myconn")))
                    {
                        conn.Open();
                        SqlTransaction tran = conn.BeginTransaction("Transaction1");
                        try
                        {
                            SqlCommand cmd = new SqlCommand("dbo.saveorderfb", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Transaction = tran;

                            cmd.Parameters.Add(new SqlParameter("@orderjson", payload.OrderJson));
                            cmd.Parameters.Add(new SqlParameter("@paymenttypeid", paymenttypeid));
                            //cmd.Parameters.Add(new SqlParameter("@storepaymenttypeid", storepaymenttypeid));
                            //cmd.Parameters.Add(new SqlParameter("@customerid", customerid));
                            DataSet ds = new DataSet();
                            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                            sqlAdp.Fill(ds);

                            DataTable table = ds.Tables[0];
                            data = table;
                            //Your Code

                            tran.Commit(); //both are successful
                            conn.Close();
                        }
                        catch (Exception e)
                        {
                            tran.Rollback();
                            conn.Close();
                            throw e;
                        }
                    }
                }
                var response = new
                {
                    data = data,
                    message = message,
                    status = status
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    error = new Exception(e.Message, e.InnerException),
                    status = 500,
                    msg = "Something went wrong  Contact our service provider"
                };
                return Json(error);
            }
        }

        [HttpGet("getOrderById")]
        [EnableCors("AllowOrigin")]
        public IActionResult getOrderById(int orderid)
        {
            try
            {
                Order order = db.Orders.Find(orderid);
                return Json(order);
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

        [HttpPost("updateorder_2")]
        public IActionResult updateorder_2([FromBody] OrderPayload payload)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("myconn")))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction("Transaction1");
                try
                {
                    dynamic raworder = JsonConvert.DeserializeObject(payload.OrderJson);
                    if (raworder.DiscAmount == null)
                    {
                        raworder.DiscAmount = 0;
                    }
                    string orderjson = payload.OrderJson;
                    raworder.Id = raworder.OrderId;
                  
                    Order order = raworder.ToObject<Order>();
                    order.ItemJson = JsonConvert.SerializeObject(raworder.Items);
                    order.OrderStatusId = raworder.OrderStatusId;
                    //order.CustomerId = raworder.CustomerId;
                    
                    foreach (string citem in raworder.changeditems)
                    {
                        if (citem == "transaction")
                        {
                            orderjson = ordertransaction(payload).OrderJson;
                        }
                        else if (citem == "kot")
                        {
                            orderjson = orderkot(payload).OrderJson;    
                        }
                    }
                    order.OrderJson = orderjson;
                    if (order.OrderStatusId == 5)
                    {
                        order.DeliveredDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                        order.DeliveredDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    }
                    order.DeliveryDate = order.DeliveryDateTime == null ? order.OrderedDate : order.DeliveryDateTime;
                    order.DeliveryStoreId = order.DeliveryStoreId == null ? order.StoreId : order.DeliveryStoreId;
                    order.OrderedTime = db.Orders.Where(x => x.Id == order.Id).AsNoTracking().FirstOrDefault().OrderedTime;
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                    if (order.DeliveryStoreId != null)
                    {
                        //_uhubContext.Clients.All.DeliveryOrderUpdate((int)order.StoreId, (int)order.DeliveryStoreId, order.InvoiceNo);
                    }
                    var response = new
                    {
                        status = 200,
                        msg = "status change success"
                    };
                    return Json(response);
                }
                catch (Exception e)
                {
                    //if error occurred, reverse all actions. By this, your data consistent and correct
                    tran.Rollback();
                    conn.Close();
                    var error = new
                    {
                        error = new Exception(e.Message, e.InnerException),
                        status = 500,
                        msg = "Something went wrong  Contact our service provider"
                    };
                    return Json(error);
                }
            }
        }

        [HttpGet("Get")]
        [EnableCors("AllowOrigin")]
        public IActionResult Get(int CompanyId)
        {
            try
            {

                var diningarea = (from da in db.DiningAreas
                                  join s in db.Stores on da.StoreId equals s.Id
                                  where da.CompanyId == CompanyId
                                  select new { da.Id, da.Description, s.Name, da.StoreId, store = s.Id }).ToList();
                //var diningarea = db.DiningAreas.Where(v => v.CompanyId == CompanyId).ToList();
                System.Collections.Generic.Dictionary<string, object>[] objData = new System.Collections.Generic.Dictionary<string, object>[diningarea.Count()];

                for (int i = 0; i < diningarea.Count(); i++)
                {
                    objData[i] = new Dictionary<string, object>();
                    objData[i].Add("Id", diningarea[i].Id);
                    objData[i].Add("DiningArea", diningarea[i].Description);
                    objData[i].Add("StoreId", diningarea[i].StoreId);
                    objData[i].Add("StoreName", diningarea[i].Name);
                    string str = "";

                    var dining = db.DiningTables.Where(v => v.DiningAreaId == diningarea[i].Id).ToList();
                    int varCount = dining.Count();
                    for (int j = 0; j < varCount; j++)
                    {
                        if (j < varCount - 1)
                        {
                            str += dining[j].Description + ",";
                        }
                        else
                        {
                            str += dining[j].Description;
                        }

                    }
                    objData[i].Add("DiningTable", str);
                }

                return Ok(objData);
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

        [HttpGet("GetById")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var diningarea = db.DiningAreas.Find(Id);
                System.Collections.Generic.Dictionary<string, object>[] objData = new System.Collections.Generic.Dictionary<string, object>[1];

                var diningtable = db.DiningTables.Where(v => v.DiningAreaId == Id).ToList();
                objData[0] = new Dictionary<string, object>();
                objData[0].Add("Id", diningarea.Id);
                objData[0].Add("DiningArea", diningarea.Description);
                objData[0].Add("StoreId", diningarea.StoreId);
                //string str = "";
                //for (int j = 0; j < variant.Count(); j++)
                //{
                //    str += variant[j].Description + ",";
                //}
                objData[0].Add("DiningTable", diningtable);


                return Ok(objData);
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

        [HttpGet("getUnfinishedOrders")]
        [EnableCors("AllowOrigin")]
        public IActionResult getUnfinishedOrders(int storeid)
        {
            try
            {
                int[] pendingStatusIds = { 0, 1, 2, 3, 4 };
                int[] advancedOrderTypeIds = { 2, 3, 4 };

                DateTime today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                List<Order> order = db.Orders.Where(o => (o.OrderedDate == today || pendingStatusIds.Contains(o.OrderStatusId) || o.BillAmount != o.PaidAmount) && o.StoreId == storeid && advancedOrderTypeIds.Contains(o.OrderType) && o.OrderJson != null).ToList();
                return Json(order);
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

        [HttpPost("Update")]
        [EnableCors("AllowOrigin")]
        public IActionResult Update([FromForm] string Data)
        {
            try
            {
                dynamic orderJson = JsonConvert.DeserializeObject(Data);
                DiningArea diningArea = orderJson.ToObject<DiningArea>();
                diningArea.ModifiedDate = DateTime.Now;
                db.Entry(diningArea).State = EntityState.Modified;
                db.SaveChanges();
                JArray itemObj = orderJson.DiningTable;
                JArray itemDel = orderJson.Del;
                dynamic itemJson = itemObj.ToList();
                dynamic itemJsonDel = itemDel.ToList();
                foreach (var item in itemJson)
                {
                    if (item.Id == 0)
                    {
                        DiningTable diningTable = item.ToObject<DiningTable>();
                        diningTable.ModifiedDate = DateTime.Now;
                        db.DiningTables.Add(diningTable);
                        db.SaveChanges();
                    }
                    else
                    {
                        DiningTable diningTable = item.ToObject<DiningTable>();
                        diningTable.ModifiedDate = DateTime.Now;
                        db.Entry(diningTable).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                foreach (var item in itemJsonDel)
                {
                    int itemId = item.Id.ToObject<int>();
                    DiningTable diningTable = db.DiningTables.Find(itemId);
                    db.DiningTables.RemoveRange(diningTable);
                    db.SaveChanges();
                }
                var error = new
                {
                    status = "success",
                    data = new
                    {
                        value = 2
                    },
                    msg = "The Data Updated successfully"
                };

                return Json(error);
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

        [HttpPost("CreateArea")]
        [EnableCors("AllowOrigin")]
        public IActionResult CreateArea([FromForm] string data)
        {
            try
            {
                dynamic orderJson = JsonConvert.DeserializeObject(data);
                {
                    DiningArea diningArea = orderJson.ToObject<DiningArea>();
                    diningArea.ModifiedDate = DateTime.Now;
                    db.DiningAreas.Add(diningArea);
                    db.SaveChanges();
                    JArray itemObj = orderJson.DiningTable;
                    dynamic itemJson = itemObj.ToList();
                    foreach (var item in itemJson)
                    {
                        DiningTable diningTable = item.ToObject<DiningTable>();
                        diningTable.ModifiedDate = DateTime.Now;
                        diningTable.DiningAreaId = diningArea.Id;
                        diningTable.StoreId = diningArea.StoreId;
                        db.DiningTables.Add(diningTable);
                        db.SaveChanges();
                    }
                    var error = new
                    {
                        status = "success",
                        data = new
                        {
                            value = 2
                        },
                        msg = "The DiningArea added successfully"
                    };

                    return Json(error);
                }
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

        [HttpGet("Deletedinein")]
        [EnableCors("AllowOrigin")]
        public IActionResult Deletedinein(int Id)
        {
            try
            {
                var dining = db.DiningTables.Where(x => x.DiningAreaId == Id).ToList();
                foreach (var item in dining)
                {
                    var opt = db.DiningTables.Find(item.Id);
                    db.DiningTables.Remove(opt);
                }
                var area = db.DiningAreas.Find(Id);
                db.DiningAreas.Remove(area);
                db.SaveChanges();
                var error = new
                {
                    status = "success",
                    data = new
                    {
                        value = 2
                    },
                    msg = "The Data deleted successfully"
                };

                return Json(error);
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

        public OrderPayload ordertransaction([FromBody] OrderPayload orderPayload)
        {
            dynamic raworder = JsonConvert.DeserializeObject(orderPayload.OrderJson);
            orderPayload.Transactions = raworder.Transactions.ToObject<List<Transaction>>();
            int orderid = (int)orderPayload.Transactions.FirstOrDefault().OrderId;
            Order order = db.Orders.AsNoTracking().Where(x => x.Id == orderid).FirstOrDefault();
            List<Transaction> oldTransactions = db.Transactions.Where(x => x.OrderId == orderid).ToList();
            double totaltransactionamnt = 0;
            foreach (Transaction otrnsction in oldTransactions)
            {
                totaltransactionamnt += otrnsction.Amount;
            }
            if (order.PaidAmount > totaltransactionamnt)
            {
                foreach (Transaction transaction in orderPayload.Transactions)
                {
                    transaction.ModifiedDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }
            }
            //var list = raworder.changeditems.ToArray<string>();
            //list.Remove("transaction");
            raworder.closedtransactions = new JArray();
            for (int i = 0; i < raworder.Transactions.Count; i++)
            {
                raworder.closedtransactions.Add(raworder.Transactions[i]);
            }
            raworder.changeditems = new JArray();
            raworder.Transactions = new JArray();
            orderPayload.OrderJson = JsonConvert.SerializeObject(raworder);
            return orderPayload;
        }
        public OrderPayload orderkot([FromBody] OrderPayload orderPayload)
        {
            dynamic raworder = JsonConvert.DeserializeObject(orderPayload.OrderJson);
            int orderid = (int)raworder.OrderId;
            //orderPayload.Transactions = raworder.Transactions.ToObject<List<Transaction>>();
            foreach (var kotobj in raworder.KOTS)
            {
                kotobj.OrderId = orderid;
                KOT kOT = kotobj.ToObject<KOT>();
                if (!db.KOTs.Where(x => x.refid == kOT.refid && x.OrderId == orderid).Any())
                {
                    db.KOTs.Add(kOT);
                    db.SaveChanges();
                    foreach (var item in kotobj.Items)
                    {
                        item.Product = null;
                        item.OrderId = orderid;
                        OrderItem orderItem = item.ToObject<OrderItem>();
                        orderItem.KOTId = kOT.Id;
                        db.OrderItems.Add(orderItem);
                        db.SaveChanges();
                        foreach (var optionGroup in item.OptionGroup)
                        {
                            if (optionGroup.selected == true)
                            {
                                foreach (var option in optionGroup.Option)
                                {
                                    if (option.selected == true)
                                    {
                                        OrdItemOptions itemoption = new OrdItemOptions();
                                        itemoption.OptionId = (int)option.Id;
                                        itemoption.OrderItemId = orderItem.Id;
                                        itemoption.orderitemrefid = option.orderitemrefid;
                                        itemoption.Price = option.Price;
                                        db.OrdItemOptions.Add(itemoption);
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //var list = raworder.changeditems.ToArray<string>();
            //list.Remove("transaction");
            raworder.changeditems = new JArray();
            raworder.Transactions = new JArray();
            orderPayload.OrderJson = JsonConvert.SerializeObject(raworder);
            return orderPayload;
        }


        // GET: SaleController
        //[HttpPost("saveorder")]
        //public IActionResult saveorder([FromBody] dynamic payload)
        //{
        //    int  line = 28;
        //    try
        //    {
        //        Customer customer = new Customer();
        //        Order order = new Order(); line++;
        //        order = payload.ToObject<Order>(); line++;
        //        string cphone = payload.CustomerDetails.PhoneNo.ToString();
        //        if (db.Customers.Where(x => x.PhoneNo == cphone).AsNoTracking().Any())
        //        {
        //            payload.CustomerDetails.Id = db.Customers.Where(x => x.PhoneNo == cphone).AsNoTracking().FirstOrDefault().Id;
        //            customer = payload.CustomerDetails.ToObject<Customer>();
        //            customer.CompanyId = order.CompanyId;
        //            customer.StoreId = order.StoreId;
        //            db.Entry(customer).State = EntityState.Modified; line++;
        //            db.SaveChanges();
        //            order.CustomerId = customer.Id;
        //        }
        //        else if (cphone != "" && cphone != null)
        //        {
        //            payload.CustomerDetails.Id = 0;
        //            customer = payload.CustomerDetails.ToObject<Customer>();
        //            customer.CompanyId = order.CompanyId;
        //            customer.StoreId = order.StoreId;
        //            db.Customers.Add(customer);
        //            db.SaveChanges();
        //            order.CustomerId = customer.Id;
        //        }
        //        else
        //        {
        //            order.CustomerId = null;
        //        }
        //        db.Orders.Add(order);  line++;
        //        db.SaveChanges();  line++;
        //        List<Batch> batches = new List<Batch>();  line++;
        //        List<StockBatch> stockBatches = new List<StockBatch>();  line++;
        //        int batchno = db.Batches.Where(x => x.CompanyId == order.CompanyId).Max(x => x.BatchNo);  line++;
        //        foreach (var item in payload.Items)
        //        {
        //            batches = new List<Batch>(); line++;
        //            stockBatches = new List<StockBatch>(); line++;
        //            OrderItem orderItem = new OrderItem();  line++;
        //            orderItem = item.ToObject<OrderItem>();  line++;
        //            orderItem.OrderId = order.Id;  line++;
        //            db.OrderItems.Add(orderItem);  line++;
        //            db.SaveChanges();  line++;
        //            batches = db.Batches.Where(x => x.BarcodeId == orderItem.BarcodeId && x.Price == orderItem.Price).ToList();  line++;
        //            foreach (Batch batch in batches)
        //            {
        //                var sbatches = db.StockBatches.Where(x => x.BatchId == batch.BatchId && x.Quantity >= orderItem.OrderQuantity).ToList();  line++;
        //                foreach (StockBatch stockBatch in sbatches)
        //                {
        //                    stockBatches.Add(stockBatch);  line++;
        //                }
        //            }
        //            stockBatches = stockBatches.OrderBy(x => x.CreatedDate).ToList(); line++;
        //            if (stockBatches.Count > 0)
        //            {
        //                StockBatch stckBtch = new StockBatch();
        //                stckBtch = stockBatches.FirstOrDefault(); line++;
        //                stckBtch.Quantity = stckBtch.Quantity - (int)orderItem.OrderQuantity; line++;
        //                db.Entry(stckBtch).State = EntityState.Modified; line++;
        //                db.SaveChanges(); line++;
        //            }
        //        }
        //        int lastorderno = db.Orders.Where(x => x.StoreId == order.StoreId).Max(x => x.OrderNo);  line++;
        //        var response = new
        //        {
        //            status = 200,
        //            message = "Sales Added Successfully",
        //            lastorderno = lastorderno,
        //            batches = batches,
        //            stockBatches = stockBatches,
        //            customer = customer
        //        };
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        var response = new
        //        {
        //            status = 0,
        //            msg = "Something Went Wrong",
        //            error = new Exception(ex.Message, ex.InnerException),
        //            errorline = line
        //        };
        //        return Ok(response);
        //    }
        //}


        [HttpGet("Testplan")]

        public IActionResult Testplan()
        {
            List<Plan> plans = db.Plans.ToList();

            return Json(plans);
        }

        [HttpGet("GetAccess")]
        public IActionResult GetAccess(int companyid, int storeid, int planid)
        {
            Store store = db.Stores.Find(storeid);
            Accounts company = db.Accounts.Where(a => a.CompanyId == companyid).FirstOrDefault();
            Plan plan = db.Plans.Find(planid);
            Plan oldPlan = db.Plans.Find(store.PlanId);

            string mailbody = String.Format(@"<!DOCTYPE html>
                                <html>
                                <head>
	                                <meta charset='utf-8'>
	                                <meta name='viewport' content='width=device-width, initial-scale=1'>
	                                <title></title>
                                </head>
                                <body>
	                                <p>{0} has requested change of plan from {1} to {2} for store {3} </p>
	                                <strong>Email: </strong> {4} <br>
	                                <strong>Phone No: </strong> {5}, {6} <br>
	                                <strong>Company Id: </strong> {7} <br>
	                                <strong>Store Id: </strong> {8}
                                </body>
                                </html>", company.Name, oldPlan.Name, plan.Name, store.Name, company.Email, company.PhoneNo, store.ContactNo, company.CompanyId, store.Id);
            mailbody += String.Format("{0} has requested change of plan from {1} to {2}\n", company.Name, oldPlan.Name, plan.Name);
            mailbody += String.Format("\nEmail: {0}", company.Email);
            mailbody += String.Format("\nPhone No: {0}, {1}", company.PhoneNo, store.ContactNo);
            send_alert_email(mailbody);

            var response = new
            {
                status = 200,
                meassage = "You will be contacted soon."
            };

            return Json(response);
        }
        [HttpGet("Testplandetails")]

        public IActionResult Testplandetails()
        {

            List<PlanDetail> Plandetail = db.PlanDetails.Where(x => x.IsActive == true).ToList();

            return Ok(Plandetail);
        }
        public void send_alert_email(string mailbody)
        {
            string from = "bizdom.solutions@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, "biz1pos.bizdom@gmail.com");
            //message.To.Add("karthick.nath@gmail.com");
            //message.To.Add("masterservice2020@gmail.com");
            //message.To.Add("mohamedanastsi@gmail.com");
            //message.To.Add("sanjai.nath1995@gmail.com");
            // string mailbody = storename + " faced an app crash event @" + dateTime.ToString();
            message.Subject = "User Plan Access";

            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            client.UseDefaultCredentials = false;
            NetworkCredential basicCredential1 = new
            NetworkCredential(from, "Password@123");

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);
        }


        [HttpPost("SaveOrder_Test")]
        public IActionResult SaveOrder_Test([FromBody] OrderPayload payload) {

            //int? companyid = null;
            //int? storeid = null;
            try

            {
                string message = "Order Test As Been Saved";
                int status = 200;
                dynamic orderjsonformat = JsonConvert.DeserializeObject(payload.OrderJson);
                dynamic DataAllocation = new { };
                using (SqlConnection myconnn = new SqlConnection(Configuration.GetConnectionString("myconn")))
                {
                    myconnn.Open();
                    try
                    {
                        SqlCommand ordersp = new SqlCommand("dbo.SaveOrderTest", myconnn);
                        ordersp.CommandType = CommandType.StoredProcedure;
                        ordersp.Parameters.Add(new SqlParameter("@orderjson", payload.OrderJson));
                        DataSet ds = new DataSet();
                        SqlDataAdapter sqladapter = new SqlDataAdapter(ordersp);
                        sqladapter.Fill(ds);
                        myconnn.Close();
                    }
                    catch (Exception e)
                    {
                        myconnn.Close();
                        throw e;
                    }
                }
                var response = new
                {
                    //data = DataAllocation,
                    message = message,
                    status = status
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    Error = new Exception(e.Message, e.InnerException),
                    status = 500,
                    Message = "Opps, Failed"
                };
                return Json(error);
            }
        }

       


        public class OrderPayload
        {
            public string OrderJson { get; set; }
            public List<Transaction> Transactions { get; set; }
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
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

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleController/Edit/5
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

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
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
