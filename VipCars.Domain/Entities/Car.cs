namespace VipCars.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateOnly YearOfProduction { get; set; }
    public string Color { get; set; }
    public string Transmission { get; set; }
    public string Engine { get; set; }
    public string Fuel { get; set; }
    public string Drive { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int NumberOfSeats { get; set; }
    public int NumberOfDoors { get; set; }
    public decimal PricePerDay { get; set; }
    
    public ICollection<Order>? Orders { get; set; }
}