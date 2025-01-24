// Important notice: Object initializers need the setters to work.
// This isn't good because you can manipulate it at any point with no validations.
// So we have the 'init' keyword. The version w/ the init keyword will be in the latest commit.

//Person person = new Person("John Doe", 2001);
Person person = new Person("John Doe")
{
    Name = "Jane Doe", // Jane doe will be the name used. Constructor is called first, and then the Object initializer does its job, overwriting Name.
    YearOfBirth = 2001
};

Console.ReadKey();

class Person
{
    public string Name { get; set; }
    public int YearOfBirth { get; set; }

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