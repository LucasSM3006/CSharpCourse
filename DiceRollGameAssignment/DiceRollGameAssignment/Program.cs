using DiceRollGameAssignment.Game;

GamePrinter gamePrinter = new GamePrinter();
DiceGame diceGame = new DiceGame();

GameResult gameResult = diceGame.Playgame();

gamePrinter.PrintEndGame(gameResult);

Console.ReadKey();

public class DiceGame
{
    const int NumberOfTries = 3;
    Random randomNumberGenerator = new Random();
    GamePrinter gamePrinter = new GamePrinter();

    public GameResult Playgame()
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
                return GameResult.Win;
            }

            Console.WriteLine("Wrong number.");
        }

        return GameResult.Loss;
    }
}