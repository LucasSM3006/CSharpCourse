// Note: Linq does not modify the input, it instead creates a new one.

var numbers = new List<int> { 5, 3, 7, 1, 2, 4 };
var numbersWith10 = numbers.Append(10);

// Despite appending ten to it on the line above, the input, 'numbers' remained unmodified.

Console.WriteLine($"Numbers without appending 10: {{ {string.Join(", ", numbers)} }}");
Console.WriteLine($"Numbers with appending 10: {{ {string.Join(", ", numbersWith10)} }}");

// Another example;

var oddNumbers = numbers.Where(number => number % 2 != 0);
var orderedOddNumbers = oddNumbers.OrderBy(number => number);

// It's very similar to streams in Java, but much simpler..
var orderedOddNumbersALT = numbers
    .Where(number => number % 2 != 0)
    .OrderBy(number => number);
// Code above is method chaining.

Console.WriteLine($"Odd numbers: {{ {string.Join(", ", oddNumbers)} }}");
Console.WriteLine($"Ordered numbers: {{ {string.Join(", ", orderedOddNumbers)} }}");
Console.WriteLine($"Ordered numbers ALT: {{ {string.Join(", ", orderedOddNumbersALT)} }}");

Console.ReadKey();
