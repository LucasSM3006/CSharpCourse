int userNumber;
do
{
    Console.WriteLine("Enter a number bigger than 10 (write 'stop' to leave.");
    string userInput = Console.ReadLine();

    if (userInput.Trim() == "stop") break;

    bool isParsableInt = userInput.All(char.IsDigit);

    if (!isParsableInt)
    {
        userNumber = 0;
        continue;
    }

    userNumber = int.Parse(userInput.Trim());
} while (userNumber <= 10);

Console.WriteLine("Loop is finished");
Console.ReadKey();