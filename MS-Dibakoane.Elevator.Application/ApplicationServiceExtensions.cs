using Microsoft.Extensions.DependencyInjection;
using MS_Dibakoane.Elevator.Application.Behaviours;

namespace MS_Dibakoane.Elevator.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddOpenBehavior(typeof(ExceptionHandlingBehaviour<,>));
        });
        return services;
    }
}