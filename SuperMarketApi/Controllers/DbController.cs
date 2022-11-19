using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;

namespace SuperMarketApi.Controllers
{
    public class DbController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public DbController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        // GET: DbController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DbController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DbController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DbController/Create
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

        // GET: DbController/Edit/5
        public POSDbContext getdb()
        {
            return db;
        }

        // POST: DbController/Edit/5
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

        // GET: DbController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DbController/Delete/5
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
