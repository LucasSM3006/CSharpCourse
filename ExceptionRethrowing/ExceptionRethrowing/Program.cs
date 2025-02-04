try {
    IsFirstElementPositive(null);
}
catch (NullReferenceException ex)
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
        throw; // Preserves the stack trace, will point to the method that caused the exception in the first place.
        // throw ex; // Doesn't preserve the stack trace, we'll lose information about the first place that threw an exception.
        // throw new NullReferenceException("The collection is null.", ex); // We're not expecting nulls here, so this is fine.
    }
}