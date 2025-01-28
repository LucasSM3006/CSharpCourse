
DealerShip dealerShip = new DealerShip();

Car newCar = new Car();
Boat newBoat = new Boat();
Plane newPlane = new Plane();

dealerShip.AddVehicle(newCar);
dealerShip.AddVehicle(newBoat);
dealerShip.AddVehicle(newPlane);

Vehicle vehicle1 = new Plane();

Console.WriteLine(vehicle1.Brand);

//Console.WriteLine(dealerShip.Display());

//Console.WriteLine(newCar.PublicMethod());

//Console.WriteLine(newBoat.PublicMethod());

Vehicle newSuv = new Suv();

Console.WriteLine($"Suv brand: {newSuv.Brand}");

Console.WriteLine("With overriding ToString: " + new Plane());
Console.WriteLine("Without overriding ToString: " + new Vehicle());

Console.WriteLine(newBoat.Brand);

List<Vehicle> list = new List<Vehicle>
{
    new Boat(),
    new Plane(),
    new Car()
};

foreach (Vehicle item in list)
{
    Console.WriteLine(item.Brand);
}

Console.ReadKey();

public class DealerShip
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle) => vehicles.Add(vehicle);

    public string Display() => $"This dealership has {string.Join(", ", vehicles)}";
}

public class Vehicle
{
    public string EngineType;

    public virtual string Brand { get; } = "Random brand";

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

    public override string Brand => "General Electric";

    public void UseFromBaseClass()
    {
        Console.WriteLine(PublicMethod());
        Console.WriteLine(ProtectedMethod());
    }

    public override string ToString() => Brand;
}

public class Car : Vehicle
{
    double _wheelBase;

    public override string Brand => "Ford";
}

public class Suv : Car
{
    public override string Brand => "Honda";
}

public class Boat : Vehicle
{
    double _propellerSize;

    public string Brand => "Boat Brand";
}