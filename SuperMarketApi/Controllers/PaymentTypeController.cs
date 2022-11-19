using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]

    public class PaymentTypeController : Controller
    {

        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public PaymentTypeController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }

        // GET: PaymentTypesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypesController/Create
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

        // GET: PaymentTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentTypesController/Edit/5
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

        // GET: PaymentTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentTypesController/Delete/5
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

        [HttpGet("getstorepaymenttype")]
        public IActionResult getstorepaymenttype(int storeid)
        {
            //SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            //sqlCon.Open();

            List<StorePaymentType> storePaymentTypes = db.StorePaymentTypes.Where(x => x.StoreId == storeid).ToList();
            return Ok(storePaymentTypes);
        }
    }
}
