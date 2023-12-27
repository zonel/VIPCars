using Microsoft.AspNetCore.Mvc;

namespace VipCars.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}