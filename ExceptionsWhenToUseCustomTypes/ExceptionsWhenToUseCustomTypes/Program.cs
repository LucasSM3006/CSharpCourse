using System.Runtime.Serialization;

try
{
    ComplexMethod();
}
catch (ConnectionException ex)
{
    Console.WriteLine("Check your internet connection");
    throw;
}
catch (JsonParsingException ex)
{
    Console.WriteLine($"Unable to parse JSON. Json body is: {ex.JsonBody}");
    throw;
}

Console.ReadKey();

void ComplexMethod()
{
    // step 1: connecting
    throw new ConnectionException("Cannot connect to a service");

    // step 2: authorizing
    throw new AuthorizationException("Couldn't authorize user");

    // step 3: retrieving data as JSON
    throw new DataAccessException("Cannot retrieve data");

    // step 4: parsing JSON to some C# type
    throw new JsonParsingException("Could not parse correctly");
}


internal class JsonParsingException : Exception
{
    public string JsonBody { get; }
    public JsonParsingException()
    {
    }

    public JsonParsingException(string? message) : base(message)
    {
    }
    
    public JsonParsingException(string? message, string jsonBody) : base(message)
    {
        JsonBody = jsonBody;
    }

    public JsonParsingException(string? message, Exception? innerException, string jsonBody) : base(message, innerException)
    {
        JsonBody = jsonBody;
    }
}

internal class DataAccessException : Exception
{
    public DataAccessException()
    {
    }

    public DataAccessException(string? message) : base(message)
    {
    }

    public DataAccessException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

internal class AuthorizationException : Exception
{
    public AuthorizationException()
    {
    }

    public AuthorizationException(string? message) : base(message)
    {
    }

    public AuthorizationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

internal class ConnectionException : Exception
{
    public ConnectionException()
    {
    }

    public ConnectionException(string? message) : base(message)
    {
    }

    public ConnectionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}