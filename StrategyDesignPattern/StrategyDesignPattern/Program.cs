var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

// There is also going to be an implementation of the open closed principle
// The principle that dictates that "modules, classes, and functions, should be opened for extension, but closed for modification"
// Aka, we should create our in code in a way that its behaviour changes by adding new code, and not modifying existing code.
// It brings positive sides, such as the code always working, tests like unit tests not needing to be added or updated, no new surprises, and y'won't need a new version of it

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
    // This is pretty good, but now it breaks SRP and is also going to need to be modified in the future if we want to add new things.
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