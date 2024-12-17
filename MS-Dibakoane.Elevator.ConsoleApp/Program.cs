using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MS_Dibakoane.Elevator.Application;
using MS_Dibakoane.Elevator.ConsoleApp;
using MS_Dibakoane.Elevator.Infrastructure;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

using IHost host = CreateHostBuilder(args)
    .UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console())
    .Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Elevator application started");

using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

try
{
    serviceProvider.GetRequiredService<EntryPoint>()
        .Run(args);
}
catch (Exception ex)
{
    logger.LogError(ex, ex.Message);
    Console.WriteLine(ex.Message);
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
    {
        services.AddInfrastructureServices();
        services.AddApplicationService();
        services.AddSingleton<EntryPoint>();
    });
}