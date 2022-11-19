using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperMarketApi.Models;
using SuperMarketApi.Models.Enum;

namespace SuperMarketApi.Controllers
{
  [Route("api/[controller]")]
  public class TransControllerExt : Controller
  {
    private POSDbContext db;
    public IConfiguration Configuration { get; }
    public TransControllerExt(POSDbContext contextOptions, IConfiguration configuration)
    {
      db = contextOptions;
      Configuration = configuration;
    }
    public static IEnumerable<TransMode> TransMode(POSDbContext db, string flow)
    {
      //controller.ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName");
      //var transModes = mCache.GetOrSet("TransModes",
      //                    () => CacheController.GetTransMode(db));
      IEnumerable<TransMode> transModes = db.TransModes;
      if (flow == "In") transModes = transModes.Where(i => i.IsIn == true);
      else if (flow == "Out") transModes = transModes.Where(i => i.IsOut == true);
      else if (flow == "Store") transModes = transModes.Where(i => i.IsStoreTrx == true);
      return transModes;
    }
    public static bool CreateTrans(POSDbContext db, Transaction trans, bool isIncoming)
    {
      bool isNegativeBalance = false;
      trans.IsIncoming = isIncoming;
      trans.CreatedDate = DateTime.Now;
      trans.TransDateTime = DateTime.Now;
      trans.TransDate = DateTime.Now;
      trans.ChequeDate = DateTime.Now;
      db.Transactions.Add(trans);
      db.SaveChanges();
      if (trans.TransModeId == (int)TransModeEnum.Cheque)
      {
        // trans.ChequeDate = FormatExt.GetDateTimeSave(Convert.ToString(trans.ChequeDateStr), null);
        Cheque cheque = new Cheque(trans.ChequeNo,
            trans.Amount, (DateTime)trans.ChequeDate, trans.TransactionId);
        cheque.Status = (int)ChequeStatusEnum.Issued;
        cheque.CompanyId = trans.CompanyId;
        db.Cheques.Add(cheque);
      }
      else if (IsBankTrans((int)trans.TransModeId))
      {
        BankAccount account = db.BankAccounts.Find(trans.BankAccountId);
        if (isIncoming == true)
        {
          isNegativeBalance = ChangeBankBalance(account, trans.Amount);
        }
        else if (isIncoming == false)
        {
          isNegativeBalance = ChangeBankBalance(account, -trans.Amount);

        }
      }
      return isNegativeBalance;
    }
    public static Bill CreateBillForTrans(POSDbContext db, Transaction trans,
       int billType, DateTime billDate)
    {
      Bill bill = new Bill();
      if (trans.IsIncoming == true)
      {
        bill.ReceiverId = trans.StoreId;
        bill.ProviderId = (int)trans.ContactId;
      }
      else
      {
        bill.ProviderId = trans.StoreId;
        bill.ReceiverId = (int)trans.ContactId;
      }
      bill.BillAmount = trans.Amount;
      bill.BillType = billType;
      bill.ReceivedDate = billDate;
      bill.BillDate = billDate;
      if (bill.BillAmount - bill.PaidAmount > 0) bill.IsPaid = false;
      else bill.IsPaid = true;
      bill.CompanyId = trans.CompanyId;
      db.Bill.Add(bill);
      return bill;
    }
    public static void BillnPays(POSDbContext db, dynamic billArr, int transId, int userId, int companyId)
    {
      for (int i = 0; i < billArr.Count; i++)
      {
        double pay = billArr[i].pay;

        if (pay > 0)
        {
          int billId = billArr[i].billId;
          double pastPaid = billArr[i].paidAmount;
          var bill = db.Bill.Find(billId);
          bill.CreatedDate = DateTime.Now;
          //bill.CreatedBy = userId;
          bill.PaidAmount = pastPaid + pay;

          if (bill.BillAmount - bill.PaidAmount > 0) bill.IsPaid = false;
          else bill.IsPaid = true;
          db.Entry(bill).State = EntityState.Modified;
          BillPay billPay = new BillPay(billId, transId, pay);
          billPay.CompanyId = bill.CompanyId;
          billPay.CreatedDate = DateTime.Now;
          billPay.Amount = bill.PaidAmount;
          db.BillPay.Add(billPay);
          db.SaveChanges();
          var planTrans = db.PlannedTrans.Where(p => p.BillId == billId && p.Status.Code != "CLS" && p.CompanyId == companyId).FirstOrDefault();
          if (planTrans != null)
          {
            planTrans.StatusCode = "CLS";
            planTrans.ClosedDate = DateTime.Now;
            db.Entry(planTrans).State = EntityState.Modified;
            db.SaveChanges();
          }
        }
      }
    }
    public static bool UpdateTrans(POSDbContext db, Transaction trans, bool isContactChange, int companyId)
    {
      bool isNegBankBalance = false;
      Transaction transFromDB = db.Transactions.Find(trans.TransactionId);
      int transModeOld = (int)transFromDB.TransModeId;
      int transModeNew = (int)trans.TransModeId;
      double amountOld = transFromDB.Amount;
      double amountNew = trans.Amount;
      int? bankAccountNew = trans.BankAccountId;
      int? bankAccountOld = transFromDB.BankAccountId;

      bool? isIncoming = transFromDB.IsIncoming;
      if (isContactChange == true)
      {
        transFromDB.ContactId = trans.ContactId;
      }
      transFromDB.StoreId = trans.StoreId;
      //transFromDB.CommissionPer = trans.CommissionPer;
      transFromDB.BankAccountId = trans.BankAccountId;
      transFromDB.Amount = amountNew;
      transFromDB.TransModeId = transModeNew;
      //setOptionalFields(transFromDB, trans);
      if (transModeNew == (int)TransModeEnum.Cheque && transModeOld != (int)TransModeEnum.Cheque)
      {
        trans.ChequeDate = FormatExt.GetDateTimeSave(Convert.ToString(trans.ChequeDate), null);
        Cheque cheque = new Cheque(trans.ChequeNo,
            trans.Amount, (DateTime)trans.ChequeDate, trans.TransactionId);
        cheque.CompanyId = companyId;
        db.Cheques.Add(cheque);
      }
      else if (transModeNew != (int)TransModeEnum.Cheque && transModeOld == (int)TransModeEnum.Cheque)
      {
        Cheque cheque = db.Cheques.Where(c => c.IssuedTrxId == trans.TransactionId && c.CompanyId == companyId).FirstOrDefault();
        db.Cheques.Remove(cheque);
      }
      else if (transModeNew == (int)TransModeEnum.Cheque && transModeOld == (int)TransModeEnum.Cheque)
      {
        Cheque cheque = db.Cheques.Where(c => c.IssuedTrxId == trans.TransactionId && c.CompanyId == companyId).FirstOrDefault();
        cheque.Amount = trans.Amount;
        cheque.ChequeDate = (DateTime)trans.ChequeDate;
        cheque.ChequeNo = trans.ChequeNo;
      }
      if (IsBankTrans(transModeNew))
      {
        BankAccount account = db.BankAccounts.Find(bankAccountNew);
        if (isIncoming == true) isNegBankBalance = ChangeBankBalance(account, amountNew);
        else if (isIncoming == false) isNegBankBalance = ChangeBankBalance(account, -amountNew);
      }
      if (IsBankTrans(transModeOld))
      {
        BankAccount account = db.BankAccounts.Find(bankAccountOld);
        if (isIncoming == true) isNegBankBalance = ChangeBankBalance(account, -amountOld);
        else if (isIncoming == false) isNegBankBalance = ChangeBankBalance(account, amountOld);
      }
      return isNegBankBalance;
    }
    public static bool UpdateBillForTrans(POSDbContext db, Transaction trans, int companyId, string creditType = "", int? responsibleById = null)
    {
      bool isError = false;
      var bill = (from b in db.Bill
                  join bt in db.BillTrans on b.BillId equals bt.BillId
                  where bt.BillTransId == trans.TransactionId && bt.CompanyId == companyId
                  select b).FirstOrDefault();
      db.Bill.Attach(bill);
      if (bill.PaidAmount > trans.Amount) isError = true;
      // throw new Exception("Cannot be Edited. Paid amount cannot be greater than Credit amount.");

      Transaction transFromDB = db.Transactions.Find(trans.TransactionId);
      if (transFromDB.IsIncoming == true)
      {
        bill.ReceiverId = trans.StoreId;
        bill.ProviderId = (int)trans.ContactId;
      }
      else
      {
        bill.ProviderId = trans.StoreId;
        bill.ReceiverId = (int)trans.ContactId;
      }

      bill.BillAmount = trans.Amount;

      bill.CreditTypeStr = creditType;
      bill.ResponsibleById = responsibleById;
      return isError;
    }
    public static void BillnPaysEdit(POSDbContext db, dynamic billArr)
    {
      for (int i = 0; i < billArr.Count; i++)
      {
        int billId = billArr[i].BillId;
        int billPayId = billArr[i].BillPayId;
        double oldPaid = billArr[i].OldPaid;
        double oldPay = billArr[i].OldPay;
        double pay = billArr[i].Pay;
        bool? payUpto = billArr[i].PayUpto;

        double newPaid = oldPaid - oldPay + pay;
        var bill = db.Bill.Find(billId);
        bill.PaidAmount = newPaid;
        if (bill.BillAmount - bill.PaidAmount > 0) bill.IsPaid = false;
        else bill.IsPaid = true;
        if (payUpto == true)
          bill.IsPaid = true;
        db.Entry(bill).State = EntityState.Modified;

        BillPay billPay = new BillPay();
        db.BillPay.Attach(billPay);
        billPay.Amount = pay;
        billPay.CompanyId = bill.CompanyId;
        billPay.BillId = bill.BillId;
        billPay.CreatedDate = DateTime.Now;
      }
    }
    public static void DelTransnUpdBill(POSDbContext db, int id, int companyId)
    {
      Transaction trans = db.Transactions.Include(t => t.BankAccount)
          .Where(t => t.TransactionId == id && t.CompanyId == companyId).SingleOrDefault();
      bool? isIncoming = trans.IsIncoming;
      DeleteTrans(db, trans, companyId);
      List<BillPay> billPayList = db.BillPay.Where(b => b.TransactionId == id && b.CompanyId == companyId).ToList();
      for (int i = 0; i < billPayList.Count(); i++)
      {
        BillPay billPay = billPayList[i];
        int billId = billPay.BillId;
        Bill bill = db.Bill.Find(billId);
        bill.PaidAmount -= billPay.Amount;
        bill.IsPaid = false;
      }
      db.BillPay.RemoveRange(billPayList);
    }
    public static void DeleteTrans(POSDbContext db, Transaction trans, int companyId)
    {

      int transMode = (int)trans.TransModeId;
      double amount = trans.Amount;
      bool? isIncoming = trans.IsIncoming;
      if (IsBankTrans((int)trans.TransModeId))
      {
        BankAccount bankAccount = trans.BankAccount;
        if (isIncoming == true)
        {
          ChangeBankBalance(bankAccount, -trans.Amount);
        }
        else if (isIncoming == false)
        {
          ChangeBankBalance(bankAccount, trans.Amount);
        }
      }
      else if (transMode == (int)TransModeEnum.Cheque)
      {
        Cheque cheque = db.Cheques.Where(c => c.IssuedTrxId == trans.TransactionId && c.CompanyId == companyId).FirstOrDefault();
        db.Cheques.Remove(cheque);
      }

      db.Transactions.Remove(trans);
    }
    public static bool ChangeBankBalance(BankAccount account, double amount)
    {
      bool isNegativeBalance = false;
      if (account.AccountTypeCd == "CRD")
      {
        account.Balance -= amount;
      }
      else
      {
        account.Balance += amount;
        if (account.AllowNegative == false && account.Balance < 0)
          isNegativeBalance = true;
      }
      return isNegativeBalance;
    }
    public static bool IsBankTrans(int transModeId)
    {
      if (transModeId == (int)TransModeEnum.Online || transModeId == (int)TransModeEnum.Credit_Card
                  || transModeId == (int)TransModeEnum.Debit_Card || transModeId == (int)TransModeEnum.Bank)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public static void LoadViewBag(
                        POSDbContext db, string flow, int compId)
    {
      int companyId = compId;
      //controller.ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName");
      //var transModes = mCache.GetOrSet("TransModes",
      //                    () => CacheController.GetTransMode(db));
      IEnumerable<TransMode> transModes = db.TransModes;
      if (flow == "In") transModes = transModes.Where(i => i.IsIn == true);
      else if (flow == "Out") transModes = transModes.Where(i => i.IsOut == true);
      else if (flow == "Store") transModes = transModes.Where(i => i.IsStoreTrx == true);
      var TransModeId = new SelectList(transModes
                                   , "TransModeId", "Description");
    }

    public static void LoadViewBagEdit(
     POSDbContext db, Transaction trans, string flow)
    {
      if (trans.Store != null)
      {
        var StoreId = trans.StoreId;
        var StoreName = trans.Store.Name;
      }

      int companyId = trans.CompanyId;
      IEnumerable<TransMode> transModes = db.TransModes;
      if (flow == "In") transModes = transModes.Where(i => i.IsIn == true);
      else if (flow == "Out") transModes = transModes.Where(i => i.IsOut == true);
      else if (flow == "Store") transModes = transModes.Where(i => i.IsStoreTrx == true);
      var TransModeId = new SelectList(
          transModes, "TransModeId", "Description", trans.TransModeId);

      SetBankList( db, (int)trans.TransModeId, trans.BankAccountId, companyId);
      if (trans.TransModeId == 3)
      {
        Cheque cheque = db.Cheques.Where(c => c.IssuedTrxId == trans.TransactionId).FirstOrDefault();
        var chequeDate = cheque.ChequeDate;
        var Cheque = cheque;
      }
      var BankAccountId = db.BankAccounts.Where(b => b.AccountTypeCd != "CRD" && b.Contact.IsActive == true && b.CompanyId == companyId).ToList();
      if (trans.TransModeId == (int)TransModeEnum.Debit_Card)
      {
        BankAccountId = db.BankAccounts.Where(b => b.AccountTypeCd != "CRD" && b.Contact.IsActive == true && b.CompanyId == companyId).ToList();
      }
      if (trans.TransModeId == (int)TransModeEnum.Credit_Card)
      {
        BankAccountId = db.BankAccounts.Where(b => b.AccountTypeCd == "CRD" && b.Contact.IsActive == true).ToList();
      }
    }
    public static void SetBankList(POSDbContext db, int transModeId, int? bankAccId, int compId)
    {
      int companyId = compId;
      var AccList = db.BankAccounts.Where(b => b.AccountTypeCd != "CRD" && b.CompanyId == companyId).
                          Select(b => new SelectListItem
                          {
                            Value = b.Id.ToString(),
                            Text = b.AccountNo
                          }).ToList();

      if (transModeId == (int)TransModeEnum.Credit_Card)
      {
        AccList = db.BankAccounts.Where(b => b.AccountTypeCd == "CRD" && b.CompanyId == companyId).
                        Select(b => new SelectListItem
                        {
                          Value = b.Id.ToString(),
                          Text = b.AccountNo
                        }).ToList();
      }
      var BankAccountId = new SelectList(AccList, "Value", "Text", bankAccId);

    }

    public static double calcBalance(List<Bill> billList)
    {
      double balance = 0;
      for (int i = 0; i < billList.Count(); i++)
      {
        Bill bill = billList[i];
        balance += bill.PendAmount;
      }
      return balance;
    }

    public static double calcBalanceEdit(List<BillPay> billPayList)
    {
      double balance = 0;
      for (int i = 0; i < billPayList.Count(); i++)
      {
        BillPay billPay = billPayList[i];
        balance += billPay.PendAmountEdit;
      }
      return balance;
    }
    public static void LoadViewBillTrx(POSDbContext db, int? transId,int compId)
    {
      int companyId = compId;
      Transaction trans = db.Transactions.Include(t => t.Contact).Include(t => t.Store)
          .Include(t => t.Store).Include(t => t.BankAccount).SingleOrDefault(t => t.TransactionId == transId);
      if (trans.TransModeId == (int)TransModeEnum.Cheque)
      {
        Cheque cheque = db.Cheques.Where(t => t.IssuedTrxId == transId && t.CompanyId == companyId).FirstOrDefault();
      var  Cheque = cheque;
        var ChequeDate = FormatExt.GetDateView(cheque.ChequeDate);
      }
      var Transaction = trans;
      var transDate = FormatExt.GetDateView(trans.TransDateTime);
      //transTime = TransControllerExt.GetTimeAMPM(trans.TransDateTime);
      var ContactId = trans.ContactId;
    }

  }

}
