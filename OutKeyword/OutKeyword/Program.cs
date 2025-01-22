int[] numbers = new [] { 10, -8, 2, 12, -17 };
int nonPositiveCount;
List<int> positiveNumbers = GetOnlyPositive(numbers, out nonPositiveCount);

Console.WriteLine($"This many non positive numbers: {nonPositiveCount}");

Console.ReadKey();

List<int> GetOnlyPositive(int[] numbers, out int countNonPositive)
{
    List<int> result = new List<int>();
    countNonPositive = 0;

    foreach (int number in numbers)
    {
        if(number > 0)
        {
            result.Add(number);
        }
        else
        {
            countNonPositive++;
        }
    }
    return result;
}