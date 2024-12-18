using MediatR;

namespace MS_Dibakoane.Elevator.Application.Features.Elevator.RequestElevator;
/// <summary>
/// This record is the command used to request an elevator
/// </summary>
/// <param name="CurrentFloor"></param>
/// <param name="DestinationFloor"></param>
public record ElevatorRequest(int CurrentFloor, int DestinationFloor)
    : IRequest;