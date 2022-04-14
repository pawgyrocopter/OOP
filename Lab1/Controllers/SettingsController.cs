using System.Configuration;
using Lab1.Data;
using Lab1.Entities;
using Lab1.Entities.UserCategories;
using Lab1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SQLitePCL;

namespace Lab1.Controllers;

public class SettingsController : Controller
{
    private ApplicationDbContext _context;

    public SettingsController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Settings()
    {
        SettingsModel model = new SettingsModel();
        model.Banks = _context.Banks.ToList();
        model.Factories = _context.Factories.ToList();
        model.Roles = _context.Roles.ToList();
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Settings(SettingsModel model)
    {
        User user = _context.Users.FirstOrDefault(x => x.Email.Equals(User.Identity.Name));
        switch (model.SelectedRoleId)
        {
            case 2:
                break;
        }
        return RedirectToAction("Profile", "Account");
    }
    [Authorize(Roles = "user")]
    public IActionResult ChooseRole()
    {
        SettingsModel model = new()
        {
            Roles = _context.Roles.ToList()
        };
        return View(model);
    }

    [Authorize(Roles = "user")]
    [HttpPost]
    public async Task<IActionResult> ChooseRole(SettingsModel model)
    {
        if (model.SelectedRoleId == 3)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email.Equals(User.Identity.Name));
            user.RoleId = 3;
            Client client = new()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Password = user.Password,
                Role = user.Role,
                RoleId = user.RoleId,
                IsAproved = false,
                IdentificationNumber = user.IdentificationNumber,
                SeriesAndPassportNumber = user.SeriesAndPassportNumber,
                PhoneNumber = user.PhoneNumber,
                Bills = new List<Bill>(),
                Credits = new List<Credit>(),
                Deposits = new List<Deposit>(),
                Plans = new List<Plan>(),
            };
            _context.Users.Remove(user);
            _context.Clients.Add(client);
            _context.SaveChanges();
            Log.Information($"{User.Identity.Name} choosed role with id {user.RoleId}");
        }

        if (model.SelectedRoleId == 6)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email.Equals(User.Identity.Name));
            user.RoleId = 6;
            Operator oper = new Operator()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Password = user.Password,
                Role = user.Role,
                RoleId = user.RoleId,
                IdentificationNumber = user.IdentificationNumber,
                SeriesAndPassportNumber = user.SeriesAndPassportNumber,
                PhoneNumber = user.PhoneNumber,
                OneOperation = false
            };
            _context.Users.Remove(user);
            _context.Operators.Add(oper);
            _context.SaveChanges();
            Log.Information($"{User.Identity.Name} choosed role with id {user.RoleId}");
        }
        if (model.SelectedRoleId == 5)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email.Equals(User.Identity.Name));
            user.RoleId = 5;
            Manager manager = new Manager()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Password = user.Password,
                Role = user.Role,
                RoleId = user.RoleId,
                IdentificationNumber = user.IdentificationNumber,
                SeriesAndPassportNumber = user.SeriesAndPassportNumber,
                PhoneNumber = user.PhoneNumber,
            };
            _context.Users.Remove(user);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            Log.Information($"{User.Identity.Name} choosed role with id {user.RoleId}");
        }
        if (model.SelectedRoleId == 1)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email.Equals(User.Identity.Name));
            user.RoleId = 1;
            Admin admin = new Admin()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Password = user.Password,
                Role = user.Role,
                RoleId = user.RoleId,
                IdentificationNumber = user.IdentificationNumber,
                SeriesAndPassportNumber = user.SeriesAndPassportNumber,
                PhoneNumber = user.PhoneNumber,
            };
            _context.Users.Remove(user);
            _context.Admins.Add(admin);
            _context.SaveChanges();
            Log.Information($"{User.Identity.Name} choosed role with id {user.RoleId}");
        }
        return RedirectToAction("Profile", "Account");
    }
    
    [Authorize(Roles = "client")]
    public IActionResult ChooseBank()
    {
        SettingsModel model = new()
        {
            Banks = _context.Banks.ToList()
        };
        return View(model);
    }

    [Authorize(Roles = "client")]
    [HttpPost]
    public async Task<IActionResult> ChooseBank(SettingsModel model)
    {
        Client client = _context.Clients.FirstOrDefault(x => x.Email.Equals(User.Identity.Name));
        if (model.SelectedBankId != null)
            client.BankId = (int) model.SelectedBankId;
        _context.Clients.Update(client);
        _context.SaveChanges();
        Log.Information($"{User.Identity.Name} choosed bank with id {model.SelectedBankId}");

        return RedirectToAction("Profile", "Account");
    }

    [Authorize(Roles = "client")]
    public IActionResult ChooseFactory()
    {
        SettingsModel model = new()
        {
            Factories = _context.Factories.Where(x => x.IsBank == false).Select(x => x).ToList()
        };
        return View(model);
    }
    
    [Authorize(Roles = "client")]
    [HttpPost]
    public async Task<IActionResult> ChooseFactory(SettingsModel model)
    {
        var id = _context.Clients.FirstOrDefault(x => x.Email.Equals(User.Identity.Name)).Id;
        _context.Clients.FirstOrDefault(x => x.Email.Equals(User.Identity.Name)).FactoryId = (int) model.SelectedFactoryId;
        Log.Information($"{User.Identity.Name} choosed factory with id {model.SelectedFactoryId}");
        return RedirectToAction("ClientProfile", "Client");
    }
}

