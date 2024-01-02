using System.ComponentModel.DataAnnotations;

namespace VipCars.Domain.Entities;

public class Address
{
    public string Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string PostalCode { get; set; }
    
    public ICollection<User>? Customers { get; set; }
}