using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class PreferenceController : Controller
    {
        // GET: PreferenceController

        private POSDbContext db;
        private int var_status;
        private string var_msg;
        public IConfiguration Configuration { get; }
        public PreferenceController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("updatepricetype")]
        public IActionResult updatepricetype([FromBody] Preference preference)
        {
            try
            {
                db.Entry(preference).State = EntityState.Modified;
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Taxgroup updated successfully",
                    preference = preference
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

        // GET: PreferenceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PreferenceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreferenceController/Create
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

        // GET: PreferenceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PreferenceController/Edit/5
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

        // GET: PreferenceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PreferenceController/Delete/5
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
