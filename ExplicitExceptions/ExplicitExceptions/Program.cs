// List<int> numbers = new List<int> { 1, 2, 3 };
// int first = GetFirstElement(numbers);

Person invalidPerson = new Person("", -100);

Console.ReadKey();

int GetFirstElement(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        return number;
    }

    throw new Exception("The collection cannot be empty.");
    // This is okay because it's not this method's responsibility to figure out what to do with the invalid input.
    // We throw an exception here because we can't handle the input in a reasonable way, and an invalid input is whoever's implementing the method's mistake.
}

class Person
{
    public string Name { get; }
    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        if (name == string.Empty)
        {
            throw new Exception("Invalid name. Must not be empty.");
        }
        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
        {
            throw new Exception("Invalid year. Must be below current year & above 1900");
        }
        Name = name;
        YearOfBirth = yearOfBirth;
    }
}