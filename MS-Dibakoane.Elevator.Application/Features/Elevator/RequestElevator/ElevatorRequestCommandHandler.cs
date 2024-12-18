using MediatR;
using MS_Dibakoane.Elevator.Domain.Entities;

namespace MS_Dibakoane.Elevator.Application.Features.Elevator.RequestElevator;
/// <summary>
/// This class handles the business logic of a passenger requesting an elevator
/// </summary>
/// <param name="dispatcher"></param>
/// <param name="building"></param>
public class ElevatorRequestCommandHandler(Dispatcher dispatcher, Building building) 
    : IRequestHandler<ElevatorRequest>
{
    public async Task Handle(ElevatorRequest request, CancellationToken cancellationToken)
    {
        var validator = new ElevatorRequestCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            var message = 
                string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
            Console.WriteLine(message);
        }
        
        dispatcher.AssignElevator(request.DestinationFloor);
        foreach (var elevator in building.Elevators)
        {
            elevator.Move();
            //Console.WriteLine(elevator.ToString());
        }
    }
}