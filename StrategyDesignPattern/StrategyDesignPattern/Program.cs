﻿var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };
FilteringStrategySelector filteringStrategySelector = new FilteringStrategySelector();

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

List<int> result = new NumbersFilter().FilterBy(filteringStrategySelector.Select(userInput), numbers);

Print(result);
Print(numbers);

Console.ReadKey();

// The strategy pattern lets us define a family of algorithms that perform some tasks, the concrete strategy can be chosen at runtime.

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

public class NumbersFilter
{
    // This method should never need to be modified.
    public List<int> FilterBy(Func<int, bool> predicate, List<int> numbers)
    {
        List<int> result = new List<int>();

        foreach (int number in numbers)
        {
            if (predicate(number)) result.Add(number);
        }

        return result;
    }
}

public class FilteringStrategySelector
{
    /*
     * private readonly Dictionary<string, Func<int, bool>> _filteringStrategies =
     * new Dictionary<string, Func<int, bool>>
     * {
     *      ["even"] = n => n % 2 == 0,
     *      ["odd"] = n => n % 2 != 0,
     *      ["positive"] = n => n > 0,
     *      ["negative"] = n => n < 0
     * };
     * 
     */
    public Func<int, bool> Select(string filteringType)
    {
        /* // Alternative way of doing it.
         * 
         * if(!_filteringStrategies.ContainsKey(filteringType))
         * {
         *      throw new NotSupportedException($"Invalid user input, {filteringType} is not a filter.");
         * }
         * 
         * return _filteringStrategies[filteringType.ToLower()];
         * 
         */
        switch (filteringType.ToLower())
        {
            case "even":
                return n => n % 2 == 0;
            case "odd":
                return n => n % 2 != 0;
            case "positive":
                return n => n > 0;
            case "negative":
                return n => n < 0;
            default:
                throw new NotSupportedException($"Invalid user input, {filteringType} is not a filter.");
        }
    }
}