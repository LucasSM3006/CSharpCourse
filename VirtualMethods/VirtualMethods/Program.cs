var numbers = new List<int>() { 1, 4, 6, -1, 12, 44, -8, -19 };
bool shallAddPositiveOnly = true;

int sum;

if(shallAddPositiveOnly)
{
    sum = new PositiveNumbersSumCalculator().Calculate(numbers);
}
else
{
    sum = new NumbersSumCalculator().Calculate(numbers);
}

Console.WriteLine("Sum is: " + sum);
Console.ReadKey();

public class NumbersSumCalculator
{
    public int Calculate(List<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            if(ShallBeAdded(number)){
                sum += number;
            }
        }
        return sum;
    }

    protected virtual bool ShallBeAdded(int number)
    {
        return true;
    }
}

public class PositiveNumbersSumCalculator : NumbersSumCalculator
{
    protected override bool ShallBeAdded(int number)
    {
        return number > 0;
    }
}