﻿
DealerShip dealerShip = new DealerShip();

Car newCar = new Car();
Boat newBoat = new Boat();
Plane newPlane = new Plane();

dealerShip.AddVehicle(newCar);
dealerShip.AddVehicle(newBoat);
dealerShip.AddVehicle(newPlane);

Vehicle vehicle = new Plane();

//Console.WriteLine(vehicle.Brand); // Does not work. Inheritance doesn't work upwards, only downwards. BaseClass -> SubClass -> SubSubClass

Console.WriteLine(dealerShip.Display());

Console.WriteLine(newCar.PublicMethod());

Console.WriteLine(newBoat.PublicMethod());

Console.WriteLine(newBoat.Brand);

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

    public string Brand => "General Electric";

    public void UseFromBaseClass()
    {
        Console.WriteLine(PublicMethod());
        Console.WriteLine(ProtectedMethod());
    }
}

public class Car : Vehicle
{
    double _wheelBase;

    public string Brand => "Ford";
}

public class Boat : Vehicle
{
    double _propellerSize;

    public string Brand => "Boat Brand";
}