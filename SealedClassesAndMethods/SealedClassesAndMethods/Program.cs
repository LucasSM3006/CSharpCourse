// So the sealed keyword can be used to stop classes from inheriting things from other classes.

// Only virtual methods can be sealed.

Automobile automobile = new Automobile();

automobile.Lol();

public abstract class Vehicle
{
    public abstract void Build();
    public void Lol() { Console.WriteLine(""); }
}

public class Automobile : Vehicle
{
    // The sealed modifier here stops "Build()" from being further overridden down the line.

    public sealed override void Build()
    {
        Console.WriteLine("Automobile.");
    }
}

public sealed class SUV : Automobile
{
    // public override void Build();  // "Cannot override Build() because it is sealed"
}

// This cannot be done thanks to the sealed keyword:

// public class Crossover : SUV
// {
//
// }

// This code below is to demonstrate that static classes are always sealed.

public static class VehicleGenerator
{
    public static void Generate(int wheels)
    {

    }
}

// This generates a compiling error. Static classes cannot be instantiated, nor can they be inherited.
// They're always sealed because they only contain static methods, and static methods cannot be overridden.
// The entire point of overriding is to have specific implementations of a method when executing a specific instance.
// Static methods are not called on instances since you can't instantiate them, which makes static classes useless as base types, and impossible to use.

// public static class AutomobileGenerator : VehicleGenerator
// {
// 
// }