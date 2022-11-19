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
    public class DiningAreaController
    {

        private POSDbContext db;
        public IConfiguration Configuration { get; }

        public DiningAreaController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }

        [HttpGet("Get")]
        [EnableCors("AllowOrigin")]
        public IActionResult Get(int CompanyId)
        {
            try
            {

                var diningarea = (from da in db.DiningAreas
                                  join s in db.Stores on da.StoreId equals s.Id
                                  where da.CompanyId == CompanyId
                                  select new { da.Id, da.Description, s.Name, da.StoreId, store = s.Id }).ToList();
                //var diningarea = db.DiningAreas.Where(v => v.CompanyId == CompanyId).ToList();
                System.Collections.Generic.Dictionary<string, object>[] objData = new System.Collections.Generic.Dictionary<string, object>[diningarea.Count()];

                for (int i = 0; i < diningarea.Count(); i++)
                {
                    objData[i] = new Dictionary<string, object>();
                    objData[i].Add("Id", diningarea[i].Id);
                    objData[i].Add("DiningArea", diningarea[i].Description);
                    objData[i].Add("StoreId", diningarea[i].StoreId);
                    objData[i].Add("StoreName", diningarea[i].Name);
                    string str = "";

                    var dining = db.DiningTables.Where(v => v.DiningAreaId == diningarea[i].Id).ToList();
                    int varCount = dining.Count();
                    for (int j = 0; j < varCount; j++)
                    {
                        if (j < varCount - 1)
                        {
                            str += dining[j].Description + ",";
                        }
                        else
                        {
                            str += dining[j].Description;
                        }

                    }
                    objData[i].Add("DiningTable", str);
                }

                return Ok(objData);
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

        [HttpGet("Delete")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var dining = db.DiningTables.Where(x => x.DiningAreaId == Id).ToList();
                foreach (var item in dining)
                {
                    var opt = db.DiningTables.Find(item.Id);
                    db.DiningTables.Remove(opt);
                }
                var area = db.DiningAreas.Find(Id);
                db.DiningAreas.Remove(area);
                db.SaveChanges();
                var error = new
                {
                    status = "success",
                    data = new
                    {
                        value = 2
                    },
                    msg = "The Data deleted successfully"
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

        private IActionResult Ok(Dictionary<string, object>[] objData)
        {
            throw new NotImplementedException();
        }

        private IActionResult Json(object error)
        {
            throw new NotImplementedException();
        }
    }
}
