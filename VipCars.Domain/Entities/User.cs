namespace VipCars.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Pesel { get; set; }
    
    public int AddressId { get; set; }
    public Address? Address { get; set; }
    
    public ICollection<Order>? Orders { get; set; }
    
    public int UserRoleId { get; set; } = 2;
    public Role? UserRole { get; set; }
}