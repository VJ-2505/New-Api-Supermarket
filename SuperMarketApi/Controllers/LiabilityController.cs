using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]

    public class LiabilityController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public LiabilityController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        [HttpGet("GetLiability")]
        public IActionResult GetLiability(int companyId)
        {
            try
            {
                var response = new
                {
                    liability = db.Liabilities.Where(x => x.CompanyId == companyId).ToList(),
                    vendor = db.Vendors.Where(c => c.CompanyId == companyId).ToList(),
                    contact = db.Contacts.Where(c => c.CompanyId == companyId).ToList(),
                    store = db.Stores.Where(c => c.CompanyId == companyId).ToList()
                };
                return Json(response);
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

        [HttpPost("AddLiability")]
        public IActionResult AddLiability([FromBody] dynamic objdata)
        {
            try
            {
                dynamic jsonObj = objdata;
                Liability liability = jsonObj[0].ToObject<Liability>();
                db.Liabilities.Add(liability);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Liability Added Successfully"
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
        [HttpPost("UpdateLiability")]
        public IActionResult UpdateLiability([FromBody] dynamic objdata)
        {
            try
            {
                dynamic jsonObj = objdata;
                Liability liability = null;
                int id = jsonObj[0].id;
                liability = db.Liabilities.Find(id);
                 liability = jsonObj[0].ToObject<Liability>();
                liability.LiabilityTypeId = jsonObj[0].LiabilityTypeId;
                liability.Description = jsonObj[0].Description;
                liability.IsActive = jsonObj[0].IsActive;
                liability.ContactId = jsonObj[0].ContactId;
                liability.StoreId = jsonObj[0].StoreId;
                liability.Count = jsonObj[0].Count;
                liability.VendorId = jsonObj[0].VendorId;
                liability.CompanyId = jsonObj[0].CompanyId;
                db.Entry(liability).State = EntityState.Modified;
                db.SaveChanges();
               
                var response = new
                {
                    status = 200,
                    msg = "Liability Updated Successfully"
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
        [HttpGet("GetLiabilityById")]
        public IActionResult GetLiabilityById(int id)
        {
            //var liability = db.Liabilities.Find(id);
      var liability = from t in db.Liabilities
                  join c in db.Contacts on t.ContactId equals c.Id
                  join s in db.Stores on t.StoreId equals s.Id
                  join v in db.Vendors on t.VendorId equals v.Id
                      join lt in db.LiabilityTypes on t.LiabilityTypeId equals lt.Id
                      where (t.Id == id)
                  select new
                  {
                    t.IsActive,  t.IsOnlinePayment,t.LiabilityType,t.LiabilityTypeId,
                    t.Store,t.StoreId,t.Vendor,t.VendorId,t.CompanyId,
                    t.ContactId,t.Contact,t.Count,t.Description

                  };

      return Ok(liability);
        }
        [HttpGet("Deactivate")]
        public IActionResult Deactivate(int id)
        {
            var liability = db.Liabilities.Find(id);
            if (liability.IsActive == true)
            {
                liability.IsActive = false;
                db.SaveChanges();
            }
            else
            {
                liability.IsActive = true;
                db.SaveChanges();
            }

            return Ok(liability);
        }


    }
}
