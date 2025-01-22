List<string> words = new List<string>();

Console.WriteLine($"Count of elements in words: {words.Count}");

words.Add("Tally ho");

Console.WriteLine($"Count of elements in words: {words.Count}");

List<string> numbers = new List<string>
{
    "one",
    "two",
};

Console.WriteLine($"Count of elements in numbers: {numbers.Count}");

foreach( string word in words )
{
    Console.WriteLine(word);
}

for( int i = 0; i < numbers.Count; i++ )
{
    Console.WriteLine(numbers[i]);
}

// Removing items.

Console.WriteLine("Removing an item from words");

words.Remove("Tally ho");
// words.RemoveAt(0);

Console.WriteLine("Removing an item from words");

// numbers.Remove("one");
numbers.RemoveAt(0);

Console.WriteLine($"Count of elements in words: {words.Count}");
Console.WriteLine($"Count of elements in numbers: {numbers.Count}");

Console.WriteLine("Adding new things to words using AtRange.");

string[] moreWords = new [] { "cannon ball", "tallow", "heheh", "politikz" };
words.AddRange( moreWords );
// words.AddRange(new [] { "non canon", "fictional", "possibility" });

Console.WriteLine($"Index of 'tallow' in words is... {words.IndexOf("tallow")}");
Console.WriteLine($"Contains 'five' in words?{words.Contains("five")}");
Console.WriteLine($"Contains 'tallow' in words?{words.Contains("tallow")}");

Console.WriteLine($"Count of elements in words: {words.Count}");

Console.WriteLine("Clearing both lists now.");

words.Clear();
numbers.Clear();

Console.WriteLine($"Count of elements in words: {words.Count}");
Console.WriteLine($"Count of elements in numbers: {numbers.Count}");

Console.ReadKey();