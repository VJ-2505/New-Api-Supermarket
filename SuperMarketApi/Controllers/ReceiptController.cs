using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class ReceiptController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public ReceiptController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }


        //[HttpGet("Gettestdata")]
        //public IActionResult Gettestdata(int Storeid, DateTime? fromdate, DateTime? todate)
        //{
        //    try
        //    {
        //        SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        //        sqlCon.Open();

        //        SqlCommand cmd = new SqlCommand("dbo.Receipt", sqlCon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.Add(new SqlParameter("@ordereddate", Orderedate));
        //        cmd.Parameters.Add(new SqlParameter("@storeId", Storeid));
        //        cmd.Parameters.Add(new SqlParameter("@fromDate", fromdate));
        //        cmd.Parameters.Add(new SqlParameter("@todate", todate));
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        //        sqlAdp.Fill(ds);
        //        var data = new
        //        {
        //            receipts = ds.Tables[0],
        //        };
        //        sqlCon.Close();
        //        return Ok(data);
        //    }
        //    catch (Exception e)
        //    {
        //        var error = new
        //        {
        //            error = new Exception(e.Message, e.InnerException),
        //            status = 0,
        //            msg = "Something went wrong  Contact our service provider"
        //        };
        //        return Json(error);
        //    }

        //}

        [HttpGet("Get")]
        public IActionResult Get(int StoreId, int CompanyId, int StartId, string type, string dataType, DateTime? fromdate, DateTime? todate, string invoice)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.Receipt", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@compId", CompanyId));
                cmd.Parameters.Add(new SqlParameter("@storeId", StoreId));
                cmd.Parameters.Add(new SqlParameter("@startId", StartId));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                cmd.Parameters.Add(new SqlParameter("@data", dataType));
                cmd.Parameters.Add(new SqlParameter("@fromDate", fromdate));
                cmd.Parameters.Add(new SqlParameter("@todate", todate));
                cmd.Parameters.Add(new SqlParameter("@invoice", invoice));

                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);

                DataTable table = ds.Tables[0];
                var data = new
                {
                    receipts = ds.Tables[0],
                    orderItems = ds.Tables[1],
                    // Options = ds.Tables[2],
                    AdditionalCharges = ds.Tables[2],
                    KOTs = ds.Tables[3],
                    Transaction = ds.Tables[4],
                    FirstOrderId = ds.Tables[5],
                    LastOrderId = ds.Tables[6],
                    TotalPayments = ds.Tables[7],
                    PaymentType = db.PaymentTypes.ToList(),
                    Customers = db.Customers.ToList(),
                    TransactionPayments = ds.Tables[8]
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

        [HttpPost("Pay")]
        public IActionResult Pay([FromForm] string value)
        {
            try
            {
                dynamic orderJson = JsonConvert.DeserializeObject(value);
                Transaction transaction = orderJson.ToObject<Transaction>();
                //transaction.PaymentTypeId = 1;
                transaction.TransDateTime = DateTime.Now;
                transaction.TransDate = DateTime.Now;
                transaction.TranstypeId = 1;
                if (transaction.Amount < 0)
                {
                    transaction.TranstypeId = 2;
                }
                db.Transactions.Add(transaction);
                db.SaveChanges();
                var order = db.Orders.Find(transaction.OrderId);
                if (order.PaidAmount * -1 == transaction.Amount)
                {
                    order.OrderStatusId = -1;
                    order.RefundAmount = transaction.Amount * -1;
                    transaction.Amount = transaction.Amount * -1;
                }
                if (order.OrderStatusId != -1)
                {
                    order.PaidAmount = order.PaidAmount + transaction.Amount;
                }
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                var error = new
                {
                    status = 200,
                    msg = "Payment done"
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


        // POST api/<controller>
        [HttpPost("ordertransaction")]
        public IActionResult ordertransaction([FromBody] dynamic transactionlist)
        {
            try
            {
                List<Transaction> transactions = transactionlist.ToObject<List<Transaction>>();
                foreach (Transaction transaction in transactions)
                {
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }
                var error = new
                {
                    status = 200,
                    msg = "Transactions saved"
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

            [HttpGet("getByOrderId")]
        public ActionResult getByOrderId(int OrderId)
        {
            try
            {
                List<Transaction> transactions = db.Transactions.Where(x => x.OrderId == OrderId).ToList();
                var response = new
                {
                    status = 200,
                    msg = "Success",
                    transactions = transactions
                };
                return Json(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    status = 500,
                    error = new Exception(e.Message, e.InnerException)
                };
                return Json(error);
            }
        }

        //[HttpPost("Pay")]
        //public IActionResult Pay([FromBody] dynamic data)
        //{
        //    try
        //    {
        //        dynamic orderJson = data;

        //        Transaction transaction = data.value.ToObject<Transaction>();
        //        //transaction.PaymentTypeId = 1;
        //        transaction.TransDateTime = DateTime.Now;
        //        transaction.TransDate = DateTime.Now;
        //        transaction.TranstypeId = 1;
        //        if (transaction.Amount < 0)
        //        {
        //            transaction.TranstypeId = 2;
        //        }
        //        db.Transactions.Add(transaction);
        //        db.SaveChanges();

        //        var order = db.Orders.Find(transaction.OrderId);
        //        if (order.PaidAmount * -1 == transaction.Amount)
        //        {
        //            order.OrderStatusId = -1;
        //            dynamic jsn = JsonConvert.DeserializeObject(order.OrderJson);
        //            jsn.OrderStatusId = -1;
        //            order.OrderJson = JsonConvert.SerializeObject(jsn);
        //            order.RefundAmount = transaction.Amount * -1;
        //            transaction.Amount = transaction.Amount * -1;
        //        }
        //        if (order.OrderStatusId != -1)
        //        {
        //            order.PaidAmount = order.PaidAmount + transaction.Amount;
        //        }
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        var error = new
        //        {
        //            status = 200,
        //            msg = "Payment done"
        //        };
        //        return Json(error);

        //    }
        //    catch (Exception e)
        //    {
        //        var error = new
        //        {
        //            error = new Exception(e.Message, e.InnerException),
        //            status = 0,
        //            msg = "Something went wrong  Contact our service provider"
        //        };
        //        return Json(error);
        //    }
        //}

        [HttpPost("saveTransaction")]
        public IActionResult saveTransaction([FromBody] dynamic data)
        {
            try
            {
                int? orderid = 0;
                Transaction oldTransaction = new Transaction();
                double difference = 0;
                data.PaymentType = null;
                Transaction transaction = data.ToObject<Transaction>();
                oldTransaction = db.Transactions.Where(x => x.TransactionId == transaction.TransactionId).AsNoTracking().FirstOrDefault();
                orderid = transaction.OrderId;
                db.Entry(transaction).State = EntityState.Modified;
                difference = oldTransaction.Amount - transaction.Amount;
                if (orderid != null && orderid > 0 && difference != 0)
                {
                    Order order = db.Orders.Find(orderid);
                    order.PaidAmount = order.PaidAmount - difference;
                    dynamic payload = JsonConvert.DeserializeObject(order.OrderJson);
                    payload.PaidAmount = order.PaidAmount;
                    order.OrderJson = JsonConvert.SerializeObject(payload);
                    db.Entry(transaction).State = EntityState.Modified;
                    db.SaveChanges();
                }
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    message = "Success"
                };
                return Json(response);
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
        // GET: ReceiptController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReceiptController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReceiptController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReceiptController/Create
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

        // GET: ReceiptController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReceiptController/Edit/5
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

        // GET: ReceiptController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReceiptController/Delete/5
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
