// List<int> numbers = new List<int> { 1, 2, 3 };
// int first = GetFirstElement(numbers);

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
        Name = name;
        YearOfBirth = yearOfBirth;
    }
}