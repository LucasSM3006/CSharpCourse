Vehicle vehicle = new Car(100);

Vehicle v = GenerateRandomVehicle();
// Car car = (Car) v; // Throws an exception if the cast fails.
Car car = v as Car; // This, on the other hand, gives us a Null if the cast fails. ONLY WORKS TO CAST TO NULLABLE TYPES. EXAMPLE BELOW:
// int number = v as int; // int is non nullable!

if (car is not null)
{
    Console.WriteLine(car.Brand);
}
else
{
    Console.WriteLine("Conversion failed.");
}

Console.ReadKey();

Vehicle GenerateRandomVehicle()
{
    var random = new Random();
    var number = random.Next(1, 4);
    if (number == 1) return new Car(200);
    if (number == 2) return new Plane(5000);
    else return new Boat(3000);
}

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

    //public Vehicle()
    //{
    //    Console.WriteLine("Constructor of Vehicle class");
    //}

    public Vehicle(double priceForDifferentColors)
    {
        PriceForDifferentColors = priceForDifferentColors;
    }

    public double PriceForDifferentColors { get; }

    // Public methods are inherited.
    public string PublicMethod() => "Public method";

    // Private methods aren't inherited.
    private string PrivateMethod() => "Private method";

    // Protected methods are inherited.
    protected string ProtectedMethod() => "Protected method";

    public override string ToString() => Brand;
}

public class Plane : Vehicle
{
    double _wingSize;

    public override string Brand => "General Electric";

    public Plane(double priceForDifferentColors) : base(priceForDifferentColors)
    {

    }

    public void UseFromBaseClass()
    {
        Console.WriteLine(PublicMethod());
        Console.WriteLine(ProtectedMethod());
    }
}

public class Car2 : Vehicle
{
    public double Height { get; }

    public Car2(double priceForDifferentColors, double height) : base(priceForDifferentColors)
    {
        Height = height;
        Console.WriteLine("Constructor of Car2 Class");
    }
}

public class Car : Vehicle
{
    double _wheelBase;

    public Car(double priceForDifferentColors) : base(priceForDifferentColors)
    {

    }

    public override string Brand => "Ford";
}

public class Suv : Car
{
    public Suv(double priceForDifferentColors) : base(priceForDifferentColors)
    {

    }
    public override string Brand => "Honda";
}

public class Boat : Vehicle
{
    double _propellerSize;

    public Boat(double priceForDifferentColors) : base(priceForDifferentColors)
    {

    }

    public string Brand => "Boat Brand";
}