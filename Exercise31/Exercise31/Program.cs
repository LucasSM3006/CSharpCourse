/*
 * Generic types - Pair class

Implement the generic Pair type as follows:

    It should be a container for two items of the same type.

    It should have two properties called First and Second of the type that parameterized this class. Both those properties should be publically gettable but should not be publically settable.

    It should have a constructor taking two parameters that sets First and Second properties

    This class should expose public ResetFirst and ResetSecond methods that set the First or the Second property to the default values for their type.


For example, this is how we may want to use this class:

var pairOfInts = new Pair<int>(1,2);
Console.WriteLine($"First is {pairOfInts.First}");
Console.WriteLine($"Second is {pairOfInts.Second}");
pairOfInts.ResetFirst(); // Will set the first to 0
 * 
 * 
 */

var pairOfInts = new Pair<int>(1, 2);
Console.WriteLine($"First is {pairOfInts.First}");
Console.WriteLine($"Second is {pairOfInts.Second}");
pairOfInts.ResetFirst(); // Will set the first to 0
Console.WriteLine($"First is {pairOfInts.First}");
Console.WriteLine($"Second is {pairOfInts.Second}");

Console.ReadKey();
public class Pair<T>
{
    public T First { get; private set; }
    public T Second { get; private set; }

    public Pair(T first, T second)
    {
        First = first;
        Second = second;
    }

    public void ResetFirst()
    {
        First = default;
    }

    public void ResetSecond()
    {
        Second = default;
    }
}