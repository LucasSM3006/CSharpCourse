try {
    IsFirstElementPositive(null);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadKey();

int GetFirstElement(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        return number;
    }

    throw new InvalidOperationException("The collection cannot be empty.");
    // This is okay because it's not this method's responsibility to figure out what to do with the invalid input.
    // We throw an exception here because we can't handle the input in a reasonable way, and an invalid input is whoever's implementing the method's mistake.
}

bool IsFirstElementPositive(IEnumerable<int> numbers)
{
    try
    {
        int firstElement = GetFirstElement(numbers);
        return firstElement > 0;
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("The collection is empty!");
        return true;
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine("Sorry, the app experienced an unexpected error!");
        // throw; // Preserves the stack trace, will point to the method that caused the exception in the first place.
        // throw ex; // Doesn't preserve the stack trace, we'll lose information about the first place that threw an exception.
        throw new ArgumentNullException("The collection is null.", ex); // Preserves the stack trace.
    }
}

public class PersonDataReader
{
    private readonly IPeopleRepository _peopleRepository;
    private readonly ILogger _logger;

    public PersonDataReader(
        IPeopleRepository repository,
        ILogger logger)
    {
        _peopleRepository = repository;
        _logger = logger;
    }

    public Person ReadPersonData(int personId)
    {
        try
        {
            return _peopleRepository.Read(personId);
        }
        catch (Exception ex)
        {
            // We merely rethrow it because we're not looking to handle it, only log it so that someone may take care of it.
            _logger.Log(ex);
            throw;
        }
    }
}

public interface IPeopleRepository
{
    public Person Read(int id);
}

public class PeopleRepository : IPeopleRepository
{
    public Person Read(int id)
    {
        throw new NotImplementedException();
    }
}

public interface ILogger
{
    public void Log(Exception exception);
}

public class LoggingTxt : ILogger
{
    public void Log(Exception message)
    {
        throw new NotImplementedException();
    }
}

public class Person()
{

}