using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SuperMarketApi.Models;
using SuperMarketApi.Models.Enum;

namespace SuperMarketApi.Controllers
{
  [Route("api/[controller]")]
  public class PurchaseTrxController : Controller
  {
    private POSDbContext db;
    public IConfiguration Configuration { get; }

    public PurchaseTrxController(POSDbContext contextOptions, IConfiguration configuration)
    {
      db = contextOptions;
      Configuration = configuration;
    }


    [HttpGet("GetPurchaseTrx")]
    public IActionResult GetPurchaseTrx(JObject objData)
    {
      try
      {
        dynamic jsonObj = objData;
        int? searchContactId = jsonObj.searchContactId;
        int? billStatus = jsonObj.billStatus;
        DateTime? dateFrom = jsonObj.dateFrom;
        DateTime? dateTo = jsonObj.dateTo;
        int companyId = jsonObj.companyId;
        int? storeID = jsonObj.storeID;
        int? billId = jsonObj.billId;
        int? numRecords = jsonObj.numRecords;
        int? amountFrom = jsonObj.amountFrom;
        int? amountUpto = jsonObj.amountUpto;
        int? receiverStoreId = jsonObj.receiverStoreId;
        string UserID = jsonObj.UserID;

        SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        sqlCon.Open();

        SqlCommand cmd = new SqlCommand("dbo.PurchaseIndex", sqlCon);

        cmd.Parameters.Add(new SqlParameter("@searchContactId", searchContactId));
        cmd.Parameters.Add(new SqlParameter("@billStatus", billStatus));
        cmd.Parameters.Add(new SqlParameter("@fromDate", dateFrom));
        cmd.Parameters.Add(new SqlParameter("@toDate", dateTo));
        cmd.Parameters.Add(new SqlParameter("@storeID", storeID));
        cmd.Parameters.Add(new SqlParameter("@billId", billId));
        cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords + 1));
        cmd.Parameters.Add(new SqlParameter("@userId", UserID));
        cmd.Parameters.Add(new SqlParameter("@amountFrom", amountFrom));
        cmd.Parameters.Add(new SqlParameter("@amountUpto", amountUpto));
        cmd.Parameters.Add(new SqlParameter("@receiverStoreId", receiverStoreId));
        cmd.Parameters.Add(new SqlParameter("@companyId", companyId));
        SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sqlAdp.Fill(ds);
        DataTable table = ds.Tables[0];
        var response = new
        {
          status = 200,
          purchaseTrx = table
        };
        return Ok(response);
      }
      catch (Exception ex)
      {
        var response = new
        {
          status = 0,
          msg = "Something Went Wrong",
          error = new Exception(ex.Message, ex.InnerException)
        };
        return Ok(response);
      }
    }
    [HttpPost("GetBillPay")]
    public IActionResult GetBillPay([FromBody] dynamic objData)
    {
      try
      {
        dynamic jsonObj = objData;
        int companyId = jsonObj[0].companyId;
        int? transactionId = jsonObj[0].transactionId;
        int? searchContactId = jsonObj[0].searchContactId;
        int? UserID = jsonObj[0].UserID;
        int? numRecords = jsonObj[0].numRecords;
        int? amountFrom = jsonObj[0].amountFrom;
        int? amountUpto = jsonObj[0].amountUpto;
        int? sessionStoreID = jsonObj[0].sessionStoreID;
        DateTime? dateFrom = jsonObj[0].dateFrom;
        DateTime? dateTo = DateTime.Now;

        SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        sqlCon.Open();
        SqlCommand cmd = new SqlCommand("dbo.BillPayIndex", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@transactionId", transactionId));
        cmd.Parameters.Add(new SqlParameter("@searchContactId", searchContactId));
        cmd.Parameters.Add(new SqlParameter("@fromDate", dateFrom));
        cmd.Parameters.Add(new SqlParameter("@toDate", dateTo));
        cmd.Parameters.Add(new SqlParameter("@sessionStoreID", sessionStoreID));
        cmd.Parameters.Add(new SqlParameter("@userId", UserID));
        cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords + 1));
        cmd.Parameters.Add(new SqlParameter("@amountFrom", amountFrom));
        cmd.Parameters.Add(new SqlParameter("@amountUpto", amountUpto));
        cmd.Parameters.Add(new SqlParameter("@companyId", companyId));

        DataSet ds = new DataSet();
        SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        sqlAdp.Fill(ds);

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
    [HttpPost("Update")]
    public ActionResult Update(JObject objData)
    {
      try
      {
        dynamic jsonObj = objData;
        int companyId = jsonObj.companyId;
        int userId = jsonObj.userId;
        Transaction trans = jsonObj.ToObject<Transaction>();
        trans = jsonObj.ToObject<Transaction>();
        JArray items = jsonObj.items;
        dynamic creditArr = items.ToList();

        TransControllerExt.UpdateTrans(db, trans, false, companyId);
        TransControllerExt.BillnPaysEdit(db, creditArr);
        db.SaveChanges();
        var response = new
        {
          status = 200,
          transactionId = trans.TransactionId,
          msg = "Data Updated Successfully"
        };
        return Json(response);
      }
      catch (Exception ex)
      {
        var response = new
        {
          status = 0,
          msg = "Something Went Wrong",
          error = new Exception(ex.Message, ex.InnerException)
        };
        return Ok(response);
      }
    }
    [HttpPost("Submit")]
    public IActionResult Submit([FromBody] dynamic objData)
        {
      dynamic jsonObj = objData;
      int companyId = jsonObj[0].companyId;
      int transId = 0;
      bool result = false;
      string errorMsg = "";
      Transaction trans = new Transaction();
      trans.TransDateTime = DateTime.Now;
      trans.CreatedDate = DateTime.Now;
      trans = jsonObj[0].trans.ToObject<Transaction>();
      JArray creditArr = jsonObj[0].creditArr;
      string type = jsonObj[0].type;
      int UserId = jsonObj[0].UserId;
      int transType = (int)TransTypeEnum.Purchase;
      bool isIncoming = false;
      bool isPlanned = false;
      int userId = UserId;
      List<PlannedTrans> planTrans = null;
      trans.TranstypeId = transType;
      if (trans.IsReturn == true)
      {
        transType = (int)TransTypeEnum.Purchase_Refund;
        isIncoming = true;
      }
      if (type == "EmpAcc") transType = (int)TransTypeEnum.Emp_Refund;
      try
      {

        DateTime transDate =
         FormatExt.GetDateTimeSave(Convert.ToString(trans.TransDateStr), trans.TransTime);
        planTrans = db.PlannedTrans.Where(p => p.ContactId == trans.ContactId && p.StoreId == trans.StoreId && p.StatusCode != "CLS" && p.CompanyId == companyId).ToList();
        if (planTrans.Count > 0)
        {
          isPlanned = true;
        }
        TransControllerExt.CreateTrans(db, trans, isIncoming);
        TransControllerExt.BillnPays(db, creditArr, trans.TransactionId, userId,companyId);

        db.SaveChanges();
        transId = trans.TransactionId;
        result = true;
      }
      catch (Exception e)
      {
        errorMsg = e.Message;
      }
      var data = new { errorMsg = errorMsg, transId = transId, result = result, isPlanned = isPlanned, planTrans = planTrans.FirstOrDefault() };
      return Json(data);
    }


    [HttpGet("DeleteBillPay")]
    public ActionResult DeleteBillPay(int id, int companyId)
    {
      try
      {
        TransControllerExt.DelTransnUpdBill(db, id, companyId);
        db.SaveChanges();
        var response = new
        {
          status = 200,
          transactionId = id,
          msg = "Data Deleted Successfully"
        };
        return Json(response);
      }
      catch (Exception ex)
      {
        var response = new
        {
          status = 0,
          msg = "Something Went Wrong",
          error = new Exception(ex.Message, ex.InnerException)
        };
        return Ok(response);
      }
    }
    [HttpPost("GetPendingBills")]
    public IActionResult GetPendingBills([FromBody] dynamic objData)
    {
      try
      {
        dynamic jsonObj = objData;
        int companyId = jsonObj[0].companyId;
        int? searchContactId = jsonObj[0].searchContactId;
        int? UserID = jsonObj[0].UserID;
        int? numRecords = jsonObj[0].numRecords;
        int? amountFrom = jsonObj[0].amountFrom;
        int? amountUpto = jsonObj[0].amountUpto;
        int? sessionStoreID = jsonObj[0].sessionStoreID;
        DateTime? dateTo = DateTime.Now;

        SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("myconn"));
        sqlCon.Open();
        SqlCommand cmd = new SqlCommand("dbo.BillsByVendorIndex", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@searchContactId", searchContactId));
        cmd.Parameters.Add(new SqlParameter("@uptoDate", dateTo));
        cmd.Parameters.Add(new SqlParameter("@sessionStoreID", sessionStoreID));
        cmd.Parameters.Add(new SqlParameter("@userId", UserID));
        cmd.Parameters.Add(new SqlParameter("@numRecords", numRecords + 1));
        cmd.Parameters.Add(new SqlParameter("@companyId", companyId));

        DataSet ds = new DataSet();
        SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
        sqlAdp.Fill(ds);

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
    [HttpGet("GetBillsPayVendor")]
    public IActionResult GetBillsPayVendor(int? storeId, int vendorId)
    {
      //TransControllerExt.TransMode(this, db, "Out");
      var transDate = FormatExt.GetDateView(DateTime.Now.Date);
      var transTime = FormatExt.GetTime(DateTime.Now); var Flow = "Bill";

      var data =  setBillView1(1, vendorId, storeId, "");
      return Ok(data);
    }
    public IActionResult setBillView1(int? companyId, int? vendorId, int? storeId, string toDate = "")
    {
      var bills = db.Bill.Where(s => s.ProviderId == vendorId &&
               ((s.PaymentStoreId == null && s.ReceiverId == storeId) || s.PaymentStoreId == storeId) && s.CompanyId == companyId)
               .Where(s => s.BillType == (int)BillTypeEnum.Purchase || s.BillType == (int)BillTypeEnum.Maintenance)
               .Where(s => s.PaidAmount < s.BillAmount);
      if (!string.IsNullOrEmpty(toDate.ToString()))
      {
        DateTime date = DateTime.ParseExact(toDate, "dd-MM-yyyy HH:mm", null);
        //bills = bills.Where(s => s.ReceivedDate.DateTime.Date <= date);
      }
      var billList = bills.ToList();

      var contactId = vendorId;
      int? PaymentStoreId;
      var contact = db.Contacts.Where(c => c.Id == vendorId && c.CompanyId == companyId).FirstOrDefault().Name;
      if (storeId != null)
        PaymentStoreId = storeId;
      var paymentStore = db.Stores.Where(c => c.Id == storeId && c.CompanyId == companyId).FirstOrDefault().Name;

      var credit = db.Bill.Where(s => s.ReceiverId == vendorId && s.CompanyId == companyId && s.CompanyId == companyId)
                   .Where(s => s.ProviderId == storeId)
                   .Where(s => s.BillType == (int)BillTypeEnum.Credit)
                   .Where(s => s.PaidAmount < s.BillAmount).ToList();

      var balance = TransControllerExt.calcBalance(billList);
      var creditBalance = TransControllerExt.calcBalance(credit);
      var data = new { billList = billList, paymentStore = paymentStore, credit = credit, balance = balance, creditBalance = creditBalance };
      return Ok(data);
    }
    public IActionResult setBillView1(int companyId, int? vendorId, int? storeId, string toDate = "")
      {
      var bills = db.Bill.Where(s => s.ProviderId == vendorId &&
               ((s.PaymentStoreId == null && s.ReceiverId == storeId) || s.PaymentStoreId == storeId) && s.CompanyId == companyId)
               .Where(s => s.BillType == (int)BillTypeEnum.Purchase || s.BillType == (int)BillTypeEnum.Maintenance)
               .Where(s => s.PaidAmount < s.BillAmount).ToList();
      if (!string.IsNullOrEmpty(toDate.ToString()))
      {
        DateTime date = DateTime.ParseExact(toDate, "dd-MM-yyyy HH:mm", null);
        //bills = bills.Where(s => s.ReceivedDate <= date);
      }
      var billList = bills.ToList();

      var contactId = vendorId;
      var contact = db.Contacts.Where(c => c.Id == vendorId && c.CompanyId == companyId).FirstOrDefault().Name;
      if (storeId != null)
       ViewBag.paymentStoreId = storeId;
      var paymentStore = db.Stores.Where(c => c.Id == storeId && c.CompanyId == companyId).FirstOrDefault().Name;

      var credit = db.Bill.Where(s => s.ReceiverId == vendorId && s.CompanyId == companyId && s.CompanyId == companyId)
                   .Where(s => s.ProviderId == storeId)
                   .Where(s => s.BillType == (int)BillTypeEnum.Credit)
                   .Where(s => s.PaidAmount < s.BillAmount).ToList();

      var balance = TransControllerExt.calcBalance(bills);
      var creditBalance = TransControllerExt.calcBalance(credit);

      var data = new
      {
        //PaymentStoreId = paymentStoreId,
        PaymentStore = paymentStore,
        bills = bills,
        contactId = contactId,
        billList = billList,
        credit = credit,
        Balance = balance,
        CreditBalance = creditBalance
      };
      return Ok(data);
    }
    public IActionResult setBillView(int id, int companyId, int? storId, string toDate = "")
    {
      int? PaymentStoreId; string PaymentStore;
      var bills = from bt in db.Contacts
                  join b in db.Bill on bt.Id equals b.ContactId
                  join s in db.Stores on b.StoreId equals s.Id
                  where (b.BillId == id)
                  select new
                  {
                    bt.Name,
                    b.ProviderId,
                    b.ReceiverId,
                    b.PaymentStore,
                    b.PaymentStoreId,
                    b.Provider,
                    b.Receiver,
                    b.BillAmount,
                    b.BillDate,
                    b.BillId,
                    b.PendAmount,
                    b.PaidAmount
                  };
      var bill = db.Bill.Where(s => s.BillId == id && s.CompanyId == companyId).ToList();
      var contactId = bill.FirstOrDefault().ProviderId;
      var contact = bills.FirstOrDefault().Provider.Name;

      var storeId = bill.FirstOrDefault().ReceiverId;
      var storeName = bills.FirstOrDefault().Receiver.Name;

      if (bills.FirstOrDefault().PaymentStore != null)
      {
        PaymentStoreId = bill.FirstOrDefault().PaymentStoreId;
        PaymentStore = bills.FirstOrDefault().PaymentStore.Name;
        PaymentStoreId = bill.FirstOrDefault().PaymentStoreId;
      }
      else
      {
         PaymentStoreId = bill.FirstOrDefault().ReceiverId;
        PaymentStore = bills.FirstOrDefault().Receiver.Name;
        PaymentStoreId = bill.FirstOrDefault().ReceiverId;
      }
      var BillId = id;
     List <Bill> billList = bill.ToList();
      var credit = db.Bill.Where(s => s.ReceiverId == bills.FirstOrDefault().ProviderId && s.CompanyId == companyId)
                          .Where(s => s.ProviderId == PaymentStoreId)
                         .Where(s => s.BillType == (int)BillTypeEnum.Credit)
                         .Where(s => s.PaidAmount < s.BillAmount).ToList();

      var Balance = TransControllerExt.calcBalance(bill);
      var CreditBalance = TransControllerExt.calcBalance(credit);
      var data = new
      {
        PaymentStoreId = PaymentStoreId,
        PaymentStore = PaymentStore,
        bills = bills,
        contactId = contactId,
        billList = billList,
        credit = credit,
        Balance = Balance,
        CreditBalance = CreditBalance
      };
      return Ok(data);
    }
    [HttpPost("BillPayFor")]
    public IActionResult BillPayFor([FromBody] dynamic objData)
    {
      try
      {
        dynamic jsonObj = objData;
        string toDate = jsonObj[0].toDate;
        string viewType = jsonObj[0].viewType;
        int companyId = jsonObj[0].companyId;
        int? storeId = jsonObj[0].storeId;
        int? vendorId = jsonObj[0].vendorId;
        int? numRecords = jsonObj[0].numRecords;
        object bills;
        IEnumerable<TransMode> transMode = TransControllerExt.TransMode(db, "Out");

        var transDate = FormatExt.GetDateView(DateTime.Now.Date);
        var transTime = FormatExt.GetTime(DateTime.Now);
        var BankAccount = db.BankAccounts.Where(s => s.CompanyId == companyId).ToList();
        if (viewType == "ID")
        {
          bills = setBillView((int)vendorId, companyId,null,"");
        }
        else
        {
          bills = setBillView1(companyId, vendorId, storeId, toDate);

        }
        //var balance = TransControllerExt.calcBalance(ViewBag.Bills);

        var response = new
        {
          status = 200,
          bills = bills,
          transMode = transMode
        };
        return Ok(response);
      }
      catch (Exception ex)
      {
        var response = new
        {
          status = 0,
          msg = "Something Went Wrong",
          error = new Exception(ex.Message, ex.InnerException)
        };
        return Ok(response);
      }
    }
    [HttpGet("EditBillPay")]
    public IActionResult EditBillPay(int? id, string billType,int compId)
    {
      int companyId = compId;
      if (id == null)
      {
        return Ok();
      }
      var Flow = "Bill";
      //Transaction trans = db.Transactions.Find(id);
      var trans = from bt in db.Transactions
                  join b in db.Contacts on bt.ContactId equals b.Id
                  join s in db.Stores on bt.StoreId equals s.Id
                 join p in db.PaymentTypes on bt.PaymentTypeId equals p.Id
                  where (bt.TransactionId == id && bt.CompanyId == compId)
                  select new
                  {
                    bt.ContactId,  bt.Contact, bt.StoreId,bt.Store,
                    bt.TransactionId, bt.TransDateTime, bt.TransModeId,
                    bt.TranstypeId,bt.Amount,bt.PaymentTypeId,bt.PaymentType
                  };
                    var ContactId = trans.FirstOrDefault().ContactId;
      var Contact = trans.FirstOrDefault().Contact;

      var PaymentStoreId = trans.FirstOrDefault().StoreId;
      var PaymentStore = trans.FirstOrDefault().Store.Name;
      var  TransId = trans.FirstOrDefault().TransactionId;
      var  Transaction = trans;

      var transDate = FormatExt.GetDateView(trans.FirstOrDefault().TransDateTime);
     var transTime = FormatExt.GetTime(trans.FirstOrDefault().TransDateTime);
      //TransControllerExt.LoadViewBagEdit(this, db, trans,"Out");

      //var billRepays = db.BillPay.Include(s => s.Bill)
      //                    .Where(s => s.TransactionId == id && s.CreditMappingId == null && s.CompanyId == companyId).ToList();

      var billRepays = db.BillPay.Include(s => s.Bill)
                         .Where(s => s.TransactionId == id  && s.CompanyId == companyId).ToList();
      var BillRepays = billRepays;
      var Balance = TransControllerExt.calcBalanceEdit(BillRepays);
      var Bills = billRepays.Select(s => s.Bill).ToList();
      //ViewBag.Bills = db.Bills.Where(s => s.ProviderId == trans.ContactId)
      //            .Where(s => s.BillType == (int)BillTypeEnum.Purchase || s.BillType == (int)BillTypeEnum.Maintenance)
      //            .Where(s => s.PaidAmount < s.BillAmount).ToList();
      var BalanceAfter = TransControllerExt.calcBalance(Bills);
      //FormatExt.ViewAccess(this, 3343);
      var Action = "Update";
      var BillType = billType;
      var data = new
      {
        bill = Bills,
        balanceAfter = BalanceAfter,
        BillRepays = billRepays,
        trans = Transaction,
        paymentStore = PaymentStore,
        paymentStoreId = PaymentStoreId,
      };
      return Ok(data);
    }

    [HttpPost("Updatebill")]
    public IActionResult Updatebill([FromBody]dynamic objData)
    {
      dynamic jsonObj = objData;
      int companyId = jsonObj[0].compId;
      bool result = false;
      int transId = 0;
      JArray creditArr = jsonObj[0].creditArr;
      Transaction trans = jsonObj[0].trans.ToObject<Transaction>();
      trans = jsonObj[0].trans.ToObject<Transaction>();

      string errorMsg = "";
      try
      {
        Transaction oldTrans = db.Transactions.Where(d => d.TransactionId == trans.TransactionId && d.CompanyId == companyId).FirstOrDefault();
        //int transHistoryId = SaveHistory(db, "Transactions", oldTrans.TransactionId, oldTrans, null, "Update", "Purchase");
        //trans.CreatedBy = oldTrans.CreatedBy;
        trans.CreatedDate = DateTime.Now ;
        var oldBillPays = db.BillPay.Where(b => b.TransactionId == trans.TransactionId && b.CompanyId == companyId).ToList();

        foreach (BillPay billPay in oldBillPays)
        {
         //HistoryExt.SaveHistory(db, "BillPays", billPay.BillPayId, billPay, transHistoryId, "Update", "Purchase");
        }

        TransControllerExt.UpdateTrans(db, trans, false,companyId);
        TransControllerExt.BillnPaysEdit(db, creditArr);
        db.SaveChanges();
        result = true;
        transId = trans.TransactionId;
      }
      catch (Exception e)
      {
        errorMsg = e.Message;
        var a = e.GetHashCode();
        result = false;
      }
      var data = new { errorMsg = errorMsg, result = result, transId = transId };
      return Json(data);
    }
    //public void setBillView(int? id, compId)
    //{
    //  int companyId = compId;
    //  int? PaymentStoreId;
    //  var bills = db.Bill.Where(s => s.BillId == id && s.CompanyId == companyId);
    //  var ContactId = bills.FirstOrDefault().ProviderId;
    //  var Contact = bills.FirstOrDefault().Provider.Name;

    //  var StoreId = bills.FirstOrDefault().ReceiverId;
    //  var StoreName = bills.FirstOrDefault().Receiver.Name;

    //  if (bills.FirstOrDefault().PaymentStore != null)
    //  {
    //    var paymentStoreId = bills.FirstOrDefault().PaymentStoreId;
    //    var PaymentStore = bills.FirstOrDefault().PaymentStore.Name;
    //    PaymentStoreId = bills.FirstOrDefault().PaymentStoreId;
    //  }
    //  else
    //  {
    //    var paymentStoreId = bills.FirstOrDefault().ReceiverId;
    //    var PaymentStore = bills.FirstOrDefault().Receiver.Name;
    //    PaymentStoreId = bills.FirstOrDefault().ReceiverId;
    //  }
    //  var BillId = id;
    //  var Bills = bills.ToList();
    //  var Credit = db.Bill.Where(s => s.ReceiverId == bills.FirstOrDefault().ProviderId && s.CompanyId == companyId)
    //                .Where(s => s.ProviderId == PaymentStoreId)
    //               .Where(s => s.BillType == (int)BillTypeEnum.Credit)
    //               .Where(s => s.PaidAmount < s.BillAmount).ToList();

    //  var Balance = TransControllerExt.calcBalance(ViewBag.Bills);
    //  var CreditBalance = TransControllerExt.calcBalance(ViewBag.Credit);

    //}

    [HttpGet("PayBillFor")]
    public IActionResult PayBillFor(int? id, int? storeId, int companyId, int? vendorId, string viewType = "", string billType = "", string toDate = "")
    {
      var ToDate = toDate;
      var Action = "Submit";
      int compId = companyId;
      object vv;
      TransControllerExt.LoadViewBag( db, "Out", compId);
      var transDate = FormatExt.GetDateView(DateTime.Now.Date);
      var transTime = FormatExt.GetTime(DateTime.Now);
      var Flow = "Bill";
      var bill = db.Bill.Where(s => s.BillId == id && s.CompanyId == companyId).ToList();

      //FormatExt.ViewAccess(this, 3343);
      ViewData.Add("BankAccount", new SelectList(db.BankAccounts,
              "BankAccountId", "AccountNo"));
      if (billType == "PI")
      {
        var PurchaseInvoice = "PI-";
      }
      else if (billType == "MI")
      {
        var MaintInvoice = "MI-";
      }
      var BillType = billType;
      if (viewType == "ID")
      {
         vv= setBillView1(id, compId, storeId, ToDate);
        var ViewType = "ID";
        var BillId = id;
        return Ok();
      }
      else
      {
        var ViewType = "Vendor";
        vv = setBillView1(compId, vendorId, storeId, ToDate);
      }
      var Balance = TransControllerExt.calcBalance(bill);
      var data = new
      {
        bill = vv,
       balance= Balance
      };
      return Ok(data);
    }

    [HttpGet("BillPayDetails")]
    public IActionResult BillPayDetails(int? id, int compId, string view = "")
    {
      int companyId = compId;
      if (id == null)
      {
        return Ok();
      }

      TransControllerExt.LoadViewBillTrx(db, id,companyId);
      //int contactId = ContactId;
      var BillRepays =
          db.BillPay.Include(s => s.Bill)
                          .Where(s => s.TransactionId == id && s.CompanyId == companyId).ToList();


      var totalBillRepays = db.BillPay.Include(s => s.Bill)
                          .Where(s => s.TransactionId == id  && s.CompanyId == companyId).ToList();

      var TotalBillRepays = totalBillRepays;

      var Balance = TransControllerExt.calcBalanceEdit(TotalBillRepays);

      var Bills = totalBillRepays.Select(s => s.Bill).ToList();

      var BalanceAfter = TransControllerExt.calcBalance(Bills);
      var TransactionId = id;
      var data = new
      {
        billRepays = BillRepays,
        balanceAfter = BalanceAfter,
        bills = Bills,
        balance = Balance
      };
      return Ok(data);

    }


  }
}
