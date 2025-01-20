// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, what would you like to do?");
Console.WriteLine("[S]ee all TODOs");
Console.WriteLine("[A]dd a TODO");
Console.WriteLine("[R]emove a TODO");
Console.WriteLine("[E]xit");

string userChoice = Console.ReadLine();

switch (userChoice)
{
    case "S":
        printSelectedOption("See all TODOs");
        break;
    case "A":
        printSelectedOption("Add a TODO");
        break;
    case "R":
        printSelectedOption("Remove a TODO");
        break;
    case "E":
        printSelectedOption("Exit");
        break;
    default:
        printSelectedOption("Invalid option.");
        break;
}

void printSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}