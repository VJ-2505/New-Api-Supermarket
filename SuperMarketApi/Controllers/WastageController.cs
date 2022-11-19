using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class WastageController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }

        public WastageController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }

        [HttpGet("Getwastages")]
        [EnableCors("AllowOrigin")]
        public IActionResult Getwastages(int CompanyId)
        {
            try
            {
                var prod = new
                {
                    product = db.Products.Where(o => o.CompanyId == CompanyId).ToList(),    
                    wastages = db.Wastages.Where(o => o.CompanyId == CompanyId).ToList(),
                };
                return Json(prod);
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

        [HttpPost("Addwastages")]
        public IActionResult Addwastages([FromBody] dynamic wastagesobj)
        {
            try
            {
                Wastage wastages = wastagesobj.ToObject<Wastage>();
                db.Wastages.Add(wastages);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Wastage  added successfully",
                    wastages = wastages
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "OOPS! Something went wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }



        // GET: WastageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WastageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WastageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WastageController/Create
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

        // GET: WastageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WastageController/Edit/5
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

        // GET: WastageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WastageController/Delete/5
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
