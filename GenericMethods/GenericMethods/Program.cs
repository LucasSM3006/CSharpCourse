
List<int> ints = new List<int> { 1, 2, 3 };

Console.WriteLine(ints[0]);

ints.AddToFront(10);
// ints.AddToFront<int>(10); // This wasn't needed due to the type being inferred by the compiler. 
// ints.AddToFront("abc"); // Generates a compiling error, 'The type arguments for method AddToFront cannot be inferred from the usage.'  

Console.WriteLine(ints[0]);

Console.ReadKey();

static class ListExtensions
{
    public static void AddToFront<T>(this List<T> list, T item)
    {
        list.Insert(0, item);
    }
}