
var dealerShip = new DealerShip();

var newCar = new Car();
var newBoat = new Boat();
var newPlane = new Plane();

dealerShip.AddVehicle(newCar);
dealerShip.AddVehicle(newBoat);
dealerShip.AddVehicle(newPlane);

Console.WriteLine(dealerShip.Display());

Console.WriteLine(newCar.PublicMethod());

Console.WriteLine(newBoat.PublicMethod());

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

    // Public methods are inherited.
    public string PublicMethod() => "Public method";

    // Private methods aren't inherited.
    private string PrivateMethod() => "Private method";

    // Protected methods are inherited.
    protected string ProtectedMethod() => "Protected method";
}

public class Plane : Vehicle 
{
    double _wingSize;

    public void UseFromBaseClass()
    {
        Console.WriteLine(PublicMethod());
        Console.WriteLine(ProtectedMethod());
    }
}

public class Car : Vehicle
{
    double _wheelBase;
}

public class Boat : Vehicle
{
    double _propellerSize;
}