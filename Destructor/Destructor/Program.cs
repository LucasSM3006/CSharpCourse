// If you run this code, you likely expect to see the messages, but the GC is unpredictable.

Person person = new Person { Name = "Gonzalo", Id = 1, Age = 22 };


for(var i = 0; i < 5; i++)
{
    var person3 = new Person { Name = "Kanzaki", Id = i + 1, Age = 20 + i };
}

GC.Collect(); // Forcing the garbage collector to run.
Console.WriteLine("Ready to close."); // On the console tab, you might see that the text here happens before the GC runs, and the reason for that is simple: Different threads.

// person.Finalize(); // Althought calling this makes it understand that we're trying to finalize it ourselves, it generates a compilation error. Only the CLR can call it.

Console.ReadKey();

public class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Age { get; set; }

    // Destructors are also called Finalizers, this is because a destructor during compilation is translated to a method called Finalize.
    // Destructor.
    ~Person()
    {
        Console.WriteLine($"Object person w/ Name: {Name} and Id: {Id} finalized.");
    }

    // We can't actually define it ourselves, but here's a finalization method. Declaring a destructor method works, and during compilation, it is translated into a finalize method.
    //protected override void Finalize()
    //{
    //    Console.WriteLine($"Object person w/ Name: {Name} and Id: {Id} finalized.");
    //}
}