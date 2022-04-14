using Lab1.Data;
using Lab1.Entities;
using Lab1.Entities.Other;
using Lab1.Entities.Undo;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab1.Controllers;

public class ClientController : Controller
{
    private ApplicationDbContext _context;

    public ClientController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult ClientProfile()
    {
        var id = _context.Users.FirstOrDefault(x => x.Email.Equals(User.Identity.Name)).Id;
        ClientPageModel model = new()
        {
         Banks = _context.Banks.ToList(),
         Bills = _context.Bills.Where(x => x.ClientId == id).Select(x => x).ToList(),
         CreditInfos = _context.CreditInfos.ToList()
        };
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBill(ClientPageModel model)
    {
        var id = _context.Users.FirstOrDefault(x => x.Email.Equals(User.Identity.Name)).Id;
        Bill bill = new()
        {
            // Id = _context.Bills.ToList()[^1].Id + 1,
            BankId = model.SelectedBankId,
            Bank = _context.Banks.FirstOrDefault(x => x.Id == model.SelectedBankId),
            ClientId = id,
            State = State.Active
        };
        
        if (string.IsNullOrEmpty(model.BillName))
        {
            bill.Name = "default name";
        }
        else
        {
            bill.Name = model.BillName;
        }
        BillCreation billCreation = new()
        {
            // Id = _context.BillCreations.ToList()[^1].Id + 1,
            Name = bill.Name,
            BankName = bill.Bank.Name,
            ClientId = (int)bill.ClientId
        };
        _context.BillCreations.Add(billCreation);
        _context.Bills.Add(bill);
        _context.SaveChangesAsync();
        return RedirectToAction("ClientProfile");
    }
    [HttpPost]
    public async Task<IActionResult> PaymentRequest(int billId, int bankId)
    {
        RequestMoney requestMoney = new()
        {
            BillId = billId,
            ClientId = _context.Clients.FirstOrDefault(x => x.Email.Equals(User.Identity.Name)).Id,
            IsAproved = false
        };
        _context.RequestMonies.Add(requestMoney);
        _context.SaveChangesAsync();
        return RedirectToAction("ClientProfile");
    }
    [HttpPost]
    public async Task<IActionResult> FreezeBill(int billId)
    {
        _context.Bills.FirstOrDefault(x => x.Id == billId).State = State.Freezed;
        _context.SaveChangesAsync();
        return RedirectToAction("ClientProfile");
    }
    
    [HttpPost]
    public async Task<IActionResult> BlockBill(int billId)
    {
        _context.Bills.FirstOrDefault(x => x.Id == billId).State = State.Blocked;
        _context.SaveChangesAsync();
        return RedirectToAction("ClientProfile");
    }

    [HttpPost]
    public async Task<IActionResult> MakeActiveBill(int billId)
    {
        _context.Bills.FirstOrDefault(x => x.Id == billId).State = State.Active;
        _context.SaveChangesAsync();
        return RedirectToAction("ClientProfile");
    }

    [HttpPost]
    public async Task<IActionResult> SendMoney(ClientPageModel model)
    {
        var myBill = _context.Bills.FirstOrDefault(x => x.Id == model.SelectedBillId);
        var transferBill = _context.Bills.FirstOrDefault(x => x.Id == model.TransferBillId);
        if (transferBill != null && (int)myBill.Money >= model.TransferMoney)
        {
            Transfer transfer = new()
            {
                Money = model.TransferMoney,
                FromId = myBill.Id,
                ToId = transferBill.Id,
                Display = true
            };
            myBill.Money -= model.TransferMoney;
            transferBill.Money += model.TransferMoney;
            _context.Bills.Update(myBill);
            _context.Bills.Update(transferBill);
            _context.Transfers.Add(transfer);
            _context.SaveChangesAsync();
        }
        return RedirectToAction("ClientProfile");
    }

    public IActionResult CreditPage(int billId, bool plan)
    {
        
        var bill = _context.Bills.FirstOrDefault(x => x.Id == billId);
        var client = _context.Clients.FirstOrDefault(x => x.Id == bill.ClientId);
        CreditModel model = new()
        {
            BillId = billId,
            ClientEmail = client.Email,
            BillName = bill.Name,
            Durations = new(),
            Procents = new(),
            Plan = plan
        };
        if (plan)
        {
            model.Procents.Add(0);
            model.Procents.Add(0);
            model.Procents.Add(0);
            model.Procents.Add(0);
            model.Procents.Add(0);
        }
        else
        {
            model.Procents = _context.CreditInfos.ToList().Where(x => x.BankId == bill.BankId).Select(x => x.Procent).ToList();
        }
        model.Durations = _context.CreditInfos.ToList().Where(x => x.BankId == bill.BankId).Select(x => x.Duration).ToList();
        return View(model);
    }

    public IActionResult CreateCredit(CreditModel model, int billId)
    {
        var bill = _context.Bills.FirstOrDefault(x => x.Id == billId);
        var creditInfo = _context.CreditInfos.ToList()
            .Where(x => x.BankId == bill.BankId).ToList();
        var info = creditInfo[model.SelectedCreditInfo - 1];
        DateTime dateTime = DateTime.Now;
        Credit credit = new()
        {
            Money = model.Money,
            Status = "Not approved",
            ClientId = (int)bill.ClientId,
            BankId = (int)bill.BankId,
            Percent = model.Plan? 0:info.Procent ,
            StartTime = dateTime.ToString(),
            EndTime = "in " + info.Duration + " months"
        };
        _context.Credits.Add(credit);
        _context.SaveChangesAsync();
        return  RedirectToAction("ClientProfile");
    }

    public IActionResult WithdrawMoney(ClientPageModel model,int billId)
    {
        var bill = _context.Bills.FirstOrDefault(x => x.Id == billId);
        if (model.WMoney > bill.Money)
        {
            return RedirectToAction("ClientProfile");
        }

        bill.Money -= (double)model.WMoney;
        _context.Bills.Update(bill);
        _context.SaveChangesAsync();
        return RedirectToAction("ClientProfile");
    }
}