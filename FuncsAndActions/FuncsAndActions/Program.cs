int a = 5;
Person person = new Person("Roxanne", "Varguez", 1999);

Func<int, DateTime> someFunc; // Func used if it has a return value.
Action<string, bool> someAction; // Actions are used for void return. Can repesent any void function taking in a string and a boolean.

List<int> numbers = new List<int> { 1, 4, 2, 6, 5, 1, 2, 7 };
Func<int, bool> predicate1 = IsLargerThanTen;
Func<int, bool> predicate2 = IsEven;

Console.WriteLine($"Are any numbers larger than 10? {IsAny(numbers, predicate1)}");
Console.WriteLine($"Are any numbers even? {IsAny(numbers, predicate2)}");

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

bool IsLargerThanTen(int number)
{
    return number > 10;
}

bool IsEven(int number)
{
    return (number % 2 == 0);
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