using MediatR;
using VipCars.Application.Order.Mapping;
using VipCars.Domain.Entities;
using VipCars.Domain.Repositories;
using VipCars.Domain.Validation;

namespace VipCars.Application.Order.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IGenericRepository<Domain.Entities.Order> _orderRepository;
    private readonly IGenericRepository<Car> _carRepository;
    private readonly ICreateOrderValidation _createOrderValidation;

    public CreateOrderCommandHandler(IGenericRepository<Domain.Entities.Order> orderRepository,
        IGenericRepository<Car> carRepository, 
        ICreateOrderValidation createOrderValidation)
    {
        _orderRepository = orderRepository;
        _carRepository = carRepository;
        _createOrderValidation = createOrderValidation;
    }
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = OrderMappings.MapToOrder(request.order);
        
        var selectedCar = await _carRepository.GetByIdAsync(order.CarId);
        order.TotalPrice = order.CalculateTotalPrice(order, selectedCar.PricePerDay);
        
        if(!_createOrderValidation.IsDateRangeValid(order.RentalStartDate, order.RentalEndDate))
        {
            throw new Exception("Order date range is not valid.");
        }
        
        var isOrderDateTaken = _createOrderValidation.IsDateRangeAlreadyTaken(order.RentalStartDate, order.RentalEndDate, order.CarId);
        if (isOrderDateTaken)
        {
            throw new Exception("Order date range is taken.");
        }
        
        var OrderId = await _orderRepository.AddAsync(order);
        return OrderId;
    }
    

}