Console.WriteLine("Hello!");
Console.WriteLine("Please type the first number:");
double firstNumber = double.Parse(Console.ReadLine());
Console.WriteLine("Please type the second number:");
double secondNumber = double.Parse(Console.ReadLine());

Console.WriteLine("Which operation would you like to do?");
Console.WriteLine("[A] for addition, [S] for subtraction, [D] for division, [M] for multiplication, and [R] for remainder.");
string userInput = Console.ReadLine().Trim().ToUpper();

if (userInput == "A")
{
    printSelectedOption("Addition");
    printResult(add(firstNumber, secondNumber));
} else if (userInput == "S")
{
    printSelectedOption("Subtraction");
    printResult(subtract(firstNumber, secondNumber));
} else if (userInput == "D")
{
    printSelectedOption("Division");
    printResult(divide(firstNumber, secondNumber));
} else if (userInput == "M")
{
    printSelectedOption("Multiplication");
    printResult(multiply(firstNumber, secondNumber));
} else if (userInput == "R")
{
    printSelectedOption("Remainder");
    printResult(remainder(firstNumber, secondNumber));
} else
{
    Console.WriteLine("Invalid option!");
}

Console.ReadLine();

double add(double a, double b)
{
    return a + b;
}

double subtract(double a, double b)
{
    return a - b;
}

double divide(double a, double b)
{
    return a / b;
}

double multiply(double a, double b)
{
    return a * b;
}

double remainder(double a, double b)
{
    return a % b;
}

void printSelectedOption(string option)
{
    Console.WriteLine("Selected option: " + option);
}

void printResult(double result)
{
    Console.WriteLine("Result: " + result);
}