using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VipCars.Application.Order.Validation;
using VipCars.Domain.Repositories;
using VipCars.Domain.Validation;

namespace VipCars.Application.Configuration;

public static class ServiceCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddSingleton<IPasswordHasher<Domain.Entities.User>, PasswordHasher<Domain.Entities.User>>();
        services.AddScoped<ICreateOrderValidation, CreateOrderValidation>();

        return services;
    }
}