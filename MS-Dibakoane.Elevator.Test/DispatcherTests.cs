using MS_Dibakoane.Elevator.Domain.Entities;

namespace MS_Dibakoane.Elevator.Test;

public class DispatcherTests
{
    [Fact]
    public void AssignElevator_ShouldAssignNearestAvailableElevator()
    {
        // Arrange
        var building = new Building(10, 2, 5);
        var dispatcher = new Dispatcher(building);
        var elevator1 = building.Elevators[0];
        var elevator2 = building.Elevators[1];

        elevator1.AddRequest(2); // Busy
        elevator2.AddRequest(8); // Busy
        elevator1.Move(); // At floor 1
        elevator2.Move(); // At floor 1

        // Act
        dispatcher.AssignElevator(4);

        // Assert
        Assert.Contains(4, elevator1.Requests); // Closest elevator is elevator1
    }

    [Fact]
    public void AssignElevator_ShouldHandleInvalidFloor()
    {
        //Arrange
        var building = new Building(10, 2, 5);
        var dispatcher = new Dispatcher(building);

        //Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => dispatcher.AssignElevator(11));
    }
}