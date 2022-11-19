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
    public class UsersController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }

        public UsersController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers(int companyid)
        {
            try
            {
                var users = db.Users.Where(x => x.CompanyId == companyid).Include(x => x.Role).ToList();
                foreach(var user in users)
                {
                    user.mapped_stores = db.UserStores.Where(x => x.UserId == user.Id).Select(x => x.StoreId).ToList();
                    user.mapped_stores_name = db.UserStores.Where(x => x.UserId == user.Id).Select(x => x.Store.Name).ToList();
                }
                var usersdata = new
                {
                    users = users
                };

                return Ok(usersdata);
            }
            catch (Exception e)
            {
                var error = new
                {
                    Error = new Exception(e.Message, e.InnerException),
                    status = 500,
                    Message = "Opps, Users Data Cannot Get!"
                };
                return Json(error);
            }
        }

        [HttpGet("GetRole")]

        public IActionResult GetRole(int companyId)
        {
            try
            {
                var roles = db.Roles.ToList();

                return Ok(roles);
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

        [HttpGet("Getuser")]

        public IActionResult Get(int companyId)
        {
            try
            {
                var data = new
                {
                    users = db.Users.Where(x => x.CompanyId == companyId).Include(x => x.Role).ToList(),
                    userstores = db.UserStores.Include(x => x.Store).ToList()
                };

                return Ok(data);
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

          [HttpPost("Add")]
        [EnableCors("AllowOrigin")]
        public IActionResult Add([FromBody] JObject data)
        {
            User userstrs = new User();
            try
            { 
                dynamic userJson = data;
                User user = userJson.ToObject<User>();
                if (user.Id == 0)
                {
                    var users = db.Users.Where(x => x.CompanyId == user.CompanyId).ToList();
                    foreach (var usr in users)
                    {
                        if (user.Pin == usr.Pin)
                        {
                            var msg = new
                            {
                                status = 0,
                                msg = "Pin Already Taken Choose Another"
                            };
                            return Ok(msg);
                        }
                    }
                    user.AccountId = db.Accounts.Where(x => x.CompanyId == user.CompanyId).FirstOrDefault().Id;
                    db.Users.Add(user);
                    db.SaveChanges();
                    userstrs = user;
                    JArray userstoresObj = userJson.Stores;
                    if (userstoresObj != null)
                    {
                        dynamic UserStoresJson = userstoresObj.ToList();
                        foreach (int storeid in user.mapped_stores)
                        {
                            if (storeid != 0)
                            {
                                UserStores userstores = new UserStores();
                                userstores.UserId = user.Id;
                                userstores.StoreId = storeid;
                                userstores.CompanyId = user.CompanyId;
                                db.UserStores.Add(userstores);
                                db.SaveChanges();
                            }

                        }
                    }
                }
                else
                {
                    user.AccountId = db.Accounts.Where(x => x.CompanyId == user.CompanyId).FirstOrDefault().Id;
                    var users1 = db.Users.Where(x => x.CompanyId == user.CompanyId && x.Id != user.Id).ToList();
                    foreach (var usr in users1)
                    {
                        if (user.Pin == usr.Pin)
                        {
                            var msg = new
                            {
                                status = 0,
                                msg = "Pin Already Taken Choose Another"
                            };
                            return Ok(msg);
                        }
                    }
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    userstrs = user;
                    JArray userstoresObj = userJson.stores;
                    if (userstoresObj != null)
                    {
                        IEnumerable<dynamic> UserStoresJson = userstoresObj.ToList();
                        foreach (var item in UserStoresJson)
                        {
                            int itemId = item.ToObject<int>();
                            var usrStrs = db.UserStores.Where(x => x.UserId == user.Id && x.StoreId == itemId).FirstOrDefault();
                            if (usrStrs == null)
                            {
                                UserStores userstores = new UserStores();
                                userstores.StoreId = itemId;
                                userstores.UserId = user.Id;
                                userstores.CompanyId = user.CompanyId;
                                db.UserStores.Add(userstores);
                                db.SaveChanges();
                            }
                        }
                        var usrStrs1 = db.UserStores.Where(x => x.UserId == user.Id).ToList();
                        foreach (var str in usrStrs1)
                        {
                            var delustrs = UserStoresJson.Where(x => x == str.StoreId).FirstOrDefault();
                            if (delustrs == null)
                            {
                                var delUserStrs = db.UserStores.Find(str.Id);
                                db.UserStores.Remove(delUserStrs);
                                db.SaveChanges();
                            }
                        }
                    }

                }
                var mesg = new
                {
                    status = 200,
                    msg = "User Successfully Added or Updated",
                    user = userstrs
                };

                return Ok(mesg);
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

        [HttpGet("Deleteuser")]
        [EnableCors("AllowOrigin")]
        public IActionResult Deleteuser(int Id)
        {
            try
            {
                var userstores = db.UserStores.Where(x => x.UserId == Id).ToList();
                // var userroles = db.UserRoles.Where(x => x.Id ==  && x.CompanyId == 1).t
                if (userstores != null)
                {
                    foreach (var item in userstores)
                    {
                        var ustore = db.UserStores.Find(item.Id);
                        db.UserStores.Remove(ustore);
                    }
                }
                var user = db.Users.Find(Id);
                db.Users.Remove(user);
                db.SaveChanges();
                var error = new
                {
                    status = 200,
                    msg = "Delete Successfully"
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
        // GET: UsersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
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

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
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

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
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
