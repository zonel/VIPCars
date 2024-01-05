namespace VipCars.Application.Order.Dto;

public record CreateOrderDto(int CarId, int CustomerId, DateTimeOffset RentalStartDate, DateTimeOffset RentalEndDate);
