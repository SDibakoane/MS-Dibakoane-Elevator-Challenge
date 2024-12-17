namespace MS_Dibakoane.Elevator.Domain.Entities;

public class Building
{
    public int TotalFloors { get; private set; }
    public List<Elevator> Elevators { get; private set; }
}