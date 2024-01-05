using MediatR;
using Microsoft.AspNetCore.Mvc;
using VipCars.Application.Order.Commands.Create;
using VipCars.Application.Order.Dto;
using VipCars.Domain.Entities;
using VipCars.Domain.Repositories;
using VipCars.Infrastructure.Repositories;

namespace VipCars.Controllers;

public class RentingController : Controller
{
    private readonly IGenericRepository<Car> _carRepository;
    private readonly IMediator _mediator;

    public RentingController(IGenericRepository<Car> carRepository, IMediator mediator)
    {
        _mediator = mediator;
        _carRepository = carRepository;
    }

    public async Task<IActionResult> Create(int carId)
    {
        Car car = await _carRepository.GetByIdAsync(carId);

        if (car == null)
        {
            return NotFound();
        }

        ViewBag.SelectedCar = car;

        return View();
    }
    
    // POST: Renting/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateOrderDto order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(new CreateOrderCommand(order));
        
        return RedirectToAction("RentConfirmation");
    }
    
    // GET: Renting/RentConfirmation
    public IActionResult RentConfirmation()
    {
        return View();
    }
}