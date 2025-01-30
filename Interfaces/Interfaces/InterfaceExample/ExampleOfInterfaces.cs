namespace Interfaces.InterfaceExample
{
    // While inheritance has a "is-a" behaviour, where you've got Automobile, Aquatic, and Air all being Vehicles...
    // Interfaces do not, their relationship is more of a "behaves-like", as shown below.
    
    public interface IsFlyable
    {
        void Fly(); // The classes which implement this need to follow the rules of it. You cannot override it and change parameters or the return type. It won't compile otherwise.
        // They're implicitly virtual as well. Classes that extend from this interface need not implement it, but they need to have it declared within regardless of whether it's being used.
        // Just like in Java & multiple different languages, you cannot instantiate an interface, only extend from it.
    }

    public interface Animal
    {
        string species { get; set; }
        void MakeSound(); // Can be private, but you need to implement it.
    }
    // Interfaces can also extend from each other.

    public interface HousePet : Animal
    {
        string name { get; set; }
    }

    // You can also extend from multiple interfaces.
    public class Bird : IsFlyable, Animal
    {
        public string species { get; set; }
        public void Tweet()
        {
            Console.WriteLine("Chirp");
        }

        public void Fly()
        {
            Console.WriteLine("Flies by flapping wings");
        }

        public void MakeSound()
        {
            Tweet();
        }
    }

    public class Kite : IsFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flies carried by the wind");
        }
    }

    public class Plane : IsFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flies with its wings & propulsion");
        }
    }
}
