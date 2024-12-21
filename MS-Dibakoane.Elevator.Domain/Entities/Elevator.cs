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
    public bool IsAssigned { get; set; }

    public Elevator(int id, int maxCapacity)
    {
        Id = id;
        CurrentFloor = 0; // Assuming ground floor as starting point
        Direction = Direction.Idle;
        MaxCapacity = maxCapacity;
        PassengerCount = 0;
        Requests = new Queue<int>();
    }
    
    public void AddRequest(int floor)
    {
        if (!Requests.Contains(floor))
        {
            IsAssigned = true;
            Requests.Enqueue(floor);
        }
    }
    
    public void LoadPassengers(int count)
    {
        if (PassengerCount + count > MaxCapacity)
        {
            throw new InvalidOperationException("Elevator capacity exceeded.");
        }
        PassengerCount += count;
    }
    
    public void UnloadPassengers(int count)
    {
        PassengerCount = Math.Max(0, PassengerCount - count);
    }
    
    public void Move()
    {
        if (Requests.Count == 0)
        {
            Direction = Direction.Idle;
            return;
        }

        int nextFloor = Requests.Peek();
        while (nextFloor != CurrentFloor)
        {
            if (nextFloor > CurrentFloor)
            {
                Direction = Direction.Up;
                CurrentFloor++;

                Thread.Sleep(3000);
            }
            else if (nextFloor < CurrentFloor)
            {
                Direction = Direction.Down;
                CurrentFloor--;
                Thread.Sleep(3000);
            }

            Console.Write(string.Join(Environment.NewLine, ToString()));
            Console.Write(Environment.NewLine);
        }

        if (CurrentFloor == nextFloor)
        {
            Requests.Dequeue(); // Reached destination
            Console.Write("Elevator has arrived on floor: {currentFloor}.", CurrentFloor);
        }
        
    }

    public int FloorPassengersCout(int floor) => Requests.Count(c => c.Equals(floor));
    
    public override string ToString()
    {
        return $"Elevator {Id}: Floor {CurrentFloor}, Direction {Direction}, Passengers {PassengerCount}/{MaxCapacity}";
    }
}