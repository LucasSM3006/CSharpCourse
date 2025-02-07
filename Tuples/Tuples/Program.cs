List<int> numbers = new List<int> { 5, 3, 2, 8, 16, 7 };
TwoInts minAndMax = GetMinAndMax(numbers);
Console.WriteLine($"Smallest number is {minAndMax.Int1}");
Console.WriteLine($"Biggest number is {minAndMax.Int2}");

Console.ReadKey();

TwoInts GetMinAndMax(IEnumerable<int> input)
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

    return new TwoInts(min, max);
}

public class TwoInts
{
    public TwoInts(int int1, int int2)
    {
        Int1 = int1;
        Int2 = int2;
    }

    public int Int1 { get; }
    public int Int2 { get; }
}

