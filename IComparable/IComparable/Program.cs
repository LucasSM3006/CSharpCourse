
List<Person> people = new List<Person> { 
    new Person { Name = "Jane", YearOfBirth = 1999 },
    new Person { Name = "John", YearOfBirth = 2001 },
    new Person { Name = "Joanne", YearOfBirth = 2000 }
};

foreach (Person person in people)
{
    Console.WriteLine(person.Name);
}

people.Sort(); // Throws an exception. Only works if the list implements the IComparable interface.

foreach (Person person in people)
{
    Console.WriteLine(person.Name);
}

public class Person
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }
}