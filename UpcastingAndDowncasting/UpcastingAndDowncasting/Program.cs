
//DealerShip dealerShip = new DealerShip();

//Car newCar = new Car(222);
//Boat newBoat = new Boat(5000);
//Plane newPlane = new Plane(4213);

//dealerShip.AddVehicle(newCar);
//dealerShip.AddVehicle(newBoat);
//dealerShip.AddVehicle(newPlane);

//Vehicle vehicle1 = new Plane(4412);

//Console.WriteLine(vehicle1.Brand);

////Console.WriteLine(dealerShip.Display());

////Console.WriteLine(newCar.PublicMethod());

////Console.WriteLine(newBoat.PublicMethod());

//Vehicle newSuv = new Suv(222);

//Console.WriteLine($"Suv brand: {newSuv.Brand}");

//Console.WriteLine("With overriding ToString: " + new Plane(5000));
//Console.WriteLine("Without overriding ToString: " + new Vehicle(100));

//Console.WriteLine(newBoat.Brand);

//List<Vehicle> list = new List<Vehicle>
//{
//    new Boat(112),
//    new Plane(223),
//    new Car(4332)
//};

//foreach (Vehicle item in list)    
//{
//    Console.WriteLine(item.Brand);
//}

//Console.WriteLine(dealerShip.Display());

//Car2 car2 = new Car2(1000, 2.5);

Vehicle vehicle = new Car(100); // Upcasting. Car is a Vehicle, it makes sense.

// Car car = vehicle; // Downcasting. Not every vehicle is a car.

Vehicle v = GenerateRandomVehicle();

Console.WriteLine($"Is vehicle an object? {v is object}");
Console.WriteLine($"Is vehicle a car? {v is Car}");
Console.WriteLine($"Is vehicle a plane? {v is Plane}");
Console.WriteLine($"Is vehicle a boat? {v is Boat}");

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