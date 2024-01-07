using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VipCars.Domain.Entities;

namespace VipCars.Infrastructure.Persistence;

public class SeedDatabase
{
    public async Task Seed(VipDbContext context, IPasswordHasher<User> passwordHasher)
    {
        if(await context.Users.AnyAsync())
            return;
        await context.Addresses.AddAsync(new Address
        {
            Country = "Poland",
            City = "Kraków",
            Street = "Grodzka",
            BuildingNumber = "5",
            PostalCode = "31-000"
        });
        
        await context.Roles.AddRangeAsync(
            new Role { Name = "Admin" },
            new Role { Name = "User" }
        );
        await context.SaveChangesAsync();

        var users = new List<User>
        {
            new User
            {
                FirstName = "Jacek",
                LastName = "Placek",
                Email = "user@email.com",
                Password = "AQAAAAIAAYagAAAAELhqwE0SFAN44L8598yWkF0WcNbNTkuP4OmuKIYclIQmPczubiI5SQiBTD2NBwrJqQ==",
                PhoneNumber = 100200300,
                Pesel = 12345678901,
                AddressId = 1,
                UserRoleId = 2
            },
            new User
            {
                FirstName = "Tom",
                LastName = "Riddle",
                Email = "admin@email.com",
                Password = "AQAAAAIAAYagAAAAELhqwE0SFAN44L8598yWkF0WcNbNTkuP4OmuKIYclIQmPczubiI5SQiBTD2NBwrJqQ==",
                PhoneNumber = 300200100,
                Pesel = 10987654321,
                AddressId = 1,
                UserRoleId = 1
            }
        };
        await context.Users.AddRangeAsync(users);
        var cars = new List<Car> 
        {
        new Car
        { 
            Brand = "BMW",
            Model = "M4 Competition",
        YearOfProduction = 2023,
        Color = "Green",
        Transmission = "Automatic",
        Engine = "3.0L Twin-Turbo Inline-6",
        Fuel = "Gasoline",
        Drive = "Rear-Wheel Drive",
        Url = "https://projectcarsgorlice.pl/wp-content/uploads/2023/08/BMW4.jpg.webp",
        Description = "Powerful and sleek sports car",
        Type = "Coupe",
        NumberOfSeats = 4,
        NumberOfDoors = 2,
        PricePerDay = 300
    },
    new Car
    {
        Brand = "Chevrolet",
        Model = "Camaro SS",
        YearOfProduction = 2022,
        Color = "Yellow",
        Transmission = "Automatic",
        Engine = "6.2L V8",
        Fuel = "Gasoline",
        Drive = "Rear-Wheel Drive",
        Url = "https://projectcarsgorlice.pl/wp-content/uploads/2023/03/CamaroNewFeat.jpg.webp",
        Description = "Classic American muscle car",
        Type = "Coupe",
        NumberOfSeats = 4,
        NumberOfDoors = 2,
        PricePerDay = 250
    },
    new Car
    {
        Brand = "Mercedes-Benz",
        Model = "CLA 45S AMG",
        YearOfProduction = 2023,
        Color = "White",
        Transmission = "Automatic",
        Engine = "2.0L Turbo Inline-4",
        Fuel = "Gasoline",
        Drive = "All-Wheel Drive",
        Url = "https://projectcarsgorlice.pl/wp-content/uploads/2023/03/mercedes_amg.jpg.webp",
        Description = "Luxurious and high-performance sedan",
        Type = "Sedan",
        NumberOfSeats = 5,
        NumberOfDoors = 4,
        PricePerDay = 350
    },
    new Car
    {
        Brand = "Audi",
        Model = "S5 Sportback",
        YearOfProduction = 2022,
        Color = "Black",
        Transmission = "Automatic",
        Engine = "3.0L Turbo V6",
        Fuel = "Gasoline",
        Drive = "All-Wheel Drive",
        Url = "https://projectcarsgorlice.pl/wp-content/uploads/2023/08/AUDI.jpg.webp",
        Description = "Sleek and refined sportback",
        Type = "Sedan",
        NumberOfSeats = 5,
        NumberOfDoors = 4,
        PricePerDay = 320
    },
    new Car
    {
        Brand = "BMW",
        Model = "M135i",
        YearOfProduction = 2023,
        Color = "Black",
        Transmission = "Automatic",
        Engine = "2.0L Turbo Inline-4",
        Fuel = "Gasoline",
        Drive = "All-Wheel Drive",
        Url = "https://projectcarsgorlice.pl/wp-content/uploads/2023/08/BMW1.jpg.webp",
        Description = "Compact and powerful hatchback",
        Type = "Hatchback",
        NumberOfSeats = 5,
        NumberOfDoors = 4,
        PricePerDay = 280
    },
    new Car
    {
        Brand = "Ford",
        Model = "Mustang GT",
        YearOfProduction = 2022,
        Color = "Yellow",
        Transmission = "Manual",
        Engine = "5.0L V8",
        Fuel = "Gasoline",
        Drive = "Rear-Wheel Drive",
        Url = "https://projectcarsgorlice.pl/wp-content/uploads/2023/08/MUSTANG.jpg.webp",
        Description = "Iconic American muscle car",
        Type = "Coupe",
        NumberOfSeats = 4,
        NumberOfDoors = 2,
        PricePerDay = 270
    },
    new Car
    {
        Brand = "Mercedes-Benz",
        Model = "Vito",
        YearOfProduction = 2022,
        Color = "White",
        Transmission = "Automatic",
        Engine = "2.2L Inline-4 Diesel",
        Fuel = "Diesel",
        Drive = "Front-Wheel Drive",
        Url = "https://projectcarsgorlice.pl/wp-content/uploads/2023/08/VITO.jpg.webp",
        Description = "Versatile and spacious van",
        Type = "Van",
        NumberOfSeats = 8,
        NumberOfDoors = 4,
        PricePerDay = 200
    }
};
        await context.Cars.AddRangeAsync(cars);
        await context.SaveChangesAsync();
        
        
        await context.Orders.AddAsync(new Order
        {
            CarId = 1,
            CustomerId = 1,
            RentalStartDate = DateTime.Now,
            RentalEndDate = DateTime.Now.AddDays(2),
            TotalPrice = 600,
        });
        await context.SaveChangesAsync();
    }
}