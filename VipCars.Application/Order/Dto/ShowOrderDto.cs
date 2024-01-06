namespace VipCars.Application.Order.Dto;

public class ShowOrderDto
{
    public int Id { get; set; }
    public int CarId { get; set;}
    public int CustomerId { get; set;}
    public DateTimeOffset RentalStartDate { get; set;}
    public DateTimeOffset RentalEndDate { get; set;}
    public decimal TotalPrice { get; set;}
}