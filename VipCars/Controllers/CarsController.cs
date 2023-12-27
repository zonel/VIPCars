using Microsoft.AspNetCore.Mvc;

namespace VipCars.Controllers;

public class CarsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}