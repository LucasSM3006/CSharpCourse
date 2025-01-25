
using DiceRollGameAssignment;

DiceGame diceGame = new DiceGame();
diceGame.Playgame();

Console.ReadKey();

public class DiceGame
{
    const int NumberOfTries = 3;
    Random randomNumberGenerator = new Random();
    GamePrinter gamePrinter = new GamePrinter();

    public void Playgame()
    {
        
        Dice dice = new Dice(6, randomNumberGenerator); // Number of sides the dice has.
        int numberOfSides = dice.GetSides();
        int randomNumber = dice.RollDice();
        bool win = false;

        gamePrinter.PrintStartGame($"Dice with {numberOfSides} sides rolled. You have {NumberOfTries} tries to guess the number it landed on.");

        for (int i = 1; i <= NumberOfTries; i++)
        {
            Console.WriteLine($"Current trial: {i}");

            int guess = ConsoleReader.ReadInteger("Enter your guess: ");

            if (guess == randomNumber)
            {
                win = true;
                break;
            }

            Console.WriteLine("Wrong number, try again!");
        }

        gamePrinter.PrintEndGame(win);
    }
}