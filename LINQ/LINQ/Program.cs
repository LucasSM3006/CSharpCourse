// LINQ is a set of technologies that allow simple and efficient querying over different kinds of data.
// Language Integrated Query
// Allows filtering, ordering, and transforming the collection elements, and more.

List<string> words = new List<string> { "BalLs", "LsL", "Dee", "heeasd", "BEATsS" };

Console.WriteLine(IsAnyWordUpperCase(words));

Console.ReadKey();

static bool IsAnyWordUpperCase(IEnumerable<string> words)
{
    foreach (string word in words)
    {
        List<char> characters = word.ToList();
        bool isUpper = true;

        foreach (char c in characters)
        {
            if (char.IsLower(c))
            {
                isUpper = false;
                break;
            }
        }
        if (isUpper) return true;
    }
    return false;
}

static bool IsAnyWordUpperCaseLINQ(IEnumerable<string> words)
{
    return words.Any(word => word.All(letter => char.IsUpper(letter)));
    // STREAM, LITERALLY A STREAM.
    // Okay, so, words has words, we use Any to iterate through, and word is the element from the list. "All" will determine if all elements satisfy a condition, the condition? ARE THEY UPPER? It's a generic method using a Func, just like we've seen before!
}