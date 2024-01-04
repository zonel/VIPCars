using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VipCars.Domain.Repositories;

namespace VipCars.Application.Configuration;

public static class ServiceCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddSingleton<IPasswordHasher<Domain.Entities.User>, PasswordHasher<Domain.Entities.User>>();

        return services;
    }
}