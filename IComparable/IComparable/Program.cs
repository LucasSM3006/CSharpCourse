
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

Person joel = new Person { Name = "Joel Sweden", YearOfBirth = 1995 };
Person kazuma = new Person { Name = "Kazuma Kiryu", YearOfBirth = 1988 };

PrintInOrder(1, 2);
PrintInOrder("aaa", "bbb");
PrintInOrder("zzz", "ccc");
PrintInOrder(10, 6);
PrintInOrder(joel, kazuma); // We can now do this since the class implements the CompareTo method.

Console.ReadKey();

void PrintInOrder<T>(T first, T second) where T: IComparable<T> // We're gonna make it so this only accepts types which implement the IComparable interface.
{
    if(first.CompareTo(second) > 0)
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

    public override string ToString()
    {
        return $"{Name}, born in {YearOfBirth}.";
    }

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