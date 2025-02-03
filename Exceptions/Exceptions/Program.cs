Console.WriteLine("Enter a number:");
string input = Console.ReadLine();
try
{
    int number = ParseStringToInt(input);
    Console.WriteLine($"String successfully parsed. Result is: {number}");
}
catch (Exception e)
{
    Console.WriteLine("An exception was thrown.");
    Console.WriteLine(e.Message);
}
finally // Always executed even when it runs properly. Useful for closing DB connections, for example.
{
    Console.WriteLine("Finally block being executed");
}

Console.ReadKey();

int ParseStringToInt(string input)
{
    return int.Parse(input);
}