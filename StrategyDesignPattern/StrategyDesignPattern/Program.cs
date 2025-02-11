var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

// Now say we want to allow the user to choose how those numbers are filter, like when they enter "even" or "odd", or "positive", etc.

Console.WriteLine(@"Select filter:
Even
Odd");

var userInput = Console.ReadLine();

List<int> result;
switch(userInput.ToLower())
{
    case "even":
        result = SelectEven(numbers);
        break;
    case "odd":
        result = SelectOdd(numbers);
        break;
    case "positive":
        result = SelectPositive(numbers);
        break;
    case "negative":
        result = SelectNegative(numbers);
        break;
    default:
        throw new NotSupportedException($"Invalid user input, {userInput} is not a filter.");
}

Print(result);
Print(numbers);

Console.ReadKey();

List<int> SelectEven(List<int> numbers)
{
    List<int> evenNumbers = new List<int>();

    foreach (int number in numbers)
    {
        if(number % 2 == 0) evenNumbers.Add(number);
    }

    return evenNumbers;
}

List<int> SelectOdd(List<int> numbers)
{
    List<int> oddNumbers = new List<int>();

    foreach (int number in numbers)
    {
        if (number % 2 != 0) oddNumbers.Add(number);
    }

    return oddNumbers;
}

List<int> SelectPositive(List<int> numbers)
{
    List<int> positiveNumbers = new List<int>();

    foreach(int number in numbers)
    {
        if (number > 0)
        {
            positiveNumbers.Add(number);
        }
    }

    return positiveNumbers;
}

List<int> SelectNegative(List<int> numbers)
{
    List<int> negativeNumbers = new List<int>();

    foreach (int number in numbers)
    {
        if (number < 0)
        {
            negativeNumbers.Add(number);
        }
    }

    return negativeNumbers;
}

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}