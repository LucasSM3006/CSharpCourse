int number = 5;

AddOneToNumber(ref number);

Console.WriteLine($"Number is: {number}");

Console.ReadKey();

void AddOneToNumber(ref int number)
{
    ++number;
}