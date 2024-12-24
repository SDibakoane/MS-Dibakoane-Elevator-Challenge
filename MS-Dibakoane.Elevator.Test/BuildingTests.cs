namespace MS_Dibakoane.Elevator.Test;

public class BuildingTests
{
    [Fact]
    public void Building_ShouldInitializeWithCorrectElevatorCount()
    {
        //Arrange
        int totFloors = 10;
        int elevatorCount = 2;
        int elevatorCapacity = 10;

        //Act
        var building = new Domain.Entities.Building(totFloors, elevatorCount, elevatorCapacity);

        //Assert
        Assert.Equal(elevatorCount, building.Elevators.Count);
        Assert.All(building.Elevators, e => Assert.Equal(elevatorCapacity, e.MaxCapacity));
    }
}