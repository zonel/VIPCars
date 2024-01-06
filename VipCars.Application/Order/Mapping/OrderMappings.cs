using VipCars.Application.Order.Dto;

namespace VipCars.Application.Order.Mapping;

public static class OrderMappings
{
    public static Domain.Entities.Order MapToOrder(CreateOrderDto createOrderDto)
    {
        return new Domain.Entities.Order
        {
            CarId = createOrderDto.CarId,
            CustomerId = createOrderDto.CustomerId,
            RentalStartDate = createOrderDto.RentalStartDate,
            RentalEndDate = createOrderDto.RentalEndDate,
        };
    }
    
    public static ShowOrderDto MapToShowOrderDto(Domain.Entities.Order order)
    {
        return new ShowOrderDto
        {
            Id = order.Id,
            CarId = order.CarId,
            CustomerId = order.CustomerId,
            RentalStartDate = order.RentalStartDate,
            RentalEndDate = order.RentalEndDate,
            TotalPrice = order.TotalPrice
        };
    }
}