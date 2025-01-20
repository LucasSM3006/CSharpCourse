Console.WriteLine("Enter a word");
string userInput = Console.ReadLine();

while (userInput.Length < 15)
{
    userInput += "a";
    Console.WriteLine(userInput);
}

Console.WriteLine("Loop is finished");
Console.ReadKey();