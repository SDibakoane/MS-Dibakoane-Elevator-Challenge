using MS_Dibakoane.Elevator.Domain.Common;

namespace MS_Dibakoane.Elevator.Domain.Entities;
/// <summary>
/// This Elevator entity is the main entity in the system
/// </summary>
public class Elevator
{
    public int Id { get; private set; }
    public int CurrentFloor { get; private set; }
    public Direction Direction { get; private set; }
    public int MaxCapacity { get; private set; }
    public int PassengerCount { get; private set; }
    private Queue<int> Requests { get; set; }
}