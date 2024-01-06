using MediatR;
using Microsoft.AspNetCore.Mvc;
using VipCars.Application.Order.Commands.Create;
using VipCars.Application.Order.Dto;
using VipCars.Application.Order.Mapping;
using VipCars.Domain.Entities;
using VipCars.Domain.Repositories;
using VipCars.Infrastructure.Repositories;

namespace VipCars.Controllers;

public class OrderController : Controller
{
    private readonly IGenericRepository<Car> _carRepository;
    private readonly IMediator _mediator;
    private readonly IGenericRepository<Order> _orderRepository;

    public OrderController(IGenericRepository<Car> carRepository, IMediator mediator, IGenericRepository<Order> orderRepository)
    {
        _mediator = mediator;
        _carRepository = carRepository;
        _orderRepository = orderRepository;
    }
    public async Task<IActionResult> Create(int carId)
    {
        Car car = await _carRepository.GetByIdAsync(carId);

        if (car == null)
        {
            return NotFound();
        }

        ViewBag.SelectedCar = car;

        var errorMessage = TempData["ErrorMessage"] as string;
        if (!string.IsNullOrEmpty(errorMessage))
        {
            ViewBag.ErrorMessage = errorMessage;
        }
        
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

        try
        {
            var id = await _mediator.Send(new CreateOrderCommand(order));
        }
        catch (Exception ex) //TODO: Refactor this to show exceptions without reloading the page
        {
            TempData["ErrorMessage"] = ex.Message; 

            return RedirectToAction("Create", new { carId = order.CarId });
        }
        
        return RedirectToAction("RentConfirmation");
    }
    // GET: Renting/RentConfirmation
    public IActionResult RentConfirmation()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> AdminPanel()
    {
        var orders = await _orderRepository.GetAllAsync();
        var showOrders = orders.Select(order => OrderMappings.MapToShowOrderDto(order)).ToList();
        return View(showOrders);
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
        {
            return NotFound(); // Or handle appropriately if order not found
        }
        var showOrder = OrderMappings.MapToShowOrderDto(order);
        return View(showOrder);
    }

    // Edit Order - GET
    public async Task<IActionResult> Edit(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
        {
            return NotFound(); // Or handle appropriately if order not found
        }
        var showOrder = OrderMappings.MapToShowOrderDto(order);
        return View(showOrder);
    }

    // Edit Order - POST
    [HttpPost]
    public async Task<IActionResult> Edit(ShowOrderDto showOrder)
    {
        if (!ModelState.IsValid)
        {
            return View(showOrder); 
        }

        var orderToUpdate = await _orderRepository.GetByIdAsync(showOrder.Id);
        if (orderToUpdate == null)
        {
            return NotFound();
        }
        
        orderToUpdate.CarId = showOrder.CarId;
        orderToUpdate.CustomerId = showOrder.CustomerId;
        orderToUpdate.RentalStartDate = showOrder.RentalStartDate;
        orderToUpdate.RentalEndDate = showOrder.RentalEndDate;
        orderToUpdate.TotalPrice = showOrder.TotalPrice;
        
        await _orderRepository.UpdateAsync(orderToUpdate);
        return RedirectToAction("AdminPanel");
    }

    // Delete Order - GET
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
        {
            return NotFound(); // Or handle appropriately if order not found
        }
        var showOrder = OrderMappings.MapToShowOrderDto(order);
        return View(showOrder);
    }

    // Delete Order - POST
    [HttpPost("{id}")]
    public async Task<IActionResult> DeleteConfirmed([FromRoute]int id)
    {
        var orderToRemove = await _orderRepository.GetByIdAsync(id);
        _orderRepository.Remove(orderToRemove);
        return RedirectToAction("AdminPanel");
    }
}