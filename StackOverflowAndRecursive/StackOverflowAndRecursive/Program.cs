RecursiveMethod(1); // It'll take a bit but it will eventually throw an error.

Console.ReadKey();

void RecursiveMethod(int counter)
{
    Console.WriteLine($"Calling myself. Counter value: {counter}");
    if ( counter < 10 ) // Have some way to stop it, otherwise you'll be toast.
    {
        RecursiveMethod(++counter); // Cannot be 'counter++'. It won't work.
    }
}