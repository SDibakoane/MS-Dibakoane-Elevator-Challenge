using Microsoft.Extensions.DependencyInjection;

namespace MS_Dibakoane.Elevator.Infrastructure;
/// <summary>
/// This AddInfrastructureServices class is an extension of the IServiceCollection to register services
/// in the infrastructure class library
/// </summary>
public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }
}