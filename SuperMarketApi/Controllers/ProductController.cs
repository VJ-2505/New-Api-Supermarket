using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarketApi.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Collections;
using Microsoft.AspNetCore.Http;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private POSDbContext db;
        private int var_status;
        private int var_value;
        private string var_msg;

        public IConfiguration Configuration { get; }
        public ProductController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }

        // GET: View Product_Table_Data
        [HttpGet("viewData")]
        public IActionResult Indexdata()
        {
            return Json(db.Products.ToList());
        }

        [HttpGet("adbarcodes")]
        public IActionResult adbarcodes(int productid)
        {
            Product product = db.Products.Find(productid);
            var variantgroups = db.CategoryVariantGroups.Where(x => x.CategoryId == product.CategoryId).ToList();
            Barcode barcode = new Barcode();
            barcode.ProductId = productid;
            db.Barcodes.Add(barcode);
            db.SaveChanges();
            foreach (var vg in variantgroups)
            {
                foreach (var v in db.Variants.Where(x => x.VariantGroupId == vg.Id).ToList())
                {
                    BarcodeVariant barcodeVariant = new BarcodeVariant();
                    barcodeVariant.BarcodeId = barcode.Id;
                    barcodeVariant.VariantId = v.Id;
                    db.BarcodeVariants.Add(barcodeVariant);
                    db.SaveChanges();
                }
            }
            return Ok(200);
        }


        // Add Products
        [HttpGet("addData")]
        public IActionResult addData([FromBody] Product data)
        {
            try
            {
                db.Products.Add(data);
                db.SaveChanges();
                Product product = db.Products.Find(data.Id);
                var variantgroups = db.CategoryVariantGroups.Where(x => x.CategoryId == product.CategoryId).ToList();
                Barcode barcode = new Barcode();
                barcode.ProductId = data.Id;
                db.Barcodes.Add(barcode);
                db.SaveChanges();
                foreach (var vg in variantgroups)
                {
                    foreach (var v in db.Variants.Where(x => x.VariantGroupId == vg.Id).ToList())
                    {
                        BarcodeVariant barcodeVariant = new BarcodeVariant();
                        barcodeVariant.BarcodeId = barcode.Id;
                        barcodeVariant.VariantId = v.Id;
                        db.BarcodeVariants.Add(barcodeVariant);
                        db.SaveChanges();
                    }
                }
                int compId = product.CompanyId;
                int productId = product.Id;
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.StoreProduct", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CompanyId", compId));
                cmd.Parameters.Add(new SqlParameter("@productId", productId));
                int success = cmd.ExecuteNonQuery();
                sqlCon.Close();

                var response = new
                {
                    status = 200,
                    message = "Value Added Successfull"
                };
                return Ok(response);

            }
            catch (Exception)
            {
                throw;
            }
        }


        // View Products
        [HttpGet("getProduct")]
        public IActionResult getProduct(int CompanyId, int StoreId)
        {
            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand("dbo.retriveProduct", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CompanyId", CompanyId));
            cmd.Parameters.Add(new SqlParameter("@StoreId", StoreId));

            DataSet ds = new DataSet();
            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            sqlAdp.Fill(ds);

            var response = new
            {
                Product = ds.Tables[0]
            };
            return Ok(response);
        }

        [HttpPost("addProduct")]
        public IActionResult addProduct([FromBody] dynamic data, int userid, int storeid)
        {
            try
            {
                int productid;
                Product product = data.product.ToObject<Product>();
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.CreateProduct", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@companyid", product.CompanyId));
                cmd.Parameters.Add(new SqlParameter("@name", product.Name));
                cmd.Parameters.Add(new SqlParameter("@description", product.Description));
                cmd.Parameters.Add(new SqlParameter("@unitid", product.UnitId));
                cmd.Parameters.Add(new SqlParameter("@categoryid", product.CategoryId));
                cmd.Parameters.Add(new SqlParameter("@taxgroupid", product.TaxGroupId));
                //cmd.Parameters.Add(new SqlParameter("@kotgroupid", product.KOTGroupId));
                cmd.Parameters.Add(new SqlParameter("@producttypeid", product.ProductTypeId));
                cmd.Parameters.Add(new SqlParameter("@price", product.Price));
                cmd.Parameters.Add(new SqlParameter("@imgurl", product.ImgUrl));
                cmd.Parameters.Add(new SqlParameter("@code", product.ProductCode));
                cmd.Parameters.Add(new SqlParameter("@barcode", product.BarCode));
                cmd.Parameters.Add(new SqlParameter("@brand", product.brand));
                cmd.Parameters.Add(new SqlParameter("@userid", userid));
                // cmd.Parameters.Add(new SqlParameter("@storeId", sid.StoreId));


                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                DataRow table = ds.Tables[0].Rows[0];
                productid = (int)table["ProductId"];
                sqlCon.Close();
                if (data.variantcombinations.Count > 0)
                {
                    foreach (dynamic cmb in data.variantcombinations)
                    {
                        Barcode barcode = new Barcode();
                        barcode.ProductId = productid;
                        barcode.Updated = true;
                        barcode.BarCode = cmb.barcode;
                        db.Barcodes.Add(barcode);
                        db.SaveChanges();
                        List<Store> stores = db.Stores.Where(x => x.CompanyId == product.CompanyId).ToList();
                        foreach (Store store in stores)
                        {
                            Stock stock = new Stock();
                            stock.BarcodeId = barcode.Id;
                            stock.CompanyId = product.CompanyId;
                            stock.CreatedBy = userid;
                            stock.CreatedDate = DateTime.Now;
                            stock.ProductId = productid;
                            stock.SortOrder = -1;
                            stock.StorageStoreId = store.Id;
                            stock.StoreId = store.Id;
                            stock.StorageStoreName = store.Name;
                            db.Stocks.Add(stock);
                            db.SaveChanges();
                        }
                        foreach (int id in cmb.variantids)
                        {
                            BarcodeVariant barcodeVariant = new BarcodeVariant();
                            barcodeVariant.BarcodeId = barcode.Id;
                            barcodeVariant.Updated = true;
                            barcodeVariant.VariantId = id;
                            db.BarcodeVariants.Add(barcodeVariant);
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    Barcode barcode = new Barcode();
                    barcode.ProductId = productid;
                    barcode.Updated = true;
                    barcode.BarCode = product.BarCode;
                    db.Barcodes.Add(barcode);
                    db.SaveChanges();
                    List<Store> stores = db.Stores.Where(x => x.CompanyId == product.CompanyId).ToList();
                    foreach (Store store in stores)
                    {
                        Stock stock = new Stock();
                        stock.BarcodeId = barcode.Id;
                        stock.CompanyId = product.CompanyId;
                        stock.CreatedBy = userid;
                        stock.CreatedDate = DateTime.Now;
                        stock.ProductId = productid;
                        stock.SortOrder = -1;
                        stock.StorageStoreId = store.Id;
                        stock.StoreId = store.Id;
                        stock.StorageStoreName = store.Name;
                        db.Stocks.Add(stock);
                        db.SaveChanges();
                    }
                }

                sqlCon.Open();

                SqlCommand cmd1 = new SqlCommand("dbo.BarcodeProduct", sqlCon);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add(new SqlParameter("@CompanyId", product.CompanyId));
                cmd1.Parameters.Add(new SqlParameter("@storeid", storeid));

                DataSet ds1 = new DataSet();
                SqlDataAdapter sqlAdp1 = new SqlDataAdapter(cmd1);
                sqlAdp1.Fill(ds1);
                sqlCon.Close();
                var response = new
                {
                    msg = "Product Added Successfully",
                    product = db.Products.Find(productid),
                    stocks = ds1.Tables[0]
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


        [HttpGet("GetPrice")]
        public IActionResult GetPrice(int storeId)
        {
            var prod = new
            {
                streprd = from sp in db.StoreProducts
                          join p in db.Products on sp.ProductId equals p.Id
                          where sp.StoreId == storeId
                          select new { p.Name, p.Description, sp.Price, sp.TakeawayPrice, sp.DeliveryPrice, sp.StoreId, sp.CompanyId, sp.ProductId, sp.Id, sp.SortOrder, sp.Recommended },
                streopt = from os in db.StoreOptions
                          join o in db.Options on os.OptionId equals o.Id
                          where os.StoreId == storeId
                          select new { o.Name, os.Price, os.TakeawayPrice, os.DeliveryPrice, os.StoreId, os.CompanyId, os.Id, os.OptionId }
            };
            return Json(prod);
        }

        // POST api/<controller>
        [HttpPost("Update")]
        public IActionResult UpdatePrd([FromForm] string data)
        {
            try
            {
                dynamic prod = JsonConvert.DeserializeObject(data);
                foreach (var item in prod)
                {
                    StoreProduct storeProduct = item.ToObject<StoreProduct>();
                    storeProduct.IsDineInService = true;
                    storeProduct.IsDeliveryService = true;
                    storeProduct.IsTakeAwayService = true;
                    storeProduct.UPPrice = storeProduct.Price;
                    storeProduct.CreatedDate = DateTime.Now;
                    storeProduct.ModifiedDate = DateTime.Now;
                    storeProduct.SyncedAt = DateTime.Now;
                    storeProduct.IsActive = true;
                    db.Entry(storeProduct).State = EntityState.Modified;
                    db.SaveChanges();
                }
                var error = new
                {
                    status = 200,
                    msg = "Price Book Succefully Updated"
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

        [HttpPost("UpdateOption")]
        public IActionResult UpdateOption([FromForm] string data)
        {
            dynamic optn = JsonConvert.DeserializeObject(data);
            foreach (var item in optn)
            {
                StoreOption storeOption = item.ToObject<StoreOption>();
                storeOption.CreatedDate = DateTime.Now;
                storeOption.ModifiedDate = DateTime.Now;
                storeOption.IsActive = true;
                db.Entry(storeOption).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Ok(new { status = 200 });
        }





        [HttpPost("AddProductFB")]
        public IActionResult AddProductFB([FromForm] string objData, IFormFile image)
        {
            dynamic orderJson = JsonConvert.DeserializeObject(objData);
            try
            {
                if (orderJson.KOTGroupId == 0)
                {
                    orderJson.KOTGroupId = null;
                }
                Product product = orderJson.ToObject<Product>();
                product.CreatedDate = DateTime.Now;
                product.ModifiedDate = DateTime.Now;
                // product.UPPrice = product.Price;
                product.Name = product.Name;
                product.Description = product.Description;
                product.BarCode = product.BarCode;
                if (image != null)
                    product.ImgUrl = ImageUpload(product.CompanyId, image);
                db.Products.Add(product);               
                db.SaveChanges();
                
                JArray OptionGroupJson = orderJson.ProductOptionGroups;
                if (OptionGroupJson != null)
                {
                    dynamic optionGroups = OptionGroupJson.ToList();
                    foreach (var item in optionGroups)
                    {
                        int itemId = item.ToObject<int>();
                        if (item != 0)
                        {
                            ProductOptionGroup productOptionGroup = new ProductOptionGroup();
                            productOptionGroup.ProductId = product.Id;
                            productOptionGroup.OptionGroupId = item;
                            productOptionGroup.CompanyId = product.CompanyId;
                            productOptionGroup.CreatedDate = DateTime.Now;
                            productOptionGroup.ModifiedDate = DateTime.Now;
                            db.ProductOptionGroups.Add(productOptionGroup);
                            db.SaveChanges();
                            //if (akountzCompId.HasValue) AddProdInAkountz(product.Id, product.CompanyId, akountzCompId);
                        }
                    }
                }


                int compId = product.CompanyId;
                int productId = product.Id;            
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.StoreProductFB", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@compId", compId));
                cmd.Parameters.Add(new SqlParameter("@productId", productId));


                Barcode barcode = new Barcode();
                barcode.ProductId = product.Id;
                barcode.Updated = true;
                barcode.BarCode = product.BarCode;
                db.Barcodes.Add(barcode);
              
                db.SaveChanges();

                List<Store> stores = db.Stores.Where(x => x.CompanyId == product.CompanyId).ToList();
                foreach (Store store in stores)
                {
                    Stock stock = new Stock();
                    stock.CompanyId = product.CompanyId;
                    stock.CreatedDate = DateTime.Now;
                    stock.BarcodeId = barcode.Id;
                    stock.ProductId = product.Id;
                    stock.SortOrder = -1;
                    stock.StorageStoreId = store.Id;
                    stock.StoreId = store.Id;
                    stock.StorageStoreName = store.Name;
                    db.Stocks.Add(stock);
                    db.SaveChanges();
                }



                int success = cmd.ExecuteNonQuery();

                var_status = 200;
                var_value = product.Id;
                var_msg = "Product added Successfully";
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                var error = new
                {
                    error = new Exception(ex.Message, ex.InnerException),
                    status = 0,
                    msg = "Something went wrong  Contact our service provider"
                };
                return Json(error);
            }
            var response = new
            {
                status = var_status,
                data = new
                {
                    value = var_value
                },
                msg = var_msg
            };
            return Json(response);

        }

        private void AddProdInAkountz(int id, int companyId, int? akountzCompId)
        {
            throw new NotImplementedException();
        }

        private string ImageUpload(int companyId, IFormFile image)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("deleteData")]
        public IActionResult deleteData(int Id)
        {
            db.Products.Remove(db.Products.Find(Id));
            db.SaveChanges();
            var responce = new
            {
                status = 500,
                message = "Value Deleted Successfull!"
            };
            return Ok(responce);
        }

        [HttpPost("updateProduct")]
        public IActionResult updateProduct([FromBody] dynamic data, int userid)
        {
            try
            {
                Product product = data.product.ToObject<Product>();
                Product oldproduct = db.Products.AsNoTracking().Where(x => x.Id == product.Id).FirstOrDefault();
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                List<Barcode> barcodes = db.Barcodes.Where(x => x.ProductId == product.Id).ToList();
                foreach (Barcode barcode in barcodes)
                {
                    barcode.BarCode = product.BarCode;
                    db.Entry(barcode).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (oldproduct.CategoryId != product.CategoryId)
                {
                    productcategorychange(product.Id, data.variantcombinations);
                }
                else
                {
                    barcodedetailsupdate(product.Id, data.variantcombinations);
                }
                var response = new
                {
                    msg = "Product Added Successfully",
                    product = product
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

        [HttpPost("UpdateFB")]
        [EnableCors("AllowOrigin")]
        public IActionResult UpdateFB([FromForm]string objData, IFormFile image)
        {
            try
            {
                dynamic rawJson = JsonConvert.DeserializeObject(objData);
                dynamic orderJson = rawJson.ToObject<Product>();
                if (orderJson.KOTGroupId == 0)
                {
                    orderJson.KOTGroupId = null;
                }
                Product product = rawJson.ToObject<Product>();
                if (product.KOTGroupId == 0)
                {
                    product.KOTGroupId = null;
                }
                product.CreatedDate = db.Products.Where(x => x.Id == product.Id).AsNoTracking().FirstOrDefault().CreatedDate;
                product.ModifiedDate = DateTime.Now;
                product.Name = product.Name;
                product.Description = product.Description;
                if (image != null)
                    product.ImgUrl = ImageUpload(product.CompanyId, image);
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                List<UPProduct> uPProducts = db.UPProducts.Where(x => x.ProductId == product.Id && x.CompanyId == product.CompanyId).ToList();
                foreach (var upproduct in uPProducts)
                {
                    upproduct.Price = product.UPPrice;
                    db.Entry(upproduct).State = EntityState.Modified;
                    db.SaveChanges();
                }

                JArray OptionGroupJson = rawJson.ProductOptionGroups;
                if (OptionGroupJson != null)
                {
                    IEnumerable<dynamic> optionGroups = OptionGroupJson.ToList();

                    foreach (var item in optionGroups)
                    {
                        int itemId = item.ToObject<int>();
                        var prdopgp = db.ProductOptionGroups.Where(x => x.ProductId == product.Id && x.OptionGroupId == itemId).FirstOrDefault();
                        if (prdopgp == null)
                        {
                            ProductOptionGroup productOptionGroup = new ProductOptionGroup();
                            productOptionGroup.ProductId = product.Id;
                            productOptionGroup.OptionGroupId = itemId;
                            productOptionGroup.CompanyId = product.CompanyId;
                            productOptionGroup.CreatedDate = DateTime.Now;
                            productOptionGroup.ModifiedDate = DateTime.Now;
                            db.ProductOptionGroups.Add(productOptionGroup);
                            db.SaveChanges();
                        }
                    }
                    var prdopgp1 = db.ProductOptionGroups.Where(x => x.ProductId == product.Id).ToList();
                    foreach (var opgp in prdopgp1)
                    {
                        var delopgp = optionGroups.Where(x => x == opgp.OptionGroupId).FirstOrDefault();
                        if (delopgp == null)
                        {
                            var delopgp1 = db.ProductOptionGroups.Find(opgp.Id);
                            db.ProductOptionGroups.Remove(delopgp1);
                            db.SaveChanges();
                        }
                    }

                }
                int compId = product.CompanyId;
                int productId = product.Id;
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.UpdateStoreProductFB", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@compId", compId));
                cmd.Parameters.Add(new SqlParameter("@productId", productId));
                int success = cmd.ExecuteNonQuery();
                sqlCon.Close();
                var error = new
                {
                    status = 200,
                    msg = "Product updated successfully"
                };
                sqlCon.Close();
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

        [EnableCors("AllowOrigin")]
        [HttpGet("GetByIdfb")]
        public IActionResult GetByIdfb(int id, int compId)
        {
            try
            {
                var prod = new
                {
                    products = db.Products.Where(x => x.CompanyId == compId).ToList(),
                    product = from p in db.Products
                              where p.Id == id && p.CompanyId == compId
                              select new { p.Id, Product = p.Name, p.Description,p.IsStockMaintained, p.BarCode , p.Price, p.TakeawayPrice, p.DeliveryPrice, p.CategoryId, p.TaxGroupId, p.CompanyId, p.UnitId, p.ProductTypeId, p.KOTGroupId, p.ImgUrl, p.ProductCode, p.UPPrice, p.Recomended, p.SortOrder, p.isactive, p.minquantity, p.minblock },
                    productOptionGroups = from pog in db.ProductOptionGroups
                                          join og in db.OptionGroups on pog.OptionGroupId equals og.Id
                                          where pog.ProductId == id && pog.CompanyId == compId
                                          select new { pog.Id, pog.OptionGroupId, pog.ProductId, og.Name },
                    optionGroups = db.OptionGroups.Where(x => x.CompanyId == compId).ToList(),
                    category = db.Categories.Where(o => o.CompanyId == compId).ToList(),
                    categoryOptionGroups = db.CategoryOptionGroups.Where(x => x.CompanyId == compId).ToList(),
                    taxGroup = db.TaxGroups.Where(o => o.CompanyId == compId).ToList(),
                    units = db.Units.ToList(),
                    productType = db.ProductTypes.ToList(),
                    Kot = db.KOTGroups.Where(k => k.CompanyId == compId).ToList(),
                    //PredefinedQuantities = db.PredefinedQuantities.Where(x => x.ProductId == id).ToList(),
                    //CakeQuantities = db.CakeQuantities.ToList()
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

        [HttpGet("GetById")]
        public IActionResult GetById(int companyId)
        {
            try
            {
                //SqlConnection sqlCon = new SqlConnection("server=(LocalDb)\\MSSQLLocalDB; database=Biz1POS;Trusted_Connection=True;");
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.getproductbyid", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;            
                cmd.Parameters.Add(new SqlParameter("@CompanyId", companyId));               
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                DataTable table = ds.Tables[0];
               
                return Ok(table);
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


        [HttpGet("GetById1")]
        public IActionResult GetById1(int id, int compId, bool isactive)
        {
            try
            {
                var prod = new
                {
                    products = db.Products.Where(x => x.CompanyId == compId && x.isactive == true ).ToList(),
                    product = from p in db.Products
                              where p.Id == id && p.CompanyId == compId  && p.isactive == true
                              select new { p.Id, Product = p.Name, p.Description, p.Price, p.TakeawayPrice, p.DeliveryPrice, p.CategoryId, p.TaxGroupId, p.CompanyId, p.UnitId, p.ProductTypeId, p.KOTGroupId, p.ImgUrl, p.ProductCode, p.UPPrice, p.Recomended, p.SortOrder, p.isactive, p.minquantity, p.minblock, p.CreatedDate },

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

        //[HttpGet("GetById")]
        //public IActionResult GetById(DateTime fromdate, DateTime todate, int companyId, int storeId)
        //{
        //    try
        //    {
        //        //SqlConnection sqlCon = new SqlConnection("server=(LocalDb)\\MSSQLLocalDB; database=Biz1POS;Trusted_Connection=True;");
        //        SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        //        sqlCon.Open();
        //        SqlCommand cmd = new SqlCommand("dbo.getproduct", sqlCon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@fromdate", fromdate));
        //        cmd.Parameters.Add(new SqlParameter("@todate", todate));
        //        cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
        //        cmd.Parameters.Add(new SqlParameter("@companyId", companyId));


        //        DataSet ds = new DataSet();
        //        SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        //        sqlAdp.Fill(ds);
        //        DataTable table = ds.Tables[0];

        //        sqlCon.Close();
        //        return Ok(table);
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

        [HttpGet("UpdateAct")]
        public IActionResult UpdateAct(int Id, bool active)
        {
            try
            {
                var product = db.Products.Find(Id);
                product.isactive = active;
                db.Entry(product).State = EntityState.Modified;
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
        public bool barcodedetailsupdate(int productid, dynamic variantcombinations)
        {
            List<int> bcids = new List<int>();
            foreach (dynamic cmb in variantcombinations)
            {
                if (cmb.id > 0)
                {
                    int barcodeid = (int)cmb.id;
                    Barcode barcode = db.Barcodes.Find(barcodeid);
                    barcode.BarCode = cmb.barcode;
                    db.Entry(barcode).State = EntityState.Modified;
                    db.SaveChanges();
                    bcids.Add(barcode.Id);
                }
                else if (cmb.id == 0)
                {
                    Barcode barcode = new Barcode();
                    barcode.BarCode = cmb.barcode;
                    barcode.ProductId = productid;
                    barcode.Updated = true;
                    db.Barcodes.Add(barcode);
                    db.SaveChanges();
                    bcids.Add(barcode.Id);
                    foreach (int id in cmb.variantids)
                    {
                        BarcodeVariant barcodeVariant = new BarcodeVariant();
                        barcodeVariant.BarcodeId = barcode.Id;
                        barcodeVariant.Updated = true;
                        barcodeVariant.VariantId = id;
                        db.BarcodeVariants.Add(barcodeVariant);
                        db.SaveChanges();
                    }
                }
            }
            List<Barcode> barcodes = db.Barcodes.Where(x => x.ProductId == productid).ToList();
            foreach (Barcode bc in barcodes)
            {
                if (!bcids.Contains(bc.Id))
                {
                    BarcodeVariant[] barcodeVariants = db.BarcodeVariants.Where(x => x.BarcodeId == bc.Id).ToArray();
                    db.BarcodeVariants.RemoveRange(barcodeVariants);
                    db.SaveChanges();
                }
            }
            return true;
        }
        public bool productcategorychange(int productid, dynamic variantcombinations)
        {
            List<Barcode> barcodes = db.Barcodes.Where(x => x.ProductId == productid).ToList();
            foreach (Barcode barcode in barcodes)
            {
                BarcodeVariant[] barcodeVariants = db.BarcodeVariants.Where(x => x.BarcodeId == barcode.Id).ToArray();
                db.BarcodeVariants.RemoveRange(barcodeVariants);
                db.SaveChanges();
            }
            for (int i = 0; i < variantcombinations.Count; i++)
            {
                Barcode barcode = new Barcode();
                if (barcodes[i] != null)
                {
                    barcode = barcodes[i];
                    barcode.BarCode = variantcombinations[i].barcode;
                    db.Entry(barcode).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    barcode.ProductId = productid;
                    barcode.Updated = true;
                    barcode.BarCode = variantcombinations[i].barcode;
                    db.Barcodes.Add(barcode);
                    db.SaveChanges();
                }
                foreach (int id in variantcombinations[i].variantids)
                {
                    BarcodeVariant barcodeVariant = new BarcodeVariant();
                    barcodeVariant.BarcodeId = barcode.Id;
                    barcodeVariant.Updated = true;
                    barcodeVariant.VariantId = id;
                    db.BarcodeVariants.Add(barcodeVariant);
                    db.SaveChanges();
                }
            }
            foreach (dynamic cmb in variantcombinations)
            {
                Barcode barcode = new Barcode();
                barcode.ProductId = productid;
                barcode.Updated = true;
                barcode.BarCode = cmb.barcode;
                db.Barcodes.Add(barcode);
                db.SaveChanges();
                foreach (int id in cmb.variantids)
                {
                    BarcodeVariant barcodeVariant = new BarcodeVariant();
                    barcodeVariant.BarcodeId = barcode.Id;
                    barcodeVariant.Updated = true;
                    barcodeVariant.VariantId = id;
                    db.BarcodeVariants.Add(barcodeVariant);
                    db.SaveChanges();
                }
            }
            return true;
        }

        [HttpGet("getUnits")]
        public IActionResult getUnits()
        {
            var units = db.Units.ToList();

            return Ok(units);
        }

        [HttpGet("getorders")]
        public IActionResult getorders(int CompanyId)
        {
            var units = db.Orders.ToList();

            return Ok(units);
        }


        [HttpGet("getProductType")]
        public IActionResult getProductType(int CompanyId)
        {
            var producttypes = db.ProductTypes.ToList();
            return Ok(producttypes);
        }

        [HttpGet("getmasterproducts")]
        public IActionResult getmasterproducts(int CompanyId)
        {
            var products = db.Products.Where(x => x.CompanyId == CompanyId).Include(x => x.TaxGroup).Include(x => x.Category).ToList();
            return Ok(products);
        }
        [HttpGet("getproductbyid")]
        public IActionResult getproductbyid(int ProductId)
        {
            var product = db.Products.Find(ProductId);
            var barcodes = db.Barcodes.Where(x => x.ProductId == ProductId).ToList();
            var barcodevariants = db.BarcodeVariants.Where(x => barcodes.Where(y => y.Id == x.BarcodeId).Any()).ToList();
            var data = new
            {
                product = product,
                barcodes = barcodes,
                barcodevariants = barcodevariants
            };
            return Ok(data);
        }
        [HttpGet("getcategoryvariants")]
        public IActionResult getcategoryvariants(int categoryid)
        {
            try
            {
                var categoryvariantgroups = db.CategoryVariantGroups.Where(x => x.CategoryId == categoryid).ToList();
                foreach (var categoryvariantgroup in categoryvariantgroups)
                {
                    categoryvariantgroup.VariantGroupName = db.VariantGroups.Find(categoryvariantgroup.VariantGroupId).Name;
                    categoryvariantgroup.Variants = db.Variants.Where(x => x.VariantGroupId == categoryvariantgroup.VariantGroupId).ToList();
                }
                return Ok(categoryvariantgroups);
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
        [HttpGet("getmasteroption")]
        public IActionResult getmasteroption(int CompanyId)
        {
            var options = db.Variants.Where(x => x.CompanyId == CompanyId).Include(x => x.VariantGroup).ToList();

            return Ok(options);
        }
        [HttpGet("getmasteroptiongroup")]
        public IActionResult getmasteroptiongroup(int CompanyId)
        {
            var optionGroups = db.VariantGroups.Where(x => x.CompanyId == CompanyId).ToList();

            return Ok(optionGroups);
        }


        [HttpGet("getKotGroup")]
        public IActionResult getKotGroup(int CompanyId)
        {
            var kotgroups = db.KOTGroups.ToList();

            return Ok(kotgroups);
        }

        [HttpGet("getCategory")]
        public IActionResult getCategory(int CompanyId)
        {
            var categories = db.Categories.Where(x => x.CompanyId == CompanyId).ToList();

            return Ok(categories);
        }

        [HttpGet("getvariants")]
        public IActionResult getvariants(int CompanyId)
        {
            var variants = db.Variants.Where(x => x.CompanyId == CompanyId).Include(x => x.VariantGroup).ToList();
            return Ok(variants);
        }

        [HttpGet("getvariantgroups")]
        public IActionResult getvariantgroups(int CompanyId)
        {
            var variantgroups = db.VariantGroups.Where(x => x.CompanyId == CompanyId).ToList();
            foreach (var variantgroup in variantgroups)
            {
                variantgroup.variantcount = db.Variants.Where(x => x.VariantGroupId == variantgroup.Id).ToList().Count();
            }
            return Ok(variantgroups);
        }

        [HttpPost("addneededproduct")]
        public IActionResult addneededproduct([FromBody]NeedProducts product, DateTime from, DateTime to)
        {
            try

            {
                string message = "Needed Product As Been Saved";
                int status = 200;
                NeedProducts newProd = product;
                db.NeedProducts.Add(newProd);
                db.SaveChanges();
                var response = new
                {
                    
                    message = message,
                    status = status
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    Error = new Exception(e.Message, e.InnerException),
                    status = 500,
                    Message = "Opps, Failed"
                };
                return Json(error);
            }
        }


        [HttpGet("GetNeededProd")]
        public IActionResult GetNeededProd(int CompanyId)
        {
            var neededprod = db.NeedProducts.Where(x => x.CompanyId == CompanyId).ToList();
            return Ok(neededprod);
        }

        //25-03-2022
        [HttpPost("Deleteprod")]
        public IActionResult Deleteprod([FromBody] dynamic objData)

        {
            try
            {
                dynamic jsonObj = objData;
                int companyId = jsonObj.CompanyId;
                int id = jsonObj.id;
                NeedProducts product = db.NeedProducts.Find(id);

                db.NeedProducts.Remove(product);
                db.SaveChanges();
                var data = new
                {
                    data = " Data deleted Successfully",
                    status = 1
                };
                return Json(data);
            }
            catch (Exception e)
            {
                var error = new
                {
                    data = e.Message,
                    msg = "Contact your service provider",
                    status = 500,
                    error = new Exception(e.Message, e.InnerException)
                };
                return Json(error);
            }
        }

        [HttpPost("addvariant")]
        public IActionResult addvariant([FromBody] Variant variant)
        {
            try
            {
                db.Variants.Add(variant);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Variant added successfully",
                    variant = variant
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

        [HttpPost("addvariantgroup")]
        public IActionResult addvariantgroup([FromBody] VariantGroup variantGroup)
        {
            try
            {
                db.VariantGroups.Add(variantGroup);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "VariantGroup added successfully",
                    variantGroup = variantGroup
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
        [HttpPost("updatevariant")]
        public IActionResult updatevariant([FromBody] Variant variant)
        {
            try
            {

                db.Entry(variant).State = EntityState.Modified;
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Variant updated successfully",
                    variant = variant
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

        [HttpPost("updatevariantgroup")]
        public IActionResult updatevariantgroup([FromBody] VariantGroup variantGroup)
        {
            try
            {
                db.Entry(variantGroup).State = EntityState.Modified;
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "VariantGroup updated successfully",
                    variantGroup = variantGroup
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

        [HttpPost("batchEntry")]
        public IActionResult batchEntry([FromBody] dynamic batcheobj, int userid)
        {
            try
            {
                List<Batch> batches = batcheobj.ToObject<List<Batch>>();
                int companyid = 0;
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                JArray products = new JArray();
                foreach (Batch batch in batches)
                {
                    companyid = batch.CompanyId;
                    sqlCon.Open();

                    SqlCommand cmd = new SqlCommand("dbo.BatchEntry", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@companyid", batch.CompanyId));
                    cmd.Parameters.Add(new SqlParameter("@batchno", batch.BatchNo));
                    cmd.Parameters.Add(new SqlParameter("@quantity", batch.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@barcodeid", batch.BarcodeId));
                    cmd.Parameters.Add(new SqlParameter("@storeid", batch.StoreId));
                    cmd.Parameters.Add(new SqlParameter("@expiarydate", batch.ExpiaryDate));
                    cmd.Parameters.Add(new SqlParameter("@productid", batch.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@price", batch.Price));
                    cmd.Parameters.Add(new SqlParameter("@entrydatetime", batch.EntryDateTime));
                    cmd.Parameters.Add(new SqlParameter("@userid", userid));

                    DataSet ds = new DataSet();
                    SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                    sqlAdp.Fill(ds);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        JObject product = new JObject();
                        for (int j = 0; j < row.ItemArray.Length; j++)
                        {
                            string column = ds.Tables[0].Columns[j].ToString();
                            column = Char.ToLowerInvariant(column[0]) + column.Substring(1);
                            var rowvalue = row.ItemArray[j];
                            product.Add(new JProperty(column, rowvalue));
                        }
                        products.Add(product);
                    }
                    var sqldata = new
                    {
                        products = ds.Tables[0]
                    };
                    sqlCon.Close();
                }
                int lastbatchno = db.Batches.Where(x => x.CompanyId == companyid).Max(x => x.BatchNo);
                var response = new
                {
                    msg = "BatchEntry Added Successfully",
                    lastbatchno = lastbatchno,
                    products = products
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
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        [HttpGet("getbarcodeproduct")]
        public IActionResult getbarcodeproduct(int CompanyId, int storeid)
        {
            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand("dbo.BarcodeProduct", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CompanyId", CompanyId));
            cmd.Parameters.Add(new SqlParameter("@storeId", storeid));

            DataSet ds = new DataSet();
            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            sqlAdp.Fill(ds);
            int lastbatchno = 0;
            int lastorderno = 0;
            if (db.Batches.Where(x => x.CompanyId == CompanyId).Any())
            {
                lastbatchno = db.Batches.Where(x => x.CompanyId == CompanyId).Max(x => x.BatchNo);
            }
            if (db.Orders.Where(x => x.CompanyId == CompanyId).Any())
            {
                lastorderno = db.Orders.Where(x => x.CompanyId == CompanyId).Max(x => x.OrderNo);
            }
            var response = new
            {
                Products = ds.Tables[0],
                lastbatchno = lastbatchno,
                lastorderno = lastorderno
            };
            return Ok(response);
        }

        [HttpGet("getstockbarcodeproduct")]
        public IActionResult getstockbarcodeproduct(int CompanyId, int storeid)
        {
            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand("dbo.StockBatchProducts", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CompanyId", CompanyId));
            cmd.Parameters.Add(new SqlParameter("@storeId", storeid));

            DataSet ds = new DataSet();
            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            sqlAdp.Fill(ds);
            int lastbatchno = 0;
            int lastorderno = 0;
            if (db.Batches.Where(x => x.CompanyId == CompanyId).Any())
            {
                lastbatchno = db.Batches.Where(x => x.CompanyId == CompanyId).Max(x => x.BatchNo);
            }
            if (db.Orders.Where(x => x.CompanyId == CompanyId).Any())
            {
                lastorderno = db.Orders.Where(x => x.CompanyId == CompanyId).Max(x => x.OrderNo);
            }
            var response = new
            {
                Products = ds.Tables[0],
                lastbatchno = lastbatchno,
                lastorderno = lastorderno
            };
            return Ok(response);
        }


        [HttpPost("stockEntry")]
        public IActionResult stockEntry([FromBody] List<StockBatch> stockBatches)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                foreach (StockBatch stockbatch in stockBatches)
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("dbo.StockEntry", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@companyid", stockbatch.CompanyId));
                    cmd.Parameters.Add(new SqlParameter("@stockid", stockbatch.StockId));
                    cmd.Parameters.Add(new SqlParameter("@batchid", stockbatch.BatchId));
                    cmd.Parameters.Add(new SqlParameter("@quantity", stockbatch.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@createddate", stockbatch.CreatedDate));
                    cmd.Parameters.Add(new SqlParameter("@createdby", stockbatch.CreatedBy));
                    

                    DataSet ds = new DataSet();
                    SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                    sqlAdp.Fill(ds);
                    sqlCon.Close();
                }
                var response = new
                {
                    msg = "Stock Added Successfully",
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
        [HttpGet("getStockProduct")]
        public IActionResult getStockProduct(int CompanyId, int StoreId)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.StockProduct", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CompanyId", CompanyId));
                cmd.Parameters.Add(new SqlParameter("@storeId", StoreId));

                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                sqlCon.Close();

                var response = new
                {
                    Products = ds.Tables[0],
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
        [HttpPost("bulkaddproduct")]
        public IActionResult bulkaddproduct([FromBody] List<Product> products)
        {
            try
            {
                int companyid = 0;
                foreach (Product product in products)
                {
                    companyid = product.CompanyId;
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                var product_list = db.Products.Where(x => x.CompanyId == companyid).ToList();
                var response = new
                {
                    status = 200,
                    product_list = product_list
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
        [HttpPost("bulkupdateproduct")]
        public IActionResult bulkupdateproduct([FromBody] List<Product> products)
        {
            try
            {
                int companyid = 0;
                foreach (Product product in products)
                {
                    companyid = product.CompanyId;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                var product_list = db.Products.Where(x => x.CompanyId == companyid).ToList();
                var response = new
                {
                    status = 200,
                    product_list = product_list
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
        [HttpPost("bulkaddoption")]
        public IActionResult bulkaddoption([FromBody] List<Variant> variants)
        {
            try
            {
                int companyid = 0;
                foreach (Variant variant in variants)
                {
                    companyid = variant.CompanyId;
                    variant.VariantGroup = null;
                    db.Variants.Add(variant);
                    db.SaveChanges();
                }
                var variant_list = db.Variants.Where(x => x.CompanyId == companyid).ToList();
                var response = new
                {
                    status = 200,
                    variant_list = variant_list
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
        [HttpPost("bulkupdateoption")]
        public IActionResult bulkupdateoption([FromBody] List<Variant> variants)
        {
            try
            {
                int companyid = 0;
                foreach (Variant variant in variants)
                {
                    companyid = variant.CompanyId;
                    variant.VariantGroup = null;
                    db.Entry(variant).State = EntityState.Modified;
                    db.SaveChanges();
                }
                var variant_list = db.Variants.Where(x => x.CompanyId == companyid).ToList();
                var response = new
                {
                    status = 200,
                    variant_list = variant_list
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
        [HttpPost("bulkaddoptiongroup")]
        public IActionResult bulkaddoptiongroup([FromBody] List<VariantGroup> variantGroups)
        {
            try
            {
                int companyid = 0;
                foreach (VariantGroup variantGroup in variantGroups)
                {
                    companyid = variantGroup.CompanyId;
                    db.VariantGroups.Add(variantGroup);
                    db.SaveChanges();
                }
                var variantgroup_list = db.VariantGroups.Where(x => x.CompanyId == companyid).ToList();
                var response = new
                {
                    status = 200,
                    variantgroup_list = variantgroup_list
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
        [HttpPost("bulkupdateoptiongroup")]
        public IActionResult bulkupdateoptiongroup([FromBody] List<VariantGroup> variantGroups)
        {
            try
            {
                int companyid = 0;
                foreach (VariantGroup variantGroup in variantGroups)
                {
                    companyid = variantGroup.CompanyId;
                    db.Entry(variantGroup).State = EntityState.Modified;
                    db.SaveChanges();
                }
                var variantgroup_list = db.VariantGroups.Where(x => x.CompanyId == companyid).ToList();
                var response = new
                {
                    status = 200,
                    variantgroup_list = variantgroup_list
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

        //[HttpGet("getstockbatch")]
        //public IActionResult getstockbatch(int companyid)
        //{
        //    List<StockBatch> stockbatches = db.StockBatches.Where(x => x.CompanyId == companyid).ToList();
        //    return Ok(stockbatches);
        //}

        [HttpGet("getstockbatch")]
        public IActionResult getstockbatch(DateTime? fromdate, DateTime? todate, int companyId, int storeId)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.stockedit", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fromdate", fromdate));
                cmd.Parameters.Add(new SqlParameter("@todate", todate));
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                cmd.Parameters.Add(new SqlParameter("@companyId", companyId));


                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                DataTable table = ds.Tables[0];

                sqlCon.Close();
                return Ok(table);
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

        [HttpPost("Updatestockbatch")]
        public IActionResult Updatestockbatch([FromBody] dynamic stockbatchobj)
        {
            try
            {
                List<StockBatch> stockbatches = stockbatchobj.ToObject<List<StockBatch>>();
                foreach (StockBatch stockBatch in stockbatches)
                {
                    db.Entry(stockBatch).State = EntityState.Modified;
                }
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "stock updated successfully",
                    stockbatches = stockbatches
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

        //[HttpPost("Updatestockbatch")]
        //public IActionResult Updatestockbatch([FromBody] StockBatch stockBatch)
        // {
        //    try
        //    {
        //        db.Entry(stockBatch).State = EntityState.Modified;
        //        db.SaveChanges();
        //        var response = new
        //        {
        //            stockBatch = stockBatch,
        //            status = 200,
        //            msg = "stockbatch updated successfully"
        //        };
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        var response = new
        //        {
        //            status = 0,
        //            msg = "Something went wrong",
        //            error = new Exception(ex.Message, ex.InnerException)
        //        };
        //        return Ok(response);
        //    }
        //}

        [HttpGet("stockbatchget")]
        public IActionResult stockbatchget(int companyid)
        {
            List<StockBatch> stockbatch = db.StockBatches.Where(x => x.CompanyId == companyid).ToList();
            return Ok(stockbatch);
        }

        [HttpPost("Addunits")]
        public IActionResult Addunits([FromBody] dynamic unitsobj)
        {
            try
            {
                Unit units = unitsobj.ToObject<Unit>();
                db.Units.Add(units);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "Units  added successfully",
                    units = units
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






        //[HttpGet("getstockbatchproducts")]
        //public IActionResult getstoreproduct(int CompanyId,int StoreId)
        //{
        //    SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        //    sqlCon.Open();

        //    SqlCommand cmd = new SqlCommand("dbo.StockBatchProducts", sqlCon);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("@CompanyId", CompanyId));
        //     cmd.parameters.add(new sqlparameter("@storeid",storeid));

        //    DataSet ds = new DataSet();
        //    SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        //    sqlAdp.Fill(ds);
        //    int lastbatchno = 0;
        //    int lastorderno = 0;
        //    if (db.Batches.Where(x => x.CompanyId == CompanyId).Any())
        //    {
        //        lastbatchno = db.Batches.Where(x => x.CompanyId == CompanyId).Max(x => x.BatchNo);
        //    }
        //    if (db.Orders.Where(x => x.CompanyId == CompanyId).Any())
        //    {
        //        lastorderno = db.Orders.Where(x => x.CompanyId == CompanyId).Max(x => x.OrderNo);
        //    }
        //    var response = new
        //    {
        //        Products = ds.Tables[0],
        //        lastbatchno = lastbatchno,
        //        lastorderno = lastorderno
        //    };
        //    return Ok(response);
        //}


        public static DateTime UnixTimeStampToDateTime(Int64 unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp / 1000);
            var istdate = TimeZoneInfo.ConvertTimeFromUtc(dtDateTime, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            return istdate;
        }

        public class OrderPayload
        {
            public string OrderJson { get; set; }
        }
        }
}
