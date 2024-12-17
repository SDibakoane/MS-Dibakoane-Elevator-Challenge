namespace MS_Dibakoane.Elevator.Domain.Entities;

public class Building
{
    public int TotalFloors { get; private set; }
    public List<Elevator> Elevators { get; private set; }
    
    public Building(int totalFloors, int elevatorCount, int elevatorCapacity)
    {
        TotalFloors = totalFloors;
        Elevators = new List<Elevator>();
        for (int i = 0; i < elevatorCount; i++)
        {
            Elevators.Add(new Elevator(i + 1, elevatorCapacity));
        }
    }
    
    public void DisplayStatus()
    {
        Console.WriteLine("Building Status:");
        foreach (var elevator in Elevators)
        {
            Console.WriteLine(elevator);
        }
    }
}