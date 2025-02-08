
Console.ReadKey();

IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength) where T : new() // Gaurantees there's an empty constructor that takes no parameters.
{
    int length = new Random().Next(maxLength + 1);

    List<T> collection = new List<T>();

    for(int i = 0; i < length; i++)
    {
        collection.Add(new T()); // Unsure whether it'll even have a cosntructor or not. If you have 'public class xy' w/ a constructor that takes two values, well, this wouldn't work for that.
    }

    return collection;
}