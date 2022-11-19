using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SuperMarketApi.Models;
using SuperMarketApi.Models.Enum;


namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]

    public class BankAccountController : Controller
    {
        private POSDbContext db;
        public IConfiguration Configuration { get; }
        public BankAccountController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }

        [HttpGet("GetacctType")]
        public IActionResult GetacctType(int companyId)
        {
            try
            {
                var accountTypes = db.AccountType.ToList();
                return Ok(accountTypes);
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
        [HttpPost("GetBankaccount")]
        public IActionResult GetBankaccount([FromBody] dynamic objData)
        {
            try
            {
                dynamic jsonObj = objData;
                int companyId = jsonObj[0].companyId;
                int? bankAccountId = jsonObj[0].bankAccountId;
                int? accTypeId = jsonObj[0].accTypeId;
                string isActive = jsonObj[0].isActive;
                string bankName = jsonObj[0].bankName;
                int? numRecords = jsonObj[0].numRecords;
                int? amountFrom = jsonObj[0].amountFrom;
                int? amountUpto = jsonObj[0].amountUpto;

                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.BankAccountIndex", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bankAccountId", bankAccountId));
                cmd.Parameters.Add(new SqlParameter("@accTypeId", accTypeId));
                cmd.Parameters.Add(new SqlParameter("@isActive", isActive));
                cmd.Parameters.Add(new SqlParameter("@bankName", bankName));
                cmd.Parameters.Add(new SqlParameter("@amountFrom", amountFrom));
                cmd.Parameters.Add(new SqlParameter("@amountUpto", amountUpto));
                cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords + 1));
                cmd.Parameters.Add(new SqlParameter("@companyId", companyId));

                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                //DataTable table = ds.Tables[0];

                var response = new
                {
                    Ord = ds.Tables[0]
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 200,
                    msg = "Something went wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }
        [HttpPost("AddBankaccount")]
        public IActionResult AddBankaccount([FromBody] dynamic objdata)
        {
            try
            {
                dynamic jsonObj = objdata;
                Contact contact = jsonObj.ToObject<Contact>();
                db.Contacts.Add(contact);
               db.SaveChanges();
                BankAccount bankAccount = new BankAccount();
                bankAccount = jsonObj.ToObject<BankAccount>();
                bankAccount.Id = contact.Id;
                db.BankAccounts.Add(bankAccount); 
                db.SaveChanges();

                var response = new
                {
                    status = 200,
                    msg = "bankAccount Added Successfully"
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

        [HttpGet("GetAccountById")]
        public IActionResult GetAccountById(int id)
        {
            var response = new
            {
                AcctList = from b in db.BankAccounts
                          join c in db.Contacts on b.Id equals c.Id
                          where
                         (b.Id == id)

                          select new
                          {
                              b.AccountNo, b.Id,b.IsActive,b.CreatedDate,b.CompanyId ,
                              b.AccountHolder,b.AccountTypeCd,b.AccountType,b.Balance,
                              b.BankName,b.BranchCode,b.CardNumber,b.CreditLimit,b.AllowNegative,
                              c.Name,c.PhoneNo,c.Address,c.City,c.AlternatePhoneNo,c.Email,
                              c.State,c.Zip,c.Notes
                               }

            };
            return Json(response);

        }


        [HttpGet("Deactivate")]
        public IActionResult Deactivate(int id)
        {
            var bankAccount = db.BankAccounts.Find(id);
            if (bankAccount.IsActive == true)
            {
                bankAccount.IsActive = false;
                db.SaveChanges();
            }
            else
            {
                bankAccount.IsActive = true;
                db.SaveChanges();
            }

            return Ok(bankAccount);
        }
        [HttpPost("UpdateBankAccount")]
        public IActionResult UpdateBankAccount([FromBody] dynamic objData)
        {
            try
            {
                dynamic jsonObj = objData;
                Contact contact = null;
                BankAccount bankAccount = null;
                int id = jsonObj.Id;
                contact = db.Contacts.Find(id);
                contact.Name = jsonObj.Name;
                contact.PhoneNo = jsonObj.PhoneNo;
                contact.IsActive = jsonObj.IsActive;
                contact.AlternatePhoneNo = jsonObj.AlternatePhoneNo;
                contact.State = jsonObj.State;
                contact.Address = jsonObj.Address;
                contact.City = jsonObj.City;
                contact.Zip = jsonObj.Zip;
                contact.CompanyId = jsonObj.CompanyId;
                db.Entry(contact).State = EntityState.Modified;
                bankAccount = db.BankAccounts.Find(id);
                bankAccount.AccountNo = jsonObj.AccountNo;
                bankAccount.AccountHolder = jsonObj.AccountHolder;
                bankAccount.IsActive = jsonObj.IsActive;
                bankAccount.AccountTypeCd = jsonObj.AccountTypeCd;
                bankAccount.Balance = jsonObj.Balance;
                bankAccount.BankName = jsonObj.BankName;
                bankAccount.BranchCode = jsonObj.BranchCode;
                bankAccount.CardNumber = jsonObj.CardNumber;
                bankAccount.CreditLimit = jsonObj.CreditLimit;
                bankAccount.CompanyId = jsonObj.CompanyId;
                db.Entry(bankAccount).State = EntityState.Modified;
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

    }
}
