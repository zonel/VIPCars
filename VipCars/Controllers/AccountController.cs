using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using VipCars.Application.User.Commands.Authenticate;
using VipCars.Domain.Commands;

namespace VipCars.Controllers;

public class AccountController : Controller
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Logout()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand model)
    {
        if (ModelState.IsValid && await _mediator.Send(new AuthenticateUserCommand(model)))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                // Configure any authentication properties if needed
            };

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            
            return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return Ok();
    }
}