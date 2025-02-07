List<int> numbers = new List<int> { 5, 3, 2, 8, 16, 7 };
SimpleTuple<int, int> minAndMax = GetMinAndMax(numbers);
Console.WriteLine($"Smallest number is {minAndMax.Element1}");
Console.WriteLine($"Biggest number is {minAndMax.Element2}");
SimpleTuple<int, int, int> threeitems; // Different type of SimpleTuple, just shares the name.

Console.ReadKey();

SimpleTuple<int, int> GetMinAndMax(IEnumerable<int> input)
{
    if(!input.Any())
    {
        throw new InvalidOperationException("Input collection cannot be empty.");
    }

    int min = input.First();
    int max = input.First();

    foreach (int number in input)
    {
        if(number > max)
        {
            max = number;
        }
        if(number < min)
        {
            min = number;
        }
    }

    return new SimpleTuple <int, int> (min, max);
}

public class SimpleTuple<T1, T2>
{
    public SimpleTuple(T1 element1, T2 element2)
    {
        Element1 = element1;
        Element2 = element2;
    }

    public T1 Element1 { get; }
    public T2 Element2 { get; }
}

public class SimpleTuple<T1, T2, T3>
{
    public SimpleTuple(T1 element1, T2 element2, T3 element3)
    {
        Element1 = element1;
        Element2 = element2;
        Element3 = element3;
    }

    public T1 Element1 { get; }
    public T2 Element2 { get; }
    public T3 Element3 { get; }
}
