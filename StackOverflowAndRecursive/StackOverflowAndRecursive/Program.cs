// RecursiveMethod(); // It'll take a bit but it will eventually throw an error.

void RecursiveMethod()
{
    Console.WriteLine("Calling myself.");
    RecursiveMethod();
}