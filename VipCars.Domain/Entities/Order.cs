namespace VipCars.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateOnly RentalStartDate { get; set; }
    public DateOnly RentalEndDate { get; set; }
    public decimal TotalPrice { get; set; }
}