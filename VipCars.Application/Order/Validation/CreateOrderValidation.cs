using VipCars.Domain.Repositories;
using VipCars.Domain.Validation;

namespace VipCars.Application.Order.Validation;

public class CreateOrderValidation : ICreateOrderValidation
{
    private readonly IGenericRepository<Domain.Entities.Order> _orderRepository;

    public CreateOrderValidation(IGenericRepository<Domain.Entities.Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public bool IsDateRangeValid(DateTimeOffset startDate, DateTimeOffset endDate)
    {
        return startDate < endDate;
    }
    
    public bool IsDateRangeAlreadyTaken(DateTimeOffset startDate, DateTimeOffset endDate, int carId)
    {
        var orders = _orderRepository.GetAllAsync().Result;
        var ordersForSelectedCar = orders.Where(o => o.CarId == carId);
        var ordersForSelectedCarWithDateRange = ordersForSelectedCar.Where(o => o.RentalStartDate <= startDate && o.RentalEndDate >= endDate);
        return ordersForSelectedCarWithDateRange.Any();
    }

}