using Serilog;

namespace VipCars.Configuration;

public static class ServiceCollection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSerilog();
        });
        
        return services;
    }
}