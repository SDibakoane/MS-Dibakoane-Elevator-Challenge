using MediatR;
using MS_Dibakoane.Elevator.Application.Contracts;
using MS_Dibakoane.Elevator.Application.Features.Elevator.RequestElevator;
using MS_Dibakoane.Elevator.Domain.Entities;

namespace MS_Dibakoane.Elevator.Infrastructure.Services;
/// <summary>
/// This class serves as the entry point of the application which handles the user interactions and input
/// </summary>
/// <param name="building"></param>
/// <param name="dispatcher"></param>
/// <param name="sender"></param>
public class SimulationManager(Building building, Dispatcher dispatcher, ISender sender) 
    : ISimulationManager
{
    public async Task Run(string[] args)
    {
        while (true)
        {
            building.DisplayStatus();
            Console.WriteLine("Options: [1] Call Elevator [2] Exit");
            Console.Write("Enter choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter Floor to call Elevator: ");
                    if (int.TryParse(Console.ReadLine(), out int currentFloor))
                    {
                        Console.WriteLine("Enter destination Floor: ");
                        if (int.TryParse(Console.ReadLine(), out int floor))
                        {
                            await sender.Send(new ElevatorRequest(currentFloor, floor));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }
            Thread.Sleep(1000); // Simulate updates
        }
    }
}