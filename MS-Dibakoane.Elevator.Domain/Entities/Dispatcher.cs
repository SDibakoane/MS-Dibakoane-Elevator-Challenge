using MS_Dibakoane.Elevator.Domain.Common;

namespace MS_Dibakoane.Elevator.Domain.Entities;
/// <summary>
/// This Dispatcher class handles the assignment of users to an elevator
/// </summary>
/// <param name="building"></param>
public class Dispatcher(Building building)
{
    public void AssignElevator(int floor)
    {
        if (floor < 0 || floor > building.TotalFloors)
        {
            throw new ArgumentOutOfRangeException(nameof(floor), "Invalid floor number.");
        }

        // Find the nearest idle or available elevator
        Elevator nearestElevator = building.Elevators
            .Where(e => e.Direction == Direction.Idle ||
                        (e.Direction == Direction.Up && floor > e.CurrentFloor) ||
                        (e.Direction == Direction.Down && floor < e.CurrentFloor))
            .OrderBy(e => Math.Abs(e.CurrentFloor - floor))
            .FirstOrDefault();

        if (nearestElevator != null)
        {
            nearestElevator.AddRequest(floor);
            Console.WriteLine($"Request for floor {floor} assigned to Elevator {nearestElevator.Id}.");
        }
        else
        {
            Console.WriteLine($"No available elevator to handle request for floor {floor}.");
        }
    }
    
    
}