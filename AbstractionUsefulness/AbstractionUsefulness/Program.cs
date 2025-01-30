// Vehicle vehicle = new Vehicle(100); // Can't instantiate abstract methods. Obv.

Car car = new Car(1000);
Plane plane = new Plane(2000);

plane.Build();
car.Build();     // These two methods would work fine even without having "Build" in the abstract class, but something like...

List<Vehicle> vehicles = new List<Vehicle>
{
    new Car(2333),
    new Plane(3321),
    new Boat(2222)
};

// The moment we remove the 'Build()' method from the abstract class, this code will stop working altogether.

foreach (var vehicle in vehicles)
{
    vehicle.Build();
}

public class DealerShip
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle) => vehicles.Add(vehicle);

    public string Display() => $"This dealership has {string.Join(", ", vehicles)}";
}

// Reminder about abstract classes: All methods are implicitly virtual. They must be overriden in non-abstract classes.
public abstract class Vehicle
{
    public string EngineType;

    public virtual string Brand { get; } = "Random brand";
    public virtual string Name { get; } = "Random name";

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

    public abstract void Build();

    public override string ToString() => Brand;
}
public class Plane : Vehicle
{
    double _wingSize;

    public override string Brand => "General Electric";

    public Plane(double priceForDifferentColors) : base(priceForDifferentColors)
    {

    }

    public override void Build()
    {

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

    public override void Build()
    {

    }
}

public class Car : Vehicle
{
    double _wheelBase;

    public Car(double priceForDifferentColors) : base(priceForDifferentColors)
    {

    }

    public override string Brand => "Ford";

    public override void Build()
    {

    }
}

public class Suv : Car
{
    public Suv(double priceForDifferentColors) : base(priceForDifferentColors)
    {

    }
    public override string Brand => "Honda";

    public override void Build()
    {

    }
}

public class Boat : Vehicle
{
    double _propellerSize;

    public Boat(double priceForDifferentColors) : base(priceForDifferentColors)
    {

    }

    public string Brand => "Boat Brand";

    public override void Build()
    {

    }
}