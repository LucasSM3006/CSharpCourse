using DiceRollGameAssignment.Game;

GamePrinter gamePrinter = new GamePrinter();
DiceGame diceGame = new DiceGame();

GameResult gameResult = diceGame.Playgame();

gamePrinter.PrintEndGame(gameResult);

Console.ReadKey();