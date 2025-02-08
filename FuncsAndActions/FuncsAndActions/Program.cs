int a = 5;
Person person = new Person("Roxanne", "Varguez", 1999);

Console.ReadKey();

bool IsAnyLargerThan10(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        if (number > 0)
        {
            return true;
        }
    }
    return false;
}

bool IsAnyEven(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        if (number % 2 == 0)
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