using FluentValidation;

namespace MS_Dibakoane.Elevator.Application.Features.Elevator.RequestElevator;
/// <summary>
/// This class validates the elevator request to ensure that the current floor is not the destination floor.
/// </summary>
public class ElevatorRequestCommandValidator : AbstractValidator<ElevatorRequest>
{
    public ElevatorRequestCommandValidator()
    {
        RuleFor(e => e.DestinationFloor)
            .GreaterThanOrEqualTo(0).WithMessage("Destination floor cannot be less 0.");
        RuleFor(e => e)
            .Must(UserCurrentFloorCheck).WithMessage(e => $"You are currently at {e.CurrentFloor}, a request can only be to another floor.");
    }

    private bool UserCurrentFloorCheck(ElevatorRequest arg)
    {
        if (arg.CurrentFloor != arg.DestinationFloor)
        {
            return true;
        }
        return false;
    }
}