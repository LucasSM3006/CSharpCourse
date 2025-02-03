Console.WriteLine("Enter a number:");
string input = Console.ReadLine();
try
{
    int number = ParseStringToInt(input);
    int result = 10 / number;
    Console.WriteLine($"10 / {number} = {result}");
}
catch (FormatException e)
{
    Console.WriteLine("Wrong format. Input is not parsable into an integer.");
    Console.WriteLine($"Exception message: {e.Message}");
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