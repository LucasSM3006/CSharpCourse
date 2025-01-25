
Random randomMaker = new Random();

const int NumberOfTries = 3;
int diceNumber = randomMaker.Next(1, 7);
bool win = false;

//for(int i = 0; i < 100; i++)
//{
//    Console.WriteLine($"Random number generated: {randomMaker.Next(1, 7)}");
//}

Console.WriteLine($"Dice Rolled. Guess what number it was in 3 tries.");



for(int i = 1; i <= NumberOfTries; i++)
{
    Console.WriteLine($"Current trial: {i}");
    Console.WriteLine("Enter your guess: ");

    string userInput = Console.ReadLine();

    int actualNumber;
    bool isParsingSuccessful = int.TryParse(userInput, out actualNumber);

    if(!isParsingSuccessful)
    {
        Console.WriteLine("Invalid parsing, try again.");
        i--;
        continue;
    }

    if(actualNumber > 6)
    {
        Console.WriteLine("Out of range. Choose between 1 to 6");
        i--;
        continue;
    }

    if(actualNumber == diceNumber)
    {
        win = true;
        break;
    }

    Console.WriteLine("Wrong number, try again!");
}

if(win)
{
    PrintEndGame("win");
}
else
{
    PrintEndGame("lose");
}

Console.ReadKey();


void PrintEndGame(string result)
{
    Console.WriteLine($"You {result}!");
}
//do
//{

//} while (true);