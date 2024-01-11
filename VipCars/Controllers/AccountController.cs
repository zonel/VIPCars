using System.Security.Authentication;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using VipCars.Application.User.Commands.Authenticate;
using VipCars.Domain.Commands;
using VipCars.Domain.Entities;
using VipCars.Domain.Repositories;

namespace VipCars.Controllers;

public class AccountController : Controller
{
    private readonly IMediator _mediator;
    private readonly IGenericRepository<User> _userRepository;

    public AccountController(IMediator mediator, IGenericRepository<User> userRepository)
    {
        _mediator = mediator;
        _userRepository = userRepository;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        var errorMessage = TempData["ErrorMessage"] as string;
        if (!string.IsNullOrEmpty(errorMessage))
        {
            ViewBag.ErrorMessage = errorMessage;
        }
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home"); 
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand model)
    {
        try
        {

            if (ModelState.IsValid && await _mediator.Send(new AuthenticateUserCommand(model)))
            {
                var loggedUser = await _userRepository.FindAsync(x => x.Email == model.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loggedUser.FirstName + " " + loggedUser.LastName),
                    new Claim(ClaimTypes.Role, loggedUser.UserRoleId.ToString()),
                    new Claim(ClaimTypes.Sid, loggedUser.Id.ToString()),
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

            throw new InvalidCredentialException("Email or password is incorrect.");
        }
        catch(Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message; 

            return RedirectToAction("Login");
        }
    }
}