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
}