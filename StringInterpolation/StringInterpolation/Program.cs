// Traditional method I've been doing so far.
int a = 4, b = 2, c = 10;
Console.WriteLine(
    "First is: " + a + ", second is: " + b + ", third is: " + c);

// String interpolation method, aka, embedding strings and variables directly into it.
Console.WriteLine($"First is: {a}, second is: {b}, third is: {c}");

// Same result, but one feels more natural to write.

Console.ReadKey();