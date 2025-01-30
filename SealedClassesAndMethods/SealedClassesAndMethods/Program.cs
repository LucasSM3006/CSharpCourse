// So the sealed keyword can be used to stop classes from inheriting things from other classes.

// Only virtual methods can be sealed.

public abstract class Vehicle
{
    public abstract void Build();
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