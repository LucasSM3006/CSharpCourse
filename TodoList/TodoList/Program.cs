// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, what would you like to do?");
Console.WriteLine("[S]ee all TODOs");
Console.WriteLine("[A]dd a TODO");
Console.WriteLine("[R]emove a TODO");
Console.WriteLine("[E]xit");

string userChoice = Console.ReadLine();

if(userChoice == "S") {
    printSelectedOption("See all TODOs");
} else if (userChoice == "A") {
    printSelectedOption("Add a TODO");
} else if (userChoice == "R") {
    printSelectedOption("Remove a TODO");
} else if (userChoice == "E") {
    printSelectedOption("Exit");
} else {
    printSelectedOption("Invalid option.");
}

void printSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}