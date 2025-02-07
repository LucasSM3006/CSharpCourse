
List<int> ints = new List<int> { 1, 2, 3 };

Console.WriteLine(ints[0]);

ints.AddToFront(10);
// ints.AddToFront<int>(10); // This wasn't needed due to the type being inferred by the compiler. 
// ints.AddToFront("abc"); // Generates a compiling error, 'The type arguments for method AddToFront cannot be inferred from the usage.'  

Console.WriteLine(ints[0]);

List<decimal> decimals = new List<decimal> { 11.2m, 22.4m, 22.3m, 0.5m };

foreach (decimal d in decimals)
{
    Console.WriteLine(d);
}

// List<int> integers = (List<int>)decimals; // This doesn't work, we need to cast each individual item.
List<int> integers = decimals.ConvertTo<decimal, int>();

foreach (int i in integers)
{
    Console.WriteLine(i);
}

Console.ReadKey();

static class ListExtensions
{
    public static void AddToFront<T>(this List<T> list, T item)
    {
        list.Insert(0, item);
    }

    // Generic method with multiple parameters.
    public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> input)
    {
        var result = new List<TTarget>();

        foreach (var item in input)
        {
            TTarget itemAfterCasting = (TTarget) Convert.ChangeType(item, typeof(TTarget)); // Must be cast to the type we want due to it returning a System object.
            result.Add(itemAfterCasting);
        }

        return result;
    }
}

