List<int> numbers = new List<int> { 1, 4, 2, 6, 5, 1, 2, 7 };

// Declaration is as follows:
// parameter => expression ie;
// n => n > 10
// n => n > 0
// n => n < 0
// n => n == 0
//
// more than one parameter is also possible;
//
// (p1, p2) => expression
//
// if there are no parameters:
// 
// () => expression
// 
// also...
// () => STATEMENTS
// statements return nothing, functions do. void return on statement.
// functions evaluate on a value, statements do not.
// () => Console.WriteLine()
//
// Types are also inferred, as such,
// var someFunc = n => n % 2 == 0;
// would not work.

Console.WriteLine($"Are any numbers larger than 10? {IsAny(numbers, n => n > 10)}"); // Lambda expression here.
Console.WriteLine($"Are any numbers even? {IsAny(numbers, n => n % 2 == 0)}");

Console.ReadKey();

bool IsAny(IEnumerable<int> numbers, Func<int, bool> predicate) // The func type will come here. // The last parameter in Func, ie, Func<int, BOOL> is the return parameter. Anything preceding it are the types of parameters
{
    foreach (int number in numbers)
    {
        if (predicate(number))
        {
            return true;
        }
    }
    return false;
}

public class Person
{
    public string FirstName { get; }
    public string LastName { get; }
    public int YearOfBirth { get; }

    public Person(string firstName, string lastName, int yearOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        YearOfBirth = yearOfBirth;
    }

}