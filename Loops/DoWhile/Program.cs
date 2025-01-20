string word;
do
{
    Console.WriteLine("Enter a word longer than 10 letters");
    word = Console.ReadLine();
} while (word.Length < 10);

Console.WriteLine("Loop is finished");
Console.ReadKey();