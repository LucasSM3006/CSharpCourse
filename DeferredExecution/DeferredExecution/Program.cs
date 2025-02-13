// Deferred execution means that the evaluation of a LINQ expression is delayed until the value is actually needed
// It improves performance by avoiding unnecessary execution

var words = new List<string> { "a", "bb", "ccc", "dddd" } ;

var shortwords = words.Where(word => word.Length < 3); // It's a query, not data.
var shortwordslist = words.Where(word => word.Length < 3).ToList(); // This, however, would immediately turn it into data. It won't update.


Console.WriteLine("first iteration");
foreach (var word in shortwords)
{
    Console.WriteLine(word);
}

Console.WriteLine($"Another example, all words in shortwords: {{ {string.Join(", ", shortwords)} }} at first.");

words.Add("e"); // So when we add a new thing value to the collection that's part of the actual data we query on...

Console.WriteLine($"Another example, all words in shortwords: {{ {string.Join(", ", shortwords)} }} immediately after adding a new value.");

Console.WriteLine("second iteration"); 
foreach (var word in shortwords) // The second iteration is updated with the query.
{
    Console.WriteLine(word);
}

// Basically, the query is only executed when it is needed, which means that whenever we run a loop with it or do whatever with it, it'll "update".

Console.ReadKey();