using System.Net;
using System.Security.Claims;
using Lab1.Data;
using Lab1.Entities;
using Lab1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab1.Models;
using Microsoft.VisualBasic;
using Serilog;
using Serilog.Core;
using static Serilog.RollingInterval;

namespace Lab1.Controllers;

public class AccountController : Controller
{
    private ApplicationDbContext _context;
    
    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Profile()
    {
        Log.Information("Profile page clicked");
        var roleId =  _context.Users.FirstOrDefault(x => x.Email.Equals(User.Identity.Name)).RoleId;
        switch (roleId)
        {
            case 3:
                Log.Information($"ClientProfile {User.Identity.Name} page redirected");
                return RedirectToAction("ClientProfile", "Client");
            case 6:
                Log.Information($"OperatorProfile {User.Identity.Name} page redirected");
                return RedirectToAction("OperatorProfile", "Operator");
            case 5:
                Log.Information($"ManagerProfile {User.Identity.Name} page redirected");
                return RedirectToAction("ManagerProfile", "Manager");
            case 1:
                Log.Information($"AdminProfile {User.Identity.Name} page redirected");
                return RedirectToAction("AdminProfile", "Admin");
        }
        return View(new RoleModel() {Roles = _context.Roles.ToList()});
    }

    [HttpGet]
    public IActionResult Register()
    {
        Log.Information($"Register page redirected");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Profile(RoleModel model)
    {
        User user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name));

        if (!(model.SelectedRoleId == null))
        {
            user.RoleId = model.SelectedRoleId;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Profile", "Account");
    }

    public async Task<IActionResult> Logout()
    {
        Log.Information($"{User.Identity.Name} logged out");
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                if (model.PhoneNumber.Length < 6)
                {
                    return RedirectToAction("Register", "Account");
 
                }
                user = new User
                {
                    Email = model.Email, 
                    Password = model.Password, 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SecondName = model.SecondName,
                    PhoneNumber = model.PhoneNumber,
                    IdentificationNumber = model.IdentificationNumber,
                    SeriesAndPassportNumber = model.SeriesAndPassportNumber
                };
                Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                if (userRole != null)
                    user.Role = userRole;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                await Authenticate(user);
                Log.Information($"{User.Identity.Name} signed up");
                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            User user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                await Authenticate(user);
                Log.Information($"{User.Identity.Name} logged in");
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }

        return View(model);
    }

    private async Task Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
        };
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
}