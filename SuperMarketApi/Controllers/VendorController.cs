using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SuperMarketApi.Models;
/*using System.Linq;*/
namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class VendorController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public VendorController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        [HttpGet("getVendorList")]
        public IActionResult getVendorList(int CompanyId)
        {
            return Json(db.Vendors.Where(x => x.CompanyId == CompanyId).ToList());
        }
        [HttpGet("getVendorListbyid")]
        public IActionResult getVendorListbyid(int vendorid)
        {
            return Json(db.Vendors.Find(vendorid));
        }
        [HttpPost("addvendors")]
        public IActionResult addvendors([FromBody] dynamic data)
        {
            try
            {
                Contact contact = new Contact();
                contact = data.ToObject<Contact>();
                contact.Zip = (string)data.PostalCode;
                db.Contacts.Add(contact);
                db.SaveChanges();
                Vendor vendor = new Vendor();
                vendor = data.ToObject<Vendor>();
                vendor.Id = (int)contact.Id;
                db.Vendors.Add(vendor);
                db.SaveChanges();
                var response = new
                {
                    vendor = vendor,
                    status = 200,
                    msg = "Vendors added successfully"
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
        [HttpPost("updatevendors")]
        public IActionResult updatevendors([FromBody] Vendor vendor)
        {
            try
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                var response = new
                {
                    vendor = vendor,
                    status = 200,
                    msg = "Vendor updated successfully"
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

        // GET: SaleController
        [HttpPost("saveorder")]
        public IActionResult saveorder([FromBody] dynamic payload)
        {
            int line = 28;
            try
            {
                Customer customer = new Customer();
                Order order = new Order(); line++;
                order = payload.ToObject<Order>(); line++;
                string cphone = payload.CustomerDetails.PhoneNo.ToString();
                if (db.Customers.Where(x => x.PhoneNo == cphone).AsNoTracking().Any())
                {
                    payload.CustomerDetails.Id = db.Customers.Where(x => x.PhoneNo == cphone).AsNoTracking().FirstOrDefault().Id;
                    customer = payload.CustomerDetails.ToObject<Customer>();
                    customer.CompanyId = order.CompanyId;
                    customer.StoreId = order.StoreId;
                    db.Entry(customer).State = EntityState.Modified; line++;
                    db.SaveChanges();
                    order.CustomerId = customer.Id;
                }
                else if (cphone != "" && cphone != null)
                {
                    payload.CustomerDetails.Id = 0;
                    customer = payload.CustomerDetails.ToObject<Customer>();
                    customer.CompanyId = order.CompanyId;
                    customer.StoreId = order.StoreId;
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    order.CustomerId = customer.Id;
                }
                else
                {
                    order.CustomerId = null;
                }
                db.Orders.Add(order); line++;
                db.SaveChanges(); line++;
                List<Batch> batches = new List<Batch>(); line++;
                List<StockBatch> stockBatches = new List<StockBatch>(); line++;
                int batchno = db.Batches.Where(x => x.CompanyId == order.CompanyId).Max(x => x.BatchNo); line++;
                foreach (var item in payload.Items)
                {
                    batches = new List<Batch>(); line++;
                    stockBatches = new List<StockBatch>(); line++;
                    OrderItem orderItem = new OrderItem(); line++;
                    orderItem = item.ToObject<OrderItem>(); line++;
                    orderItem.OrderId = order.Id; line++;
                    db.OrderItems.Add(orderItem); line++;
                    db.SaveChanges(); line++;
                    batches = db.Batches.Where(x => x.BarcodeId == orderItem.BarcodeId && x.Price == orderItem.Price).ToList(); line++;
                    foreach (Batch batch in batches)
                    {
                        var sbatches = db.StockBatches.Where(x => x.BatchId == batch.BatchId && x.Quantity >= orderItem.OrderQuantity).ToList(); line++;
                        foreach (StockBatch stockBatch in sbatches)
                        {
                            stockBatches.Add(stockBatch); line++;
                        }
                    }
                    stockBatches = stockBatches.OrderBy(x => x.CreatedDate).ToList(); line++;
                    if (stockBatches.Count > 0)
                    {
                        StockBatch stckBtch = new StockBatch();
                        stckBtch = stockBatches.FirstOrDefault(); line++;
                        stckBtch.Quantity = stckBtch.Quantity - (int)orderItem.OrderQuantity; line++;
                        db.Entry(stckBtch).State = EntityState.Modified; line++;
                        db.SaveChanges(); line++;
                    }
                }
                int lastorderno = db.Orders.Where(x => x.StoreId == order.StoreId).Max(x => x.OrderNo); line++;
                var response = new
                {
                    status = 200,
                    message = "Sales Added Successfully",
                    lastorderno = lastorderno,
                    batches = batches,
                    stockBatches = stockBatches,
                    customer = customer
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something Went Wrong",
                    error = new Exception(ex.Message, ex.InnerException),
                    errorline = line
                };
                return Ok(response);
            }
        }

        //05/10/2022
        [HttpPost("SavePurchase")]
        public IActionResult SavePurchase([FromBody] purchasepayload payload, dynamic vendorid, int orderstatusid)
        {
            try
            {
                dynamic purchasejsonformat = JsonConvert.DeserializeObject((string)payload.PurchaseJson);
                dynamic DataAllocation = new { };
                using (SqlConnection myconnn = new SqlConnection(Configuration.GetConnectionString("myconn")))
                {
                    myconnn.Open();
                    try
                    {
                        //string name = purchasejsonformat.VendorDetails.Name.ToStrings();
                        Vendor vendor = new Vendor();
                        vendor = vendorid.ToObject<Vendor>();
                        db.Vendors.Add(vendor);
                        db.SaveChanges();

                        SqlCommand vendors = new SqlCommand("@dbo.HyperPurchase_Entry", myconnn);
                        vendors.CommandType = CommandType.StoredProcedure;
                        vendors.Parameters.Add(new SqlParameter("@purchasejson", payload.PurchaseJson));
                        vendors.Parameters.Add(new SqlParameter("@orderstatusid", orderstatusid));
                        DataSet ds = new DataSet();
                        SqlDataAdapter sqladapter = new SqlDataAdapter(vendors);
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
                    status = 200,
                    msg = "Successfully",
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

        // GET: VendorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VendorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorController/Create
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

        // GET: VendorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VendorController/Edit/5
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

        // GET: VendorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VendorController/Delete/5
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
