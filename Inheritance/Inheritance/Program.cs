
var dealerShip = new DealerShip();

var newCar = new Car();
var newBoat = new Boat();
var newPlane = new Plane();

dealerShip.AddVehicle(newCar);
dealerShip.AddVehicle(newBoat);
dealerShip.AddVehicle(newPlane);

Console.WriteLine(dealerShip.Display());

Console.ReadKey();

public class DealerShip
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle) => vehicles.Add(vehicle);

    public string Display() => $"This dealership has {string.Join(", ", vehicles)}";
}

public class Vehicle
{
    string _engineType;
}

public class Plane : Vehicle 
{
    double _wingSize;
}

public class Car : Vehicle
{
    double _wheelBase;
}

public class Boat : Vehicle
{
    double _propellerSize;
}