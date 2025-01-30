using System.Text.Json;

Person person = new Person
{
    firstName = "John",
    lastName = "Doe",
    yearOfBirth = 1999
};

var asJson = JsonSerializer.Serialize(person);

Console.WriteLine("As JSON: ");
Console.WriteLine(asJson);

var personJson = "{\"firstName\":\"John\",\"lastName\":\"Doe\",\"yearOfBirth\":1999}";

Person personFromJson = JsonSerializer.Deserialize<Person>(personJson);

Console.WriteLine(personFromJson.firstName + " " + personFromJson.lastName + " " + personFromJson.yearOfBirth);

Console.ReadKey();

public class Person
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int yearOfBirth { get; set; }
}