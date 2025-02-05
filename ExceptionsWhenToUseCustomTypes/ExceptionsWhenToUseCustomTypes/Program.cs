try
{
    ComplexMethod();
}
catch (InvalidOperationException ex) when (ex.Message == "Cannot connect to a service")
{
    Console.WriteLine("Check your internet connection");
    throw;
}
Console.ReadKey();

void ComplexMethod()
{
    // step 1: connecting
    throw new InvalidOperationException("Cannot connect to a service");

    // step 2: authorizing
    throw new InvalidOperationException("Couldn't authorize user");

    // step 3: retrieving data as JSON
    throw new InvalidOperationException("Cannot retrieve data");

    // step 4: parsing JSON to some C# type
    throw new InvalidOperationException("Could not parse correctly");
}