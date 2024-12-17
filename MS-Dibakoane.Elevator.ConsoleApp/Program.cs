using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS_Dibakoane.Elevator.Application;
using MS_Dibakoane.Elevator.ConsoleApp;
using MS_Dibakoane.Elevator.Infrastructure;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

try
{
    serviceProvider.GetRequiredService<EntryPoint>()
        .Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}
static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
    {
        services.AddSingleton<EntryPoint>();
        services.AddInfrastructureServices();
        services.AddApplicationService();
    });
}