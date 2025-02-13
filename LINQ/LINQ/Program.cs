// LINQ is a set of technologies that allow simple and efficient querying over different kinds of data.
// Language Integrated Query
// Allows filtering, ordering, and transforming the collection elements, and more.

List<string> words = new List<string> { "BalLs", "LsL", "Dee", "heeasd", "BEATS" };

Console.WriteLine(IsAnyWordUpperCase(words));

Console.ReadKey();

static bool IsAnyWordUpperCase(IEnumerable<string> words)
{
    foreach (string word in words)
    {
        List<char> characters = word.ToList();
        bool isUpper = false;

        foreach (char c in characters)
        {
            if (char.IsUpper(c))
            {
                isUpper = true;
                continue;
            }
            isUpper = false;
            break;
        }
        if (isUpper) return true;
    }
    return false;
}