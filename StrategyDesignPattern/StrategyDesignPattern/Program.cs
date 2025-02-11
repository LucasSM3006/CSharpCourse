var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };
FilteringStrategySelector filteringStrategySelector = new FilteringStrategySelector();

// There is also going to be an implementation of the open closed principle
// The principle that dictates that "modules, classes, and functions, should be opened for extension, but closed for modification"
// Aka, we should create our in code in a way that its behaviour changes by adding new code, and not modifying existing code.
// It brings positive sides, such as the code always working, tests like unit tests not needing to be added or updated, no new surprises, and y'won't need a new version of it


// So far, the code is looking good, but THIS below is an eye sore due to us needing to update it if we add more filters, which means it has to go, and use the keys of the dictionary we created.
// The dictionary was an alternative way, but since it's the only way to achieve what we want without extreme levels of complexity, we'll do just that.
Console.WriteLine("Select filter:");
Console.WriteLine(string.Join(Environment.NewLine, filteringStrategySelector.FilteringStrategiesNames));

var userInput = Console.ReadLine();

IEnumerable<int> result = new Filter().FilterBy(filteringStrategySelector.Select(userInput), numbers);

// Since it's now of a generic type, we can get away with things like...

List<string> words = new List<string> { "otter", "cow", "dog" };
var oWords = new Filter().FilterBy(word => word.StartsWith("o"), words);


Print(result);
Print(numbers);
Print(words);
Print(oWords);

Console.ReadKey();

// The strategy pattern lets us define a family of algorithms that perform some tasks, the concrete strategy can be chosen at runtime.

void Print<T>(IEnumerable<T> input)
{
    Console.WriteLine(string.Join(", ", input));
}

public class Filter
{
    // This method should never need to be modified.
    public IEnumerable<T> FilterBy<T>(Func<T, bool> predicate, IEnumerable<T> numbers)
    {
        List<T> result = new List<T>();

        foreach (T number in numbers)
        {
            if (predicate(number)) result.Add(number);
        }

        return result;
    }
}

public class FilteringStrategySelector
{

    public readonly Dictionary<string, Func<int, bool>> _filteringStrategies =
    new Dictionary<string, Func<int, bool>>
    {
        ["even"] = n => n % 2 == 0,
        ["odd"] = n => n % 2 != 0,
        ["positive"] = n => n > 0,
        ["negative"] = n => n < 0
    };

    public IEnumerable<string> FilteringStrategiesNames => _filteringStrategies.Keys;

    public Func<int, bool> Select(string filteringType)
    {

         if(!_filteringStrategies.ContainsKey(filteringType.ToLower()))
         {
              throw new NotSupportedException($"Invalid user input, {filteringType} is not a filter.");
         }
         
         return _filteringStrategies[filteringType.ToLower()];
    }
}