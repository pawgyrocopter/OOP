using System.Text;
using Lab1.Data;
using Lab1.Entities;
using Lab1.Entities.Other;
using Lab1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lab1.Controllers;

public class AdminController : Controller
{
    private ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "admin")]
    public IActionResult AdminProfile()
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
        var billCreations = _context.BillCreations.ToList();

        string str ="";
        foreach (var path in Directory.EnumerateFiles(@"wwwroot/Logs"))
        {
            using (var fs = new FileStream(path, FileMode.Open,
                       FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                str += sr.ReadToEnd();
            }
        }
        


        AdminPageModel adminPageModel = new()
        {
            BillCreations = billCreations,
            ManagerModel = managerModel,
            LogInfo = str
        };
        return View(adminPageModel);
    }

    [Authorize(Roles = "admin")]
    public IActionResult DeleteBill()
    {
        Log.Information("qweqwe");
        return RedirectToAction("haha", "Home");
    }
}