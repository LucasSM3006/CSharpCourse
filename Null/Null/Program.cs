DealerShip dealerShip = new DealerShip();

// Vehicle vehicle = null; // This works.
// var vehicle = null; // This does not compile.

// To assign null, you need to specify the type.

Console.WriteLine(dealerShip.networth);
Console.WriteLine(dealerShip.dateOfCreation);
Console.WriteLine(dealerShip.ownersVehicle); // This is null, thus, it prints nothing.

// Null exception example:
// Vehicle nullVehicle = null;
// Console.WriteLine(nullVehicle.EngineType);

// Handling that:

// Vehicle nullVehicle = null;
// if(nullVehicle != null) Console.WriteLine("Yep, not null!");
// if(nullVehicle is not null) Console.WriteLine("Yep, not null!"); // Note for future: 'is not null' cannot be overloaded, while '!=' can.
// if (nullVehicle is null) Console.WriteLine("Nope, it's null!");

Console.ReadKey();

public class DealerShip
{
    public double networth;
    public DateTime dateOfCreation;
    public Vehicle ownersVehicle;
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