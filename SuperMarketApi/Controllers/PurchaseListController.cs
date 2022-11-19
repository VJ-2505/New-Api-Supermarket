using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;
using System.Data;
using Newtonsoft.Json.Linq;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class PurchaseListController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public PurchaseListController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        // GET: PurchaseListController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PurchaseListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PurchaseListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseListController/Create
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

        // GET: PurchaseListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseListController/Edit/5
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

        // GET: PurchaseListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseListController/Delete/5
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

        [HttpPost("SaveReceivePurchaseList")]
        public IActionResult SaveReceivePurchaseList([FromBody] JArray payload)
        {
            try
            {
                string message = "Order Test As Been Saved";
                int status = 200;
                dynamic orderjsonformat = payload;
                int StoreId = (int)orderjsonformat[0].StoreId;
                dynamic DataAllocation = new { };
                int orderno = 1;
                if (db.PurchaseLists.Where(x => x.StoreId == StoreId).Any())
                {
                    orderno = db.PurchaseLists.Where(x => x.StoreId == StoreId).Max(x => x.OrderNo) + 1;
                }
                foreach (var item in orderjsonformat)
                {
                    PurchaseList list = item.ToObject<PurchaseList>();
                    list.OrderNo = orderno;
                    db.PurchaseLists.Add(list);
                }
                db.SaveChanges();
                var response = new
                {
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
        [HttpGet("purchaselist")]                                      
        public IActionResult paymenttypes(int Storeid)
        {
            List<PurchaseList> purchaselist = db.PurchaseLists.Where(x => x.StoreId == Storeid).ToList();
            return Ok(purchaselist);
        }

        [HttpGet("getbyid")]
        public IActionResult getbyid(int orderNo)
        {
            List<PurchaseList> purchaselist = db.PurchaseLists.Where(x => x.OrderNo == orderNo).ToList();
            return Ok(purchaselist);
        }



        public class OrderPayload
        {
            public string OrderJson { get; set; }
        }
    }
}
