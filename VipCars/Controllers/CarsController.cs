using Microsoft.AspNetCore.Mvc;
using VipCars.Domain.Entities;
using VipCars.Domain.Repositories;

namespace VipCars.Controllers;

public class CarsController : Controller
{
    private readonly IGenericRepository<Car> _carRepository; 

    public CarsController(IGenericRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IActionResult> Index()
    {
        var cars = await _carRepository.GetAllAsync(); 
        return View(cars); 
    }
}