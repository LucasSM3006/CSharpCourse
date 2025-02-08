using System.Diagnostics;
using System.Threading.Channels;

Stopwatch sw = Stopwatch.StartNew();

var list = CreateCollectionOfRandomLength<int>(100);

sw.Stop();
Console.WriteLine($"number of miliseconds: {sw.ElapsedMilliseconds}");

var people = new List<Person>
{ new Person { Name = "dfaaf", YearOfBirth = 1999 },
  new Person { Name = "fafa", YearOfBirth = 2002 },
  new Person { Name = "fafa22", YearOfBirth = 2000 }
};

var employees = new List<Employee>
{ new Employee { Name = "daf", YearOfBirth = 1999 },
  new Employee { Name = "aa", YearOfBirth = 20224 },
  new Employee { Name = "fa22", YearOfBirth = 2029 }
};

var validPeople = GetOnlyValid(people);
var validEmployee = GetOnlyValid(employees);

foreach (var employee in validEmployee)
{
    employee.GoToWork();
}

Console.ReadKey();

IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength) where T : new() // Gaurantees there's an empty constructor that takes no parameters.
{
    int length = new Random().Next(maxLength + 1); // 10000000;

    List<T> collection = new List<T>(length); // Sets list size.

    for(int i = 0; i < length; i++)
    {
        collection.Add(new T()); // Unsure whether it'll even have a cosntructor or not. If you have 'public class xy' w/ a constructor that takes two values, well, this wouldn't work for that.
    }

    return collection;
}

IEnumerable<TPerson> GetOnlyValid<TPerson>(IEnumerable<TPerson> people) where TPerson : Person // Again using 'where'. This forces it to only accept classes that derive from Person
{
    var result = new List<TPerson>();

    foreach(TPerson person in people)
    {
        if(person.YearOfBirth > 1900 && person.YearOfBirth < DateTime.Now.Year)
        {
            result.Add(person); 
        }
    }

    return result;
}


public class Person
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }
}

public class Employee : Person
{
    public void GoToWork() => Console.WriteLine("I have to go to work!");
}