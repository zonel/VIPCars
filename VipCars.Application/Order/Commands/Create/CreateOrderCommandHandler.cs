using MediatR;
using VipCars.Application.Order.Mapping;
using VipCars.Domain.Entities;
using VipCars.Domain.Repositories;

namespace VipCars.Application.Order.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IGenericRepository<Domain.Entities.Order> _orderRepository;
    private readonly IGenericRepository<Car> _carRepository;

    public CreateOrderCommandHandler(IGenericRepository<Domain.Entities.Order> orderRepository,IGenericRepository<Car> carRepository)
    {
        _orderRepository = orderRepository;
        _carRepository = carRepository;
    }
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = OrderMappings.MapToOrder(request.order);
        
        var selectedCar = await _carRepository.GetByIdAsync(order.CarId);
        order.TotalPrice = order.CalculateTotalPrice(order, selectedCar.PricePerDay);
        
        if(order.RentalEndDate < order.RentalStartDate)
        {
            throw new Exception("The end date of the rental period cannot be earlier than the start date.");
        }
        
        var OrderId = await _orderRepository.AddAsync(order);
        return OrderId;
    }
}