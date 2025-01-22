/*
Console.WriteLine("Enter a number:");
string userInput = Console.ReadLine();
int asNumber = int.Parse(userInput);

This is unhandled. A try/catch could work, but there's tryparse. Here it is.
 
 */
int number;
Console.WriteLine("Enter a number:");
string userInput = Console.ReadLine();
bool isParsingSuccessful = int.TryParse(userInput, out number);
// bool isParsingSuccessful = int.TryParse(userInput, out int number); Declaring the 'number' variable inside it is also OK.

if (isParsingSuccessful)
{
    Console.WriteLine($"Parsing successful. Number is: {number}");
}

// Loop for constant validation. Different variables for clarity.

bool isParsingSuccess;
do
{
    Console.WriteLine("Enter a number:");
    string usrInput = Console.ReadLine();
    isParsingSuccess = int.TryParse(usrInput, out int num);
    
    if (isParsingSuccess)
    {
        Console.WriteLine($"Parsing successful. Number is: {num}");
    }
    else
    {
        Console.WriteLine("Parsing unsuccessful! Enter a number! Ex: 10");
    }
} while (!isParsingSuccess);



Console.WriteLine("Press enter to leave.");
Console.ReadKey();