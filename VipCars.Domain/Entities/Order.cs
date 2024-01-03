namespace VipCars.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTimeOffset RentalStartDate { get; set; }
    public DateTimeOffset RentalEndDate { get; set; }
    public decimal TotalPrice { get; set; }
    
    public Car Car { get; set; }
    public User Customer { get; set; } 
}