using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class TaxGroupController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public TaxGroupController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        // GET: TaxGroupController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TaxGroupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaxGroupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxGroupController/Create
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

        // GET: TaxGroupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaxGroupController/Edit/5
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

        // GET: TaxGroupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaxGroupController/Delete/5
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
        //Master 05-01-2022
        [HttpGet("GetTaxGrp")]
        public IActionResult GetTaxGrp(int CompanyId)
        {
            var taxgroup = db.TaxGroups.Where(x => x.CompanyId == CompanyId).ToList();
            return Ok(taxgroup);
        }
        //Master 06-01-2022
       [HttpPost("AddTaxGrp")]
        public IActionResult AddTaxGrp([FromBody] dynamic taxGroupobj)
        {
            try
            {
                TaxGroup taxGroup = taxGroupobj.ToObject<TaxGroup>();
                db.TaxGroups.Add(taxGroup);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "TaxGrp added successfully",
                    taxgroup = taxGroup
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

       
        //Master 06-01-2022
        [HttpPost("UpdateTaxGrp")]
        public IActionResult UpdateTaxGrp([FromBody] dynamic taxGroupobj)
        {
            try
            {
                TaxGroup taxGroup = taxGroupobj.ToObject<TaxGroup>();
                db.Entry(taxGroup).State = EntityState.Modified;
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "TaxGrp updated successfully",
                    taxgroup = taxGroup
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

       
        [HttpGet("GetAddtional")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetAddtional(int CompanyId)
        {
            try
            {
                var prod = new
                {
                    taxGroup = db.TaxGroups.Where(o => o.CompanyId == CompanyId).ToList(),
                    addtncharges = db.AdditionalCharges.Where(o => o.CompanyId == CompanyId).ToList(),
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

        [HttpPost("Addadditional")]
        public IActionResult Addadditional([FromBody] dynamic additionalchargesobj)
        {
            try
            {
                AdditionalCharges additionalcharges = additionalchargesobj.ToObject<AdditionalCharges>();
                db.AdditionalCharges.Add(additionalcharges);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Additional charge added successfully",
                    additionalcharges = additionalcharges
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

        [HttpPost("Updateadditional")]
        public IActionResult Updateadditional([FromBody] dynamic additionalobj)
        {
            try
            {
                AdditionalCharges additionalcharges = additionalobj.ToObject<AdditionalCharges>();
                db.Entry(additionalcharges).State = EntityState.Modified;
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Additional updated successfully",
                    taxgroup = additionalcharges
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

        //[HttpPost("Updateadditional")]
        //public IActionResult Updateadditional([FromBody] JObject data)
        //{
        //    try
        //    {
        //        dynamic Addchrgs = data;
        //        AdditionalCharges additionalCharges = Addchrgs.ToObject<AdditionalCharges>();
        //        additionalCharges.CreatedDate = db.AdditionalCharges.Where(x => x.Id == additionalCharges.Id).AsNoTracking().FirstOrDefault().CreatedDate;
        //        additionalCharges.ModifiedDate = DateTime.Now;
        //        db.Entry(additionalCharges).State = EntityState.Modified;
        //        db.SaveChanges();
        //        var error = new
        //        {
        //            status = "success",
        //            data = new
        //            {
        //                value = 2
        //            },
        //            msg = "The AdditionalCharges updated successfully"
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


    }
}
