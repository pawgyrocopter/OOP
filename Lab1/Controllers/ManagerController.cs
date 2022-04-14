using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers;

public class ManagerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}