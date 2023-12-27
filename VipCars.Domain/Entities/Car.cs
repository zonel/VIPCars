namespace VipCars.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateOnly YearOfProduction { get; set; }
    public string Color { get; set; }
    public string Vin { get; set; }
    public string RegistrationNumber { get; set; }
    public decimal PricePerDay { get; set; }
}