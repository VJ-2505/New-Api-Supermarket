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

    public class MaintBillTypesController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public MaintBillTypesController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        [HttpGet("GetMaintBillTypes")]
        public IActionResult GetMaintBillTypes(int companyId)
        {
           return Json(db.MaintBillTypes.Where(x => x.CompanyId == companyId).ToList());

            //try
            //{
            //    var maintBillTypes = db.MaintBillTypes.Where(s => s.CompanyId == companyId).ToList();
            //    return Ok(maintBillTypes);
            //}
            //catch (Exception ex)
            //{
            //    var response = new
            //    {
            //        status = 0,
            //        msg = "Something went wrong",
            //        error = new Exception(ex.Message, ex.InnerException)
            //    };
            //    return Ok(response);
            //}
        }

        [HttpPost("AddMaintBillType")]
        public IActionResult AddMaintBillType([FromBody] dynamic objdata)
        {
            try
            {
                dynamic jsonObj = objdata;
                MaintBillType maintBillType = jsonObj[0].ToObject<MaintBillType>();
                db.MaintBillTypes.Add(maintBillType);
                db.SaveChanges();              
                var response = new
                {
                    status = 200,
                    msg = "MaintBillType Added Successfully"
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

        [HttpPost("UpdateMaintBillType")]
        public IActionResult UpdateMaintBillType([FromBody] dynamic objdata)
        {
            try
            {
                dynamic jsonObj = objdata;
                MaintBillType maintBillType = null;
                int id = jsonObj[0].id;
                maintBillType = db.MaintBillTypes.Find(id);
                maintBillType.LiabilityTypeId = jsonObj[0].LiabilityTypeId;
                maintBillType.Description = jsonObj[0].Description;
                maintBillType.IsActive = jsonObj[0].IsActive;
                maintBillType.IsVerify = jsonObj[0].IsVerify;
                maintBillType.CompanyId = jsonObj[0].CompanyId;
                db.Entry(maintBillType).State = EntityState.Modified;
                db.SaveChanges();
           
                var response = new
                {
                    status = 200,
                    msg = "MaintBillType Updated Successfully"
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
        [HttpGet("GetMaintBillTypeById")]
        public IActionResult GetMaintBillTypeById(int id)
        {
            //var maintBillType = db.MaintBillTypes.Find(id);

      var maintBillType = from t in db.MaintBillTypes
                      join lt in db.LiabilityTypes on t.LiabilityTypeId equals lt.Id
                      where (t.Id == id)
                      select new
                      {
                        t.IsActive,
                        t.LiabilityType,
                        t.LiabilityTypeId,
                        t.Description,
                        t.CompanyId,
                        t.IsVerify,
                        t.Id
                      };


      return Ok(maintBillType);
        }

        [HttpGet("Deactivate")]
        public IActionResult Deactivate(int id)
        {
            var maintBillType = db.MaintBillTypes.Find(id);
            if (maintBillType.IsActive == true)
            {
                maintBillType.IsActive = false;
                db.SaveChanges();
            }
            else
            {
                maintBillType.IsActive = true;
                db.SaveChanges();
            }

            return Ok(maintBillType);
        }

    }
}
