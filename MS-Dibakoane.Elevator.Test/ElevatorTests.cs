namespace MS_Dibakoane.Elevator.Test;
/// <summary>
/// This class contains the tests for the Elevator class.
/// </summary>
public class ElevatorTests
{
    [Fact]
    public void AddRequest_ShouldAddFloorToQueue()
    {
        //Arrange
        var elevator = new Domain.Entities.Elevator(1, 10);

        //Act
        elevator.AddRequest(5);

        //Assert
        Assert.Equal(1, elevator.Requests.Count);
        Assert.Equal(5, elevator.Requests.Peek());
    }

    [Fact]
    public void AddRequest_ShouldNotAddDuplicateFloorToQueue()
    {
        //Arrange
        var elevator = new Domain.Entities.Elevator(1, 10);

        //Act
        elevator.AddRequest(5);
        elevator.AddRequest(5);

        //Assert
        Assert.Equal(1, elevator.Requests.Count);
    }

    [Fact]
    public void LoadPassengers_ShouldIncreasePassengerCount()
    {
        //Arrange
        var elevator = new Domain.Entities.Elevator(1, 10);

        //Act
        elevator.LoadPassengers(5);

        //Assert
        Assert.Equal(5, elevator.PassengerCount);
    }

    [Fact]
    public void LoadPassengers_ShouldThrowExceptionIfCapacityExceeded()
    {
        //Arrange
        var elevator = new Domain.Entities.Elevator(1, 10);

        //Act
        elevator.LoadPassengers(10);

        //Assert
        Assert.Throws<InvalidOperationException>(() => elevator.LoadPassengers(1));
    }
}