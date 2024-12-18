using Microsoft.Extensions.DependencyInjection;
using MS_Dibakoane.Elevator.Domain.Entities;

namespace MS_Dibakoane.Elevator.Application;
/// <summary>
/// This class is an extension of the IService collection used to register services in the Application library
/// </summary>
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        // Register Dispatcher
        services.AddSingleton<Dispatcher>();
        //Register Mediatr
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        // Register Building and other dependencies
        services.AddSingleton(new Building(10, 3, 5));
        return services;
    }
}