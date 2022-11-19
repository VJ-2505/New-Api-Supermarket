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

    public class LiabilityTypesController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public LiabilityTypesController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        [HttpGet("GetLiabilityTypes")]
        public IActionResult GetLiabilityTypes(int companyId)
        {
            try
            {
                var liabilityTypes = db.LiabilityTypes.Where(s => s.CompanyId == companyId).ToList();
                return Ok(liabilityTypes);
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

        [HttpPost("AddLiabilityTypes")]
        public IActionResult AddLiabilityTypes([FromBody] dynamic objdata)
        {
            try
            {
                dynamic jsonObj = objdata;
                LiabilityType liabilityType = jsonObj.ToObject<LiabilityType>();
                db.LiabilityTypes.Add(liabilityType);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "LiabilityType Added Successfully"
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
        [HttpPost("UpdateLiabilityType")]
        public IActionResult UpdateLiabilityType([FromBody] dynamic objData)
        {
            try
            {
                dynamic jsonObj = objData;
                LiabilityType liabilityType = null;
                int id = jsonObj.Id;
                liabilityType = db.LiabilityTypes.Find(id);
                liabilityType.IsOnlinePayment = jsonObj.IsOnlinePayment;
                liabilityType.Description = jsonObj.Description;
                liabilityType.IsActive = jsonObj.IsActive;
                liabilityType.IsVehicle = jsonObj.IsVehicle;
                liabilityType.CompanyId = jsonObj.CompanyId;
                db.Entry(liabilityType).State = EntityState.Modified;
                db.SaveChanges();

                var response = new
                {
                    status = 200,
                    msg = "LiabilityType Updated Successfully"
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
        [HttpGet("GetLiabTypeById")]
        public IActionResult GetLiabTypeById(int id)
        {
            var liabilityType = db.LiabilityTypes.Find(id);

            return Ok(liabilityType);
        }
        [HttpGet("Deactivate")]
        public IActionResult Deactivate(int id)
        {
            var liabilityType = db.LiabilityTypes.Find(id);
            if (liabilityType.IsActive == true)
            {
                liabilityType.IsActive = false;
                db.SaveChanges();
            }
            else
            {
                liabilityType.IsActive = true;
                db.SaveChanges();
            }

            return Ok(liabilityType);
        }

    }
}
