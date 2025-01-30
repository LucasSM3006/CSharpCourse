// Vehicle vehicle = new Vehicle(100); // Can't instantiate abstract methods. Obv.

Vehicle v = GenerateRandomVehicle();

if (v is Car)
{
    Car newCar = (Car)v;
    Console.WriteLine($"New car object! {newCar}");
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

// Reminder about abstract classes: All methods are implicitly virtual. They must be overriden in non-abstract classes.
public abstract class Vehicle
{
    public string EngineType;

    public virtual string Brand { get; } = "Random brand";
    public virtual string Name { get; } = "Random name";

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

    public abstract void Build();

    // NOTE: Virtual modifiers and abstract modifiers are not the same. Virtual modifiers can be used on non-abstract classes and also have implementations, abstract methods cannot.
    // While at it, Virtual methods are optional when it comes to overriding them, while in abstract methods, you absolutely must override them.

    public override string ToString() => Brand;
}

// all vehicle subclasses could technically be abstract classes themselves if we want to even further divide vehicles instead of setting properties.
// SUV could be a class, jet could be a class, jetski... Vehicle -> Land/Air/Aquatic -> Specific Types... For simplificity I will keep it as is.
// Note: Abstract methods need not override the parent's class methods as well.

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