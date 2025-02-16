int number1 = 5;
int number2 = number1;
number2++;

Console.WriteLine($"Number1 is: {number1}"); // Value here is still 5.
Console.WriteLine($"Number2 is: {number2}"); // Value here is still 6.

// The reason for above is that we passed the values, not the reference. Which means that it takes the value of it, instead of manipulating the original value.
// We expect the value and the reference to be separate from each other. Value semantics guarantees that the values stored are independent.


// This, on the other hand, is different because we've passed an object as it. We didn't pass a copy of the object, we more so told the variable person to point towards the same space as "john" does.

var john = new Person { Name = "john", Age = 34 };
var person = john;
person.Age = 35;

Console.WriteLine($"Person1's name: {john.Name}, Age: {john.Age}");    // They are now the same object. The value here is 35.
Console.WriteLine($"Person2's name: {person.Name}, Age: {person.Age}"); // Age is 35.

// Watch this:

Console.WriteLine($"Are Person1 and Person2 the same object? {john.Equals(person)}");
Console.WriteLine("Objects:");
Console.WriteLine(john.GetHashCode());
Console.WriteLine(person.GetHashCode());

Console.ReadKey();

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}