var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

// Now say we want to allow the user to choose how those numbers are filter, like when they enter "even" or "odd", or "positive", etc.

Console.WriteLine(@"Select filter:
Even
Odd");

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
                return SelectEven(numbers);
            case "odd":
                return SelectOdd(numbers);
            case "positive":
                return SelectPositive(numbers);
            case "negative":
                return SelectNegative(numbers);
            default:
                throw new NotSupportedException($"Invalid user input, {filteringType} is not a filter.");
        }
    }

    private List<int> SelectEven(List<int> numbers)
    {
        List<int> evenNumbers = new List<int>();

        foreach (int number in numbers)
        {
            if (number % 2 == 0) evenNumbers.Add(number);
        }

        return evenNumbers;
    }

    private List<int> SelectOdd(List<int> numbers)
    {
        List<int> oddNumbers = new List<int>();

        foreach (int number in numbers)
        {
            if (number % 2 != 0) oddNumbers.Add(number);
        }

        return oddNumbers;
    }

    private List<int> SelectPositive(List<int> numbers)
    {
        List<int> positiveNumbers = new List<int>();

        foreach (int number in numbers)
        {
            if (number > 0)
            {
                positiveNumbers.Add(number);
            }
        }

        return positiveNumbers;
    }

    private List<int> SelectNegative(List<int> numbers)
    {
        List<int> negativeNumbers = new List<int>();

        foreach (int number in numbers)
        {
            if (number < 0)
            {
                negativeNumbers.Add(number);
            }
        }

        return negativeNumbers;
    }

}