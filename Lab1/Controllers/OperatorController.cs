using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers;

public class OperatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}