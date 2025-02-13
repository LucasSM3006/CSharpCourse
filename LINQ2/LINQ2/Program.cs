// We don't have to declare "using System.Linq" because it's imported with global usings. You can still see it on projects that don't use it, tho.

var words = new List<string> { "a", "bb", "ccc", "dddd" };
var wordsLongerThanTwoLetters = words.Where(word => word.Length > 2);

var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
var oddNumbers = numbers.Where(number => number % 2 != 0); // Right click "Where" and click "Go to implementation"
// Linq is an extension for IEnumerables, so we can use it on just about any collections!

Console.ReadKey();

