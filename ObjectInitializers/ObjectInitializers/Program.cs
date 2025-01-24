// Important notice: Object initializers need the setters to work.
// This isn't good because you can manipulate it at any point with no validations.
// So we have the 'init' keyword. The version w/ the init keyword will be in the latest commit.

//Person person = new Person("John Doe", 2001);

// The nice part about initializers is that you can start an empty object, you can just run "Person person = new Person;"
// Their use case could come about in building DTOs for DB operations, for example, where you've got multiple kinds of information and having a really big constructor could be cumbersome and harder to follow than what looks like JSON.
Person person = new Person("John Doe")
{
    Name = "Jane Doe", // Jane doe will be the name used. Constructor is called first, and then the Object initializer does its job, overwriting Name.
    YearOfBirth = 2001
};

//person.YearOfBirth = 2000; // This causes a compilation error because the init keyword acts like a setter during the initialization, and afterwards, it acts as if it never even had a setter method.

Console.ReadKey();

class Person
{
    public string Name { get; set; }
    public int YearOfBirth { get; init; }

    public Person(string name)
    {
        Name = name;
    }

    //public Person(string name, int yearOfBirth)
    //{
    //    Name = name;
    //    YearOfBirth = yearOfBirth;
    //}
}