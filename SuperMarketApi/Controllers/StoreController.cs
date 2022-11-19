using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperMarketApi.Models;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]

    public class StoreController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public StoreController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }

        [HttpGet("GetLocation")]
        public IActionResult GetLocation(int companyId)
        {
            try
            {
                var store = db.Stores.Where(s => s.CompanyId == companyId).ToList();
                return Ok(store);
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
        [HttpPost("AddLocation")]
        public IActionResult AddLocation([FromBody] dynamic objdata)
        {
            try
            {
                dynamic jsonObj = objdata;
                Store store = jsonObj.ToObject<Store>();
                db.Stores.Add(store);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Location Added Successfully"
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
        [HttpGet("GetStoreById")]
        public IActionResult GetStoreById(int id)
        {
            var store = db.Stores.Find(id);
            return Ok(store);
        }
        [HttpPost("UpdateStore")]
        public IActionResult UpdateStore([FromBody] dynamic objData)
        {
            try
            {
                dynamic jsonObj = objData;
                Store store = null;
                int id = jsonObj.Id;
                store = db.Stores.Find(id);
                store.Name = jsonObj.Name;
                store.ContactNo = jsonObj.ContactNo;
                store.Email= jsonObj.Email;
                store.PostalCode= jsonObj.PostalCode;
                store.isactive = jsonObj.IsActive;
                store.OpeningTime = jsonObj.OpeningTime;
                store.ClosingTime = jsonObj.ClosingTime;
                store.Address = jsonObj.Address;
                store.City = jsonObj.City;
                store.Country = jsonObj.Country;
                store.CompanyId = jsonObj.CompanyId;
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

                var response = new
                {
                    status = 200,
                    msg = "store Updated Successfully"
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

        [HttpGet("Deactivate")]
        public IActionResult Deactivate(int id)
        {
            var store = db.Stores.Find(id);
            if (store.isactive == true)
            {
                store.isactive = false;
                db.SaveChanges();
            }
            else
            {
                store.isactive = true;
                db.SaveChanges();
            }

            return Ok(store);
        }

        [HttpGet("Get")]
        public IActionResult Get(int CompanyId)
        {
            try
            {
                var stores = db.Stores.Where(s => s.CompanyId == CompanyId).ToList();
                return Ok(stores);
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

        public interface payload
        {
            string data { get; set; }
        }
        [HttpPost("AddStore")]
        [EnableCors("AllowOrigin")]
        public IActionResult AddStore([FromBody]Store store)
        {
            try
            {
                //dynamic _data = data;
                //dynamic outlet = JsonConvert.DeserializeObject(_data.data);

                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.storeoutlet", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.Add(new SqlParameter("@companyId", store.CompanyId));
                cmd.Parameters.Add(new SqlParameter("@name", store.Name));
                cmd.Parameters.Add(new SqlParameter("@address", store.Address));
                cmd.Parameters.Add(new SqlParameter("@city", store.City));
                cmd.Parameters.Add(new SqlParameter("@GSTno", store.GSTno));
                cmd.Parameters.Add(new SqlParameter("@phoneNo", store.ContactNo));
                cmd.Parameters.Add(new SqlParameter("@emailId", store.Email));
                cmd.Parameters.Add(new SqlParameter("@postalcode", store.PostalCode));

                int success = cmd.ExecuteNonQuery();
                sqlCon.Close();
                var error = new
                {
                    status = 200,
                    msg = "The data added successfully"
                };

                return Json(error);
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

        [HttpPost("UpdateData")]
        public IActionResult UpdateData([FromBody] Store store)
        {
            try
            {
                
                //Store Store = outlet.ToObject<Store>();
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

                var error = new
                {
                    status = 200,
                    msg = "The Store updated successfully"
                };

                return Json(error);
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

        [HttpGet("UpdateAct")]
        [EnableCors("AllowOrigin")]
        public IActionResult UpdateAct(int id, bool active)
        {
            try
            {
                var stores = db.Stores.Find(id);
                stores.isactive = active;
                db.Entry(stores).State = EntityState.Modified;
                db.SaveChanges();
                var error = new
                {
                    status = "success",
                    data = new
                    {
                        value = 2
                    },
                    msg = "The data updated successfully"
                };

                return Json(error);
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



        public IActionResult Index()
        {
            return View();
        }

    }
}
