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
    public class CreditTrxController : Controller
    {
        private POSDbContext db;
        BillTypeEnum billType = BillTypeEnum.Credit;

        public IConfiguration Configuration { get; }
        public CreditTrxController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
        // GET: CreditTrxController
        [HttpPost("GetCreditTrx")]
        public IActionResult GetCreditTrx([FromBody] dynamic objData)
         {
            try
            {
                dynamic jsonObj = objData;
                int companyId = jsonObj[0].companyId;
                int numRecords = jsonObj[0].numRecords;
                string billStatus = jsonObj[0].billstatus;
                int UserID = jsonObj[0].UserID;
                int? searchId = jsonObj[0].searchId;
                int? searchContactId = jsonObj[0].searchContactId;
                DateTime? dateFrom = jsonObj[0].dateFrom;
                DateTime? dateTo = DateTime.Now;
                string reference = jsonObj[0].reference;
                string creditTypeStr = jsonObj[0].creditTypeStr;
                int? amountFrom = jsonObj[0].amountFrom;
                int? amountUpto = jsonObj[0].amountUpto;
                int? contactType = jsonObj[0].contactType;
                
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("dbo.CreditIndex", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@searchId", searchId));
                cmd.Parameters.Add(new SqlParameter("@searchContactId", searchContactId));
                cmd.Parameters.Add(new SqlParameter("@billType", billType));
                cmd.Parameters.Add(new SqlParameter("@billStatus", billStatus));
                cmd.Parameters.Add(new SqlParameter("@fromDate", dateFrom));
                cmd.Parameters.Add(new SqlParameter("@toDate", dateTo));
                cmd.Parameters.Add(new SqlParameter("@sessionStoreID", 0));
                cmd.Parameters.Add(new SqlParameter("@userId", UserID));
                cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords + 1));
                cmd.Parameters.Add(new SqlParameter("@reference", reference));
                cmd.Parameters.Add(new SqlParameter("@contactType", contactType));
                cmd.Parameters.Add(new SqlParameter("@amountFrom", amountFrom));
                cmd.Parameters.Add(new SqlParameter("@amountUpto", amountUpto));
                cmd.Parameters.Add(new SqlParameter("@creditTypeStr", creditTypeStr));
                cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                return Ok(ds.Tables[0]);
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
        [HttpPost("PayCredit")]
        public IActionResult PayCredit([FromBody] dynamic objData)
        {
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {

                    int companyId = objData[0].CompanyId;
                    int userId = objData[0].UserId;
                    int? responsibleById = objData[0].ResponsibleById;
                    int amount = objData[0].Amount;
                    int contactId = objData[0].ContactId;
                    string creditType = objData[0].CreditType;
                    bool isPlanned = false;
                    List<PlannedTrans> planTransList = null;
                    PlannedTrans planTrans = null;
                    bool debtError = false;



                    //DateTime transDate = FbBatterController.GetDateTimeSave(transDateStr, transTime);
                    Transaction trans = new Transaction();
                    trans = objData[0].ToObject<Transaction>();

                    bool isNegativeBalance = TransControllerExt.CreateTrans(
                        db, trans, getTransFlow(billType));
                    if (!isNegativeBalance)
                    {
                        Bill bill = TransControllerExt.CreateBillForTrans(
                            db, trans, (int)billType,  DateTime.Now);
                        BillTrans billTrans = new BillTrans(trans.TransactionId, bill.BillId);
                        bill.ResponsibleById = responsibleById;
                        //bill.DueDate = FormatExt.GetDateSave(Convert.ToString(trans.DueDate));
                        bill.CreditTypeStr = creditType;
                        var debt = db.Bill.Where(c => c.ProviderId == bill.ReceiverId && c.BillType == (int)BillTypeEnum.Debt && c.CompanyId == companyId).ToList();
                        if (debt.Count > 0) debtError = true;
                        planTransList = db.PlannedTrans.Where(p => p.ContactId == trans.ContactId && p.StoreId == trans.StoreId && p.Status.Code != "COM" && p.CompanyId == companyId).ToList();
                        if (planTransList.Count > 0)
                        {
                            isPlanned = true;
                            planTrans = planTransList.FirstOrDefault();
                        }

                        billTrans.CompanyId = companyId;
                        db.BillTrans.Add(billTrans);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    var data = new { isNegativeBalance = isNegativeBalance, isPlanned = isPlanned, debtError = debtError };
                    return Json(data);
                }
                catch (Exception e)
                {
                    var data = new { data = e.Message, msg = "Contact your service provider" };
                    return Json(data);
                }
            }
        }
        [HttpPost("Submit")]
        public IActionResult Submit([FromBody] dynamic objData)
        {
            try
            {
        int companyId = objData[0].CompanyId;
                int userId = objData[0].UserId;
                Transaction trans = new Transaction();
                trans = objData[0].ToObject<Transaction>();
                JArray items = objData[0].items;
                dynamic creditArr = items.ToList();
                TransControllerExt.CreateTrans(db, trans, !getTransFlow(billType));
                TransControllerExt.BillnPays(db, creditArr, trans.TransactionId, userId, companyId);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    transactionId = trans.TransactionId
                };
                return Json(response);
            }
            catch (Exception e)
            {
                var data = new { data = e.Message, msg = "Contact your service provider" };
                return Json(data);
            }
        }
    [HttpGet("getPaymentTypesList")]
    public IActionResult getPaymentTypesList(int CompanyId)
    {
      var paymentTypes = db.PaymentTypes.ToList();
      return Ok(paymentTypes);
    } 

    [HttpPost("UpdateCredit")]
        public IActionResult UpdateCredit([FromBody] dynamic objData)
        {
            using (var scope = SQLExt.CreateTransScope())
            {
                try
                {
                    dynamic jsonObj = objData;
                    int companyId = jsonObj[0].CompanyId;
                    int? responsibleById = jsonObj[0].responsibleById;
                    string creditType = jsonObj[0].CreditType;

                    Transaction trans = jsonObj[0].ToObject<Transaction>();

                    bool isNegBankBalance = TransControllerExt.UpdateTrans(db, trans, true, companyId);
                    bool isErrorInBillPayment = TransControllerExt.UpdateBillForTrans(db, trans, companyId, creditType, responsibleById);
                    db.SaveChanges();
                    scope.Complete();
                    var data = new { isNegBankBalance = isNegBankBalance, isErrorInBillPayment = isErrorInBillPayment, status = 1 };
                    return Json(data);
                }
                catch (Exception e)
                {
                    var data = new { data = e.Message, msg = "Contact your service provider", status = 0 };
                    return Json(data);
                }
            }
        }
        [HttpGet("RepayCreditFor")]
        public IActionResult  RepayCreditFor(int compId,int? id)
        {
            try
            {
                //IEnumerable<string> userStore = new string[] { };
                //userStore = StoresControllerExt.GetUserStores(this, db);

                var contact = db.Contacts.Where(c => c.Id == id && c.CompanyId == compId).FirstOrDefault();

                IEnumerable<TransMode> TransMode = TransControllerExt.TransMode(db, "In");
                List<Bill> Bills = setBillView(compId, id);
                double Balance = TransControllerExt.calcBalance(Bills);
                var data = new { TransMode = TransMode, Bills = Bills, Balance= Balance, status = 1 };
                return Json(data);
            }
            catch (Exception e)
            {
                var data = new { data = e.Message, msg = "Contact your service provider", status = 0 };
                return Json(data);
            }
        }
        [HttpPost("EditCreditTrx")]
        public IActionResult EditCreditTrx([FromBody]dynamic objData)
        {
            dynamic jsonObj = objData;
            int companyId = jsonObj[0].companyId;
            int id = jsonObj[0].id;

            //Transaction trans = db.Transactions.Find(id);
      var trans = from t in db.Transactions
                 join c in db.Contacts on t.ContactId equals c.Id
                 where (t.TransactionId == id && (t.CompanyId == companyId))
                 select new
                 {
                   t.TransactionId,  c.Name,
                   t.TransDate, t.TransModeId, t.Updated, c.ContactTypeId,
                   t.Notes, t.IsIncoming,t.Amount,t.Description,
                   t.PaymentTypeId, t.StoreId, t.Store, t.PaymentType, t.Contact
                 };
        List <Bill> bills = setBillView(id, companyId); 
             var balance = TransControllerExt.calcBalance(bills);


      var creditTypeStr = (from bt in db.BillTrans
                                 join b in db.Bill on bt.BillId equals b.BillId
                                 where bt.BillTransId == id && b.CompanyId == companyId
                                 select b.CreditTypeStr).FirstOrDefault();
            //var creditType = DropDownExtApi.GetDropDownVals(db, "CTYP", false);
            int billId = db.BillTrans.Where(b => b.BillTransId == id && b.CompanyId == companyId).Select(b => b.BillId).FirstOrDefault();
            var bill = db.Bill.Find(billId);
      //var bills = (from c in db.Contacts
      //             join b in db.Bill on c.Id equals b.ContactId
      //             where b.BillId == id && b.CompanyId == companyId
      //             select
      //             {

      int? responsibleById = null; string responsibleBy = "";
      //if (bill.ResponsibleById != null)
      //{
      //  responsibleBy = bill.ResponsibleBy.Name;  
      //  responsibleById = bill.ResponsibleById;
      //}
      return Json(new
            {
                balance = balance,
                trans = trans,
        //creditType = creditType,
        //responsibleBy = responsibleBy,
        //responsibleById = responsibleById,
        creditTypeStr = creditTypeStr
            });
        }
        [HttpGet("Credits")]
        public IActionResult Credits(int compId,int id)
         {
            try
            {
                List<Bill> Bills = setBillView(compId, id);
                double Balance = TransControllerExt.calcBalance(Bills);
        Contact contact = null;
       contact = db.Contacts.Find(id);
                var data = new { Bills = Bills, Balance = Balance, status = 1 ,
                Contacts = contact};
                return Json(data);
            }
            catch (Exception e)
            {
                var data = new { data = e.Message, msg = "Contact your service provider", status = 0 };
                return Json(data);
            }
        }
    public List<Bill> setBillView(int compId, int? id)
        {
            List<Bill> bills = null;
            if (getTransFlow(billType))
            {
                bills =
                    db.Bill.Where(s => s.ProviderId == id && s.CompanyId == compId).Where(s => s.BillType == (int)billType)
                           .Where(s => s.PaidAmount < s.BillAmount && s.IsPaid == false).Include(x => x.Contact).ToList();
            }
            else
            {
                bills =
                    db.Bill.Where(s => s.ReceiverId == id && s.CompanyId == compId).Where(s => s.BillType == (int)billType)
                           .Where(s => s.PaidAmount < s.BillAmount && s.IsPaid == false).ToList();
            }
            return bills;
        }
        [HttpPost("GetCreditRepayTrx")]
        public IActionResult GetCreditRepayTrx([FromBody]dynamic objData)
        {
            try
            {
                dynamic jsonObj = objData;
                int companyId = jsonObj[0].companyId;
                int numRecords = jsonObj[0].numRecords;
                int searchId = jsonObj[0].searchId;
                string transactionId = jsonObj[0].transactionId;
                string UserID = jsonObj[0].UserID;
                int? searchContactId = jsonObj[0].searchContactId;
                DateTime? dateFrom = jsonObj[0].dateFrom;
                DateTime? dateTo = DateTime.Now;
                string reference = jsonObj[0].reference;
                int? amountFrom = jsonObj[0].amountFrom;
                int? amountUpto = jsonObj[0].amountUpto;
                int? storeId = jsonObj[0].storeId;
                int transType = (int)TransTypeEnum.Credit_Repay;

                int? contactType = null;
                if (dateFrom != null && dateTo == null)
                    dateTo = ((DateTime)dateFrom).AddDays(1);
                //var conString = db.Database.Connection.ConnectionString;

                //string numRecordsStr = Constants.DEFAULT_100;
                //if (numRecordsStr == Constants.ALL_RECORDS)
                //    numRecords = db.Transactions.Where(t => (t.TranstypeId == (int)TransTypeEnum.Credit) && t.CompanyId == companyId).Count();
                //else
                //    numRecords = Convert.ToInt32(numRecordsStr);

                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.CreditRepayIndex", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@searchId", searchId));
                cmd.Parameters.Add(new SqlParameter("@searchContactId", searchContactId));
                cmd.Parameters.Add(new SqlParameter("@transType", transType));
                cmd.Parameters.Add(new SqlParameter("@transactionId", transactionId));
                cmd.Parameters.Add(new SqlParameter("@fromDate", dateFrom));
                cmd.Parameters.Add(new SqlParameter("@toDate", dateTo));
                cmd.Parameters.Add(new SqlParameter("@sessionStoreID", 0));
                cmd.Parameters.Add(new SqlParameter("@userId", UserID));
                cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords + 1));
                cmd.Parameters.Add(new SqlParameter("@amountFrom", amountFrom));
                cmd.Parameters.Add(new SqlParameter("@amountUpto", amountUpto));
                cmd.Parameters.Add(new SqlParameter("@reference", reference));
                cmd.Parameters.Add(new SqlParameter("@contactType", contactType));
                cmd.Parameters.Add(new SqlParameter("@companyId", companyId));

                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlAdp.Fill(ds);

                DataTable table = ds.Tables[0];

                var data = new { data = table, msg = "Data Retrived Successfully", status = 1 };
                return Json(data);
            }
            catch (Exception e)
            {
                var data = new { data = e.Message, msg = "Contact your service provider", status = 0 };
                return Json(data);
            }

        }

        bool getTransFlow(BillTypeEnum billType)
        {
            if (billType == BillTypeEnum.Credit)
            {
                return false;
            }
            else if (billType == BillTypeEnum.Debt)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
    }

}

