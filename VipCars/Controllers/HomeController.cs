using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VipCars.Domain.Entities;
using VipCars.Domain.Repositories;
using VipCars.Models;

namespace VipCars.Controllers;

public class HomeController : Controller
{
    private readonly IGenericRepository<Car> _carRepository; 

    public HomeController(IGenericRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<IActionResult> Index()
    {
        var cars = await _carRepository.GetAllAsync();
        return View(cars);
        
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult AboutUs()
    {
        return View();
    }
    
    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task<IActionResult> DisplayCars()
    {
        var cars = await _carRepository.GetAllAsync();
        return PartialView("_CarList", cars);
    }
}