var numbers = new List<int>() { 1, 4, 6, -1, 12, 44, -8, -19 };
var sum = new NumbersSumCalculator().Calculate(numbers);
Console.WriteLine("Sum is: " + sum);
Console.ReadKey();

public class NumbersSumCalculator
{
    public int Calculate(List<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum;
    }
}