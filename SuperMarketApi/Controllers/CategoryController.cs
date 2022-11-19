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
    public class CategoryController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public CategoryController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpGet("getcategories")]
        public IActionResult getcategories(int companyid, string type)
        {
            try
            {


                List<Category> categories;
                if (type == "A") categories = db.Categories.Where(x => x.CompanyId == companyid).Include(x => x.ParentCategory).ToList();
                else if (type == "P") categories = db.Categories.Where(x => x.CompanyId == companyid && x.ParentCategoryId == null).Include(x => x.ParentCategory).ToList();
                else categories = db.Categories.Where(x => x.CompanyId == companyid && x.ParentCategoryId != null).Include(x => x.ParentCategory).ToList();
                return Ok(categories);

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

        [HttpPost("addcategory")]
        public IActionResult addcategory([FromBody] Category category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                foreach (int id in category.variantgroupids)
                {
                    CategoryVariantGroup categoryVariantGroup = new CategoryVariantGroup();
                    categoryVariantGroup.CategoryId = category.Id;
                    categoryVariantGroup.VariantGroupId = id;
                    db.CategoryVariantGroups.Add(categoryVariantGroup);
                    db.SaveChanges();
                }
                var response = new
                {
                    status = 200,
                    msg = "Category Added Successfully",
                    category = category
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





        [HttpPost("updatecategory")]
        public IActionResult updatecategory([FromBody] Category category)
        {
            try
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                var vargroupids = db.CategoryVariantGroups.Where(x => x.CategoryId == category.Id).Select(x => x.VariantGroupId).ToList();
                foreach (int id in category.variantgroupids)
                {
                    if (!vargroupids.Contains(id))
                    {
                        CategoryVariantGroup categoryVariantGroup = new CategoryVariantGroup();
                        categoryVariantGroup.CategoryId = category.Id;
                        categoryVariantGroup.VariantGroupId = id;
                        db.CategoryVariantGroups.Add(categoryVariantGroup);
                        db.SaveChanges();
                    }
                }
                foreach (int id in vargroupids)
                {
                    if (!category.variantgroupids.Contains(id))
                    {
                        CategoryVariantGroup categoryVariantGroup = db.CategoryVariantGroups.Where(x => x.CategoryId == category.Id && x.VariantGroupId == id).FirstOrDefault();
                        db.CategoryVariantGroups.Remove(categoryVariantGroup);
                        db.SaveChanges();
                    }
                }
                var response = new
                {
                    status = 200,
                    msg = "Category Updated Successfully",
                    category = category
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

        [HttpGet("Index")]
        public IActionResult Index(int companyid)
        {
            try
            {
                var Category = db.Categories.Where(x => x.CompanyId == companyid).ToList();
                return Ok(Category);
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

        [HttpGet("UpdatecategoryAct")]
        public IActionResult UpdateAct(int Id, bool active, int CompanyId)
        {
            try
            {
                var Category = db.Categories.Find(Id);
                Category.isactive = active;
                Category.CompanyId = CompanyId;
                Category.ModifiedDate = DateTime.Now;
                db.Entry(Category).State = EntityState.Modified;
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
        [HttpGet("getcategorybyid")]
        public IActionResult getcategorybyid(int CategoryId)
        {
            var category = db.Categories.Find(CategoryId);
            category.variantgroupids = db.CategoryVariantGroups.Where(x => x.CategoryId == category.Id).Select(x => x.VariantGroupId).ToList();

            return Ok(category);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
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

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
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
