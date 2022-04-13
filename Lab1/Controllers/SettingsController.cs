using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers;

public class SettingsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}