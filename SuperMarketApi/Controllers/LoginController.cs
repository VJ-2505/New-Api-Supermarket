using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private POSDbContext db;
        private int var_status;
        private string var_msg;
        public IConfiguration Configuration { get; }
        public LoginController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }

        //[HttpGet("Login")]

        //public IActionResult login([FromBody] Accounts data)
        //{

        //    SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        //    sqlCon.Open();

        //    SqlCommand cmd = new SqlCommand("dbo.Login", sqlCon);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.Add(new SqlParameter("@Email", data.Email));
        //    cmd.Parameters.Add(new SqlParameter("@PhoneNo", data.PhoneNo));
        //    cmd.Parameters.Add(new SqlParameter("@Password", data.Password));

        //    DataSet ds = new DataSet();

        //    if (db.Accounts.Where(x => x.Email == data.Email).Any() || db.Accounts.Where(x => x.PhoneNo == data.PhoneNo).Any())
        //    {
        //        SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        //        sqlAdp.Fill(ds);
        //        var response = new
        //        {
        //            status = ds.Tables[0]
        //        };
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        var response = new
        //        {
        //            status = 500,
        //            msg = "Email_Id/Phone_No doesn't exist",
        //        };
        //        return Ok(response);
        //    }

        //}

        [HttpPost("LoginCheck")]
        public IActionResult logincheck([FromBody] Accounts data)
        {

            string enpass = EnryptString(data.Password);
            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand("dbo.Login", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Email", data.Email));
            cmd.Parameters.Add(new SqlParameter("@PhoneNo", data.PhoneNo));
            cmd.Parameters.Add(new SqlParameter("@Password", enpass));

            DataSet ds = new DataSet();

            if (db.Accounts.Where(x => x.Email == data.Email).Any() || db.Accounts.Where(x => x.PhoneNo == data.PhoneNo).Any())
            {
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    Status = ds.Tables[0],
                    CompanyId=ds.Tables[1],
                    Stores = ds.Tables[2],
                   

                };
                return Ok(response);
            }
            else
            {
                var response = new
                {
                    status = 500,
                    msg = "Email_Id or Phone_No doesn't exist",
                };
                return Ok(response);
            }

        }


        // Register New User Details
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Accounts data)
        {
            string enpass = EnryptString(data.Password);
            string depass = DecryptString(enpass);
            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("dbo.Registration", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@YourName", data.Name));
            cmd.Parameters.Add(new SqlParameter("@RestaurentName", ""));
            cmd.Parameters.Add(new SqlParameter("@EmailId", data.Email));
            cmd.Parameters.Add(new SqlParameter("@Password", enpass));
            cmd.Parameters.Add(new SqlParameter("@PhoneNo", data.PhoneNo));
            cmd.Parameters.Add(new SqlParameter("@storeName", "MainStore"));
            cmd.Parameters.Add(new SqlParameter("@provider","biz1book"));

            DataSet ds = new DataSet();
            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            sqlAdp.Fill(ds);

            DataTable table = ds.Tables[0];

            DataRow row = table.Select().FirstOrDefault();

            int result = Int32.Parse(row["Success"].ToString());

            if (result == 1)
            {
                var_status = 0;
                var_msg = "The Email alredy exists";
            }
            else if (result == 2)
            {
                var_status = 0;
                var_msg = "The PhoneNo alredy exists";
            }
            else
            {
                var_status = 200;
                var_msg = "Successfully Registered";
            }

            var returnArray = new
            {
                status = var_status,
                data = new
                {

                },
                msg = var_msg
            };
            sqlCon.Close();
            return Json(returnArray);
        }

        public string EnryptString(string strEncrypted)
        {
            try
            {
                byte[] b = System.Text.Encoding.ASCII.GetBytes(strEncrypted);
                string encrypted = Convert.ToBase64String(b);
                return encrypted;
            }
            catch (Exception e)
            {
                var error = new
                {
                    error = new Exception(e.Message, e.InnerException),
                    status = 0,
                    msg = "Something went wrong  Contact our service provider"
                };
                return ("");
            }
        }

        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }


        [HttpGet("UserPin")]
        public IActionResult Indexdataid(int CompanyId)
        {
            return Json(db.Users.Where(x => x.CompanyId == CompanyId).ToList());
        }


        [HttpGet("getstoreusers")]
        public IActionResult getstoreusers(int storeId, int companyId)
        {
            var storeusers = db.UserStores.Where(x => x.StoreId == storeId).ToList();
            var compUsers = db.Users.Where(x => x.CompanyId == companyId).Include(c => c.Role).ToList();
            List<User> users = new List<User>();
            foreach(var user in compUsers)
            {
                if(storeusers.Where(x => x.UserId == user.Id).Any())
                {
                    users.Add(user);
                }
            }
            return Ok(users);
        }
        [HttpGet("DashBoard")]
        public IActionResult DashBoard(int storeId, int companyId, DateTime fromDate, DateTime toDate, DateTime toDay)
        {
            SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("dbo.Dashboard", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@compId", companyId));
            cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
            cmd.Parameters.Add(new SqlParameter("@fromDate", fromDate));
            cmd.Parameters.Add(new SqlParameter("@toDate", toDate));
            cmd.Parameters.Add(new SqlParameter("@today", toDay));

            DataSet ds = new DataSet();
            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            sqlAdp.Fill(ds);

            DataTable table = ds.Tables[0];

            var response = new
            {
                customerData = ds.Tables[0],
                todaySales = ds.Tables[1],
                daySales = ds.Tables[2],
                prodsalesreport = ds.Tables[3]
            };
            return Ok(response);
        }
        [HttpGet("getStoreData")]
        public IActionResult getStoreData(int CompanyId, int StoreId ,int PriceType, string tables)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.storedataTest", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CompanyId", CompanyId));
                cmd.Parameters.Add(new SqlParameter("@storeId", StoreId));
                cmd.Parameters.Add(new SqlParameter("@pricetype", PriceType));
                cmd.Parameters.Add(new SqlParameter("@modDate", null));
                cmd.Parameters.Add(new SqlParameter("@table", tables));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                sqlCon.Close();
                db.Database.ExecuteSqlCommandAsync(cmd.ToString());
                DataTable table = ds.Tables[0];               
                string[] catStr = new String[20];
                for (int k = 0; k < ds.Tables.Count; k++)
                {
                    for (int j = 0; j < ds.Tables[k].Rows.Count; j++)
                    {
                        catStr[k] += ds.Tables[k].Rows[j].ItemArray[0].ToString();
                    }
                    if (catStr[k] == null)
                    {
                        catStr[k] = "";
                    }
                }
                

                var response = new
                {
                    LogInfo = ds.Tables[0],
                    Customer = ds.Tables[1],
                    Vendor = ds.Tables[2],
                    Categories = ds.Tables[3],
                    TaxGroup = ds.Tables[4],
                    VariantGroup = ds.Tables[5],
                    Variant = ds.Tables[6],
                    Product = JsonConvert.DeserializeObject(catStr[7]),
                    BarcodeProduct = ds.Tables[8],
                    Preference = ds.Tables[9],
                    orderkey = ds.Tables[10],
                    AdditionalCharges = ds.Tables[11],
                    paymenttypes = ds.Tables[12],
                    storapaymenttypes = ds.Tables[13],
                    Producttypes = ds.Tables[14],
                    Stores = ds.Tables[15],
                    DiningArea = JsonConvert.DeserializeObject(catStr[16]),
                    DiningTable = JsonConvert.DeserializeObject(catStr[17]),
                    //Store = db.Stores.Where(x => x.CompanyId == CompanyId).ToList()
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

    }
}
