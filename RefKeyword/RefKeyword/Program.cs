int number = 5;

AddOneToNumber(ref number);

Console.WriteLine($"Number is: {number}");

MethodWithOutParameter(out int otherNumber);

Console.WriteLine($"Number is: {otherNumber}");

Console.ReadKey();

// Declare that the out parameter will be set inside the method
// Needs to assign a value to the parameter or it won't compile, even if it was initialized
// Argument doesn't need to have been initialized. (TryParse is an example of it.)
void MethodWithOutParameter(out int number)
{
    number = 10;
}

 // Pass the argument by reference
 // Parameter doesn't need to have a value assigned to it
 // Argument needs to have been initialized before being passed
void AddOneToNumber(ref int number)
{
    ++number;
}