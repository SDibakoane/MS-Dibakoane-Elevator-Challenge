using Microsoft.Extensions.DependencyInjection;
using MS_Dibakoane.Elevator.Application.Contracts;
using MS_Dibakoane.Elevator.Domain.Entities;
using MS_Dibakoane.Elevator.Infrastructure.Services;

namespace MS_Dibakoane.Elevator.Infrastructure;
/// <summary>
/// This AddInfrastructureServices class is an extension of the IServiceCollection to register services
/// in the infrastructure class library
/// </summary>
public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<ISimulationManager, SimulationManager>();
        return services;
    }
}