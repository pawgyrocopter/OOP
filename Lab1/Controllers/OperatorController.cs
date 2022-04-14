using System.Data.Entity;
using Lab1.Data;
using Lab1.Entities;
using Lab1.Entities.Other;
using Lab1.Entities.UserCategories;
using Lab1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lab1.Controllers;

public class OperatorController : Controller
{
    // GET
    private ApplicationDbContext _context;

    public OperatorController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "operator")]
    public IActionResult OperatorProfile()
    {
        List<Transfer> transfers = _context.Transfers.ToList();
        List<RequestMoney> requestMonies = _context.RequestMonies.ToList();
        OperatorModel model = new()
        {
            RequestMoniesModels = new(),
            TransferModels = new()
        };
        foreach (var transfer in transfers)
        {
            if (!transfer.Display) continue;
            var fromBill = _context.Bills.FirstOrDefault(x => x.Id == transfer.FromId);
            var toBill = _context.Bills.FirstOrDefault(x => x.Id == transfer.ToId);
            var fromClient = _context.Clients.FirstOrDefault(x => x.Id == fromBill.ClientId);
            var toClient = _context.Clients.FirstOrDefault(x => x.Id == toBill.ClientId);
            model.TransferModels.Add(new TransferModel()
            {
                TransferId = transfer.id,
                FromBillId = fromBill.Id,
                FromWho = fromClient.Email,
                FromWhoId = fromClient.Id,
                ToWho = toClient.Email,
                ToWhoId = toClient.Id,
                ToBillId = toBill.Id,
            });
        }

        foreach (var requestMoney in requestMonies)
        {
            if (requestMoney.IsAproved) continue;
            var client = _context.Clients.FirstOrDefault(x => x.Id == requestMoney.ClientId);
            requestMoney.Client = client;
            Factory factory = _context.Factories.FirstOrDefault(x => x.Id == client.FactoryId);
            
            model.RequestMoniesModels.Add(new RequestMoneyModel()
            {
                Factory = factory,
                RequestMoney = requestMoney
            });
        }

        return View(model);
    }
    
    [Authorize(Roles = "operator,manager,admin")]
    [HttpPost]
    public async Task<IActionResult>  UndoTransfer(int transferId)
    {
        var transfer = _context.Transfers.FirstOrDefault(x => x.id == transferId);
        var fromBill = _context.Bills.FirstOrDefault(x => x.Id == transfer.FromId);
        var toBill = _context.Bills.FirstOrDefault(x => x.Id == transfer.ToId);
        fromBill.Money += transfer.Money;
        if (toBill.Money < transfer.Money)
        {
            return RedirectToAction("Profile", "Account");
        }
        toBill.Money -= transfer.Money;
        _context.Bills.Update(fromBill);
        _context.Bills.Update(toBill);
        transfer.Display = false;
        _context.Transfers.Update(transfer);
        _context.SaveChanges();
        Log.Information($"{User.Identity.Name} undood transfer with id {transferId}");
        return RedirectToAction("Profile", "Account");
    }


    [Authorize(Roles = "operator,manager,admin")]
    [HttpPost]
    public async Task<IActionResult> Ok(int id)
    {
        var request = _context.RequestMonies.FirstOrDefault(x => x.Id == id);
        request.IsAproved = true;
        var bill = _context.Bills.FirstOrDefault(x => x.Id == request.BillId);
        bill.Money += 10000;
        _context.Bills.Update(bill);
        _context.RequestMonies.Update(request);
        _context.SaveChangesAsync();
        Log.Information($"{User.Identity.Name} approved money request with id {id}");
        return RedirectToAction("Profile", "Account");
    }
}