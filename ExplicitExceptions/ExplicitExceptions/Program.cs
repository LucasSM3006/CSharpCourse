// List<int> numbers = new List<int> { 1, 2, 3 };
// int first = GetFirstElement(numbers);

Person invalidPerson = new Person("", -100);

// int[] numbers = new int[] { 1, 2, 3 };
// int fourthNumber = numbers[4]; // Index out of range exception.

List<int> emptyCollection = new List<int>();
int firstElement = GetFirstElement(emptyCollection);
int firstElementUsingLINQ = emptyCollection.First(); // This throws an 'InvalidOperationException' on the other hand.

string passport = "Czech";
bool passportValid = ValidatePassport(passport);

Console.ReadKey();

bool ValidatePassport(string passport)
{
    throw new NotImplementedException(); // Use this to make it compile, but shows it's still WIP.
}

int GetFirstElement(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        return number;
    }

    throw new InvalidOperationException("The collection cannot be empty.");
    // This is okay because it's not this method's responsibility to figure out what to do with the invalid input.
    // We throw an exception here because we can't handle the input in a reasonable way, and an invalid input is whoever's implementing the method's mistake.
}

bool IsFirstElementPositive(IEnumerable<int> numbers)
{
    try
    {
        int firstElement = GetFirstElement(numbers);
        return firstElement > 0;
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("The collection is empty!");
        return true;
    }
    catch (NullReferenceException ex)
    {
        throw new NullReferenceException("The collection is null.", ex); // We're not expecting nulls here, so this is fine.
    }
}

class Person
{
    public string Name { get; }
    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        if (name is null)
        {
            throw new ArgumentNullException("Name cannot be null.");
        }
        if (name == string.Empty)
        {
            throw new ArgumentException("Invalid name. Must not be empty.");
        }
        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException("Invalid year. Must be below current year & above 1900");
        }
        Name = name;
        YearOfBirth = yearOfBirth;
    }
}