using Lab1.Data;
using Lab1.Entities;
using Lab1.Entities.Other;
using Lab1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Lab1.Controllers;

public class ManagerController : Controller
{
    // GET
    private ApplicationDbContext _context;

    public ManagerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "manager")]
    public IActionResult ManagerProfile()
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
        
        
        var credits = _context.Credits.ToList();
        List<CreditDisplayModel> creditModel = new();
        foreach (var credit in credits)
        {
            if (credit.Status.Equals(Status.NotApproved))
            {
                CreditDisplayModel creditDisplayModel = new()
                {
                    Id = credit.Id,
                    Money = credit.Money,
                    Procent = credit.Percent,
                    BankName = _context.Banks.FirstOrDefault(x => x.Id == credit.BankId).Name,
                    BillId = credit.BillId,
                    EndTime = credit.EndTime,
                    StartTime = credit.StartTime
                };
                creditModel.Add(creditDisplayModel);
            }
        }

        List<UserApproveModel> userApproveModel = new();
        foreach (var client in _context.Clients.Where(x => x.IsAproved == false))
        {
            userApproveModel.Add(new UserApproveModel()
            {
                Email = client.Email,
                IdentificationNumber = client.IdentificationNumber,
                PhoneNumber = client.PhoneNumber,
                SeriesAndPassportNumber = client.SeriesAndPassportNumber
            });
        }
        ManagerModel managerModel = new()
        {
            OperatorModel = model,
            CreditDisplayModels = creditModel,
            UserModels = userApproveModel
        };
        return View(managerModel);
    }

    [Authorize(Roles = "manager,admin")]
    [HttpPost]
    public async Task<IActionResult> Approve(int creditId)
    {
        var credit = _context.Credits.FirstOrDefault(x => x.Id == creditId);
        credit.Status = Status.Approved;
        _context.Bills.FirstOrDefault(x => x.Id == credit.BillId).Money += credit.Money;
        credit.StartTime = DateTime.Now.ToString();
        _context.Credits.Update(credit);
        _context.SaveChangesAsync();
        Log.Information($"{User.Identity.Name} approved credit with id {creditId}");

        return RedirectToAction("Profile", "Account");
    }
    
    [Authorize(Roles = "manager,admin")]
    [HttpPost]
    public async Task<IActionResult> ApproveClient(string email)
    {
        _context.Clients.FirstOrDefault(x => x.Email.Equals(email)).IsAproved = true;
        _context.SaveChangesAsync();
        Log.Information($"{User.Identity.Name} approved client with email {email}");
        return RedirectToAction("Profile", "Account");
    }
}