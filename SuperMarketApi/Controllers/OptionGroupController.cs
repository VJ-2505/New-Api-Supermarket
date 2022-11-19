using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class OptionGroupController : Controller
    {

        public IConfiguration Configuration { get; }
        private POSDbContext db;


        public OptionGroupController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        // GET: OptionGroupController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("Get")]
        [EnableCors("AllowOrigin")]
        public IActionResult Get(int CompanyId)
        {
            try
            {
                var optionGroups = db.OptionGroups.Where(v => v.CompanyId == CompanyId).ToList();
                System.Collections.Generic.Dictionary<string, object>[] objData = new System.Collections.Generic.Dictionary<string, object>[optionGroups.Count()];

                //var variant = db.Variants.ToList();
                for (int i = 0; i < optionGroups.Count(); i++)
                {
                    objData[i] = new Dictionary<string, object>();
                    objData[i].Add("Id", optionGroups[i].Id);
                    objData[i].Add("OptionGroup", optionGroups[i].Name);
                    objData[i].Add("isactive", optionGroups[i].isactive);
                    string str = "";

                    var options = db.Options.Where(v => v.OptionGroupId == optionGroups[i].Id).ToList();
                    int varCount = options.Count();
                    for (int j = 0; j < varCount; j++)
                    {
                        if (j < varCount - 1)
                        {
                            str += options[j].Name + ",";
                        }
                        else
                        {
                            str += options[j].Name;
                        }

                    }
                    objData[i].Add("Options", str);
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

        [HttpPost("CreateOption")]
        [EnableCors("AllowOrigin")]
        public IActionResult CreateOption([FromBody] JObject data)
        {
            try
            {
                dynamic orderJson = data;
                {
                    OptionGroup optionGroup = orderJson.ToObject<OptionGroup>();
                    optionGroup.CreatedDate = DateTime.Now;
                    optionGroup.ModifiedDate = DateTime.Now;
                    db.OptionGroups.Add(optionGroup);
                    db.SaveChanges();
                    JArray itemObj = orderJson.Options;
                    dynamic itemJson = itemObj.ToList();
                    foreach (var item in itemJson)
                    {
                        Option option = item.ToObject<Option>();
                        option.OptionGroupId = optionGroup.Id;
                        option.CreatedDate = DateTime.Now;
                        option.ModifiedDate = DateTime.Now;
                        option.CompanyId = optionGroup.CompanyId;
                        db.Options.Add(option);
                        db.SaveChanges();
                        var stores = db.Stores.Where(x => x.CompanyId == optionGroup.CompanyId).ToList();
                        foreach (var store in stores)
                        {
                            StoreOption storeOption = new StoreOption();
                            storeOption.CompanyId = optionGroup.CompanyId;
                            storeOption.CreatedDate = DateTime.Now;
                            storeOption.ModifiedDate = DateTime.Now;
                            storeOption.StoreId = store.Id;
                            storeOption.OptionId = option.Id;
                            storeOption.IsActive = true;
                            storeOption.Price = option.Price;
                            storeOption.TakeawayPrice = option.Price;
                            storeOption.DeliveryPrice = option.Price;
                            storeOption.UPPrice = option.Price;
                            db.StoreOptions.Add(storeOption);
                            db.SaveChanges();
                        }
                    }
                    var error = new
                    {
                        status = "success",
                        data = new
                        {
                            value = 2
                        },
                        msg = "The OptionGroup added successfully"
                    };

                    return Json(error);
                }
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

        [HttpGet("GetById")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var optionGroups = db.OptionGroups.Find(Id);
                System.Collections.Generic.Dictionary<string, object>[] objData = new System.Collections.Generic.Dictionary<string, object>[1];

                var option = db.Options.Where(v => v.OptionGroupId == Id).ToList();
                objData[0] = new Dictionary<string, object>();
                objData[0].Add("Id", optionGroups.Id);
                objData[0].Add("OptionGroup", optionGroups.Name);
                objData[0].Add("OptionGroupType", optionGroups.OptionGroupType);
                objData[0].Add("Description", optionGroups.Description);
                objData[0].Add("MinimumSelectable", optionGroups.MinimumSelectable);
                objData[0].Add("MaximumSelectable", optionGroups.MaximumSelectable);
                //string str = "";
                //for (int j = 0; j < variant.Count(); j++)
                //{
                //    str += variant[j].Description + ",";
                //}
                objData[0].Add("Options", option);


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

        [HttpPost("Update")]
        [EnableCors("AllowOrigin")]
        public IActionResult Update([FromBody] JObject Data)
        {
            try
            {
                dynamic orderJson = Data;
                OptionGroup optionGroup = orderJson.ToObject<OptionGroup>();
                optionGroup.CreatedDate = db.OptionGroups.Where(x => x.Id == optionGroup.Id).AsNoTracking().FirstOrDefault().CreatedDate;
                optionGroup.ModifiedDate = DateTime.Now;
                db.Entry(optionGroup).State = EntityState.Modified;
                db.SaveChanges();
                JArray itemObj = orderJson.Options;
                JArray itemDel = orderJson.Del;
                dynamic itemJson = itemObj.ToList();
                dynamic itemJsonDel = itemDel.ToList();
                foreach (var item in itemJson)
                {
                    if (item.Id == 0)
                    {
                        Option option = item.ToObject<Option>();
                        option.CreatedDate = DateTime.Now;
                        option.ModifiedDate = DateTime.Now;
                        option.TakeawayPrice = option.Price;
                        option.DeliveryPrice = option.Price;
                        option.UPPrice = option.Price;
                        db.Options.Add(option);
                        db.SaveChanges();

                        var stores = db.Stores.Where(x => x.CompanyId == option.CompanyId).ToList();
                        foreach (var store in stores)
                        {
                            StoreOption storeOption = new StoreOption();
                            storeOption.Price = option.Price;
                            storeOption.StoreId = store.Id;
                            storeOption.OptionId = option.Id;
                            storeOption.CompanyId = option.CompanyId;
                            storeOption.IsActive = false;
                            storeOption.ModifiedDate = DateTime.Now;
                            storeOption.CreatedDate = DateTime.Now;
                            storeOption.TakeawayPrice = option.Price;
                            storeOption.DeliveryPrice = option.Price;
                            storeOption.UPPrice = option.Price;
                            db.StoreOptions.Add(storeOption);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Option option = item.ToObject<Option>();
                        option.CreatedDate = db.Options.Where(x => x.Id == option.Id).AsNoTracking().FirstOrDefault().CreatedDate;
                        option.ModifiedDate = DateTime.Now;
                        option.TakeawayPrice = option.Price;
                        option.DeliveryPrice = option.Price;
                        option.UPPrice = option.Price;
                        db.Entry(option).State = EntityState.Modified;
                        db.SaveChanges();


                        var stores = db.StoreOptions.Where(x => x.OptionId == option.Id && x.CompanyId == option.CompanyId).ToList();
                        foreach (var store in stores)
                        {
                            StoreOption storeOption = store;
                            storeOption.Price = option.Price;
                            storeOption.ModifiedDate = DateTime.Now;
                            storeOption.TakeawayPrice = option.TakeawayPrice;
                            storeOption.DeliveryPrice = option.DeliveryPrice;
                            storeOption.UPPrice = option.UPPrice;
                            db.Entry(storeOption).State = EntityState.Modified;
                            db.SaveChanges();
                        }

                    }

                }
                foreach (var item in itemJsonDel)
                {
                    int itemId = item.Id.ToObject<int>();
                    Option option = db.Options.Find(itemId);
                    var stores = db.StoreOptions.Where(x => x.OptionId == option.Id && x.CompanyId == option.CompanyId).ToList();
                    foreach (var store in stores)
                    {
                        StoreOption storeOption = store;
                        db.StoreOptions.Remove(storeOption);
                        db.SaveChanges();
                    }
                    db.Options.RemoveRange(option);
                    db.SaveChanges();

                }
                var error = new
                {
                    status = "success",
                    data = new
                    {
                        value = 2
                    },
                    msg = "The OptionData Updated successfully"
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
        public IActionResult UpdateAct(int Id, bool active)
        {
            try
            {
                var options = db.OptionGroups.Find(Id);
                options.isactive = active;
                db.Entry(options).State = EntityState.Modified;
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

        // GET: OptionGroupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OptionGroupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OptionGroupController/Create
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

        // GET: OptionGroupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OptionGroupController/Edit/5
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

        // GET: OptionGroupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OptionGroupController/Delete/5
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
