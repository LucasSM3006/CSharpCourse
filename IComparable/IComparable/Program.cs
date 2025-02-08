
List<Person> people = new List<Person> { 
    new Person { Name = "Jane", YearOfBirth = 1999 },
    new Person { Name = "John", YearOfBirth = 2001 },
    new Person { Name = "Joanne", YearOfBirth = 2000 }
};

foreach (Person person in people)
{
    Console.WriteLine(person.Name);
}

people.Sort(); // Throws an exception. Only works if the list implements the IComparable interface. (No longer throws an exception due to now having an implementation of CompareTo() from the interface.)

foreach (Person person in people)
{
    Console.WriteLine(person.Name);
}

PrintInOrder(1, 2);
PrintInOrder(2, 5);
PrintInOrder(10, 6);

Console.ReadKey();

void PrintInOrder(int first, int second)
{
    if(first > second)
    {
        Console.WriteLine($"{second} {first}");
    }
    else
    {
        Console.WriteLine($"{first} {second}");
    }
}

public class Person : IComparable<Person>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }

    public int CompareTo(Person other)
    {
        if(YearOfBirth < other.YearOfBirth)
        {
            return 1;
        }
        else if (YearOfBirth > other.YearOfBirth)
        {
            return -1;
        }
        return 0;
    }
}