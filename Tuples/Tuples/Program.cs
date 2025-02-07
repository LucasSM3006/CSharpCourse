List<int> numbers = new List<int> { 5, 3, 2, 8, 16, 7 };
/*Simple*/Tuple<int, int> minAndMax = GetMinAndMax(numbers);
/*Simple*/Tuple<string, int> stringAndInt = new Tuple<string, int> ("aaa", 2);

Console.WriteLine($"Smallest number is {minAndMax.Item1}");
Console.WriteLine($"Biggest number is {minAndMax.Item2}");

/*Simple*/Tuple<int, int, int> threeitems; // Different type of SimpleTuple, just shares the name.

Console.ReadKey();

/*Simple*/Tuple<int, int> GetMinAndMax(IEnumerable<int> input)
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

    return new /*Simple*/Tuple <int, int> (min, max);
}

public class SimpleTuple<T1, T2>
{
    public SimpleTuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    public T1 Item1 { get; }
    public T2 Item2 { get; }
}

public class SimpleTuple<T1, T2, T3>
{
    public SimpleTuple(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
    }

    public T1 Item1 { get; }
    public T2 Item2 { get; }
    public T3 Item3 { get; }
}
