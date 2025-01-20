Console.WriteLine("Hello!");
Console.WriteLine("Please type the first number:");
double firstNumber = double.Parse(Console.ReadLine());
Console.WriteLine("Please type the second number:");
double secondNumber = double.Parse(Console.ReadLine());

double result;

string operationSymbol;

Console.WriteLine("Which operation would you like to do?");
Console.WriteLine("[A] for addition, [S] for subtraction, [D] for division, [M] for multiplication, and [R] for remainder.");
string userInput = Console.ReadLine().Trim().ToUpper();

if (userInput == "A")
{
    printSelectedOption("Addition");
    result = add(firstNumber, secondNumber);
    operationSymbol = "+";
} else if (userInput == "S")
{
    printSelectedOption("Subtraction");
    result = subtract(firstNumber, secondNumber);
    operationSymbol = "-";
} else if (userInput == "D")
{
    printSelectedOption("Division");
    result = divide(firstNumber, secondNumber);
    operationSymbol = "/";
} else if (userInput == "M")
{
    printSelectedOption("Multiplication");
    result = multiply(firstNumber, secondNumber);
    operationSymbol = "*";
} else if (userInput == "R")
{
    printSelectedOption("Remainder");
    result = remainder(firstNumber, secondNumber);
    operationSymbol = "%";
} else
{
    Console.WriteLine("Invalid option!");
    Console.ReadLine();
    return;
}

printResult(firstNumber, secondNumber, operationSymbol, result);

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

void printResult(double a, double b, string symbol, double c)
{
    Console.WriteLine(a + " " + symbol + " " + b + " = " + c);
}