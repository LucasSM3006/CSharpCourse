var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

// Now say we want to allow the user to choose how those numbers are filter, like when they enter "even" or "odd", or "positive", etc.

Console.WriteLine(@"Select filter:
Even
Odd
Positive
Negative");

var userInput = Console.ReadLine();

List<int> result = new NumbersFilter().FilterBy(userInput, numbers);

Print(result);
Print(numbers);

Console.ReadKey();


void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

public class NumbersFilter
{
    public List<int> FilterBy(string filteringType, List<int> numbers)
    {
        switch (filteringType.ToLower())
        {
            case "even":
                return Select(numbers, n => n % 2 == 0);
            case "odd":
                return Select(numbers, n => n % 2 != 0);
            case "positive":
                return Select(numbers, n => n > 0);
            case "negative":
                return Select(numbers, n => n < 0);
            default:
                throw new NotSupportedException($"Invalid user input, {filteringType} is not a filter.");
        }
    }

    private List<int> Select(List<int> numbers, Func<int, bool> predicate)
    {
        List<int> result = new List<int>();

        foreach (int number in numbers)
        {
            if (predicate(number)) result.Add(number);
        }

        return result;
    }
}