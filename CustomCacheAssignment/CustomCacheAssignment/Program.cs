IDataDownloader dataDownloader = new SlowDataDownloader(); // Now if we don't need caching all we need to do is assign this to the SlowDataDownloader
// IDataDownloader dataDownloader = new CachingDataDownloader(new SlowDataDownloader()); // This will do caching, however.

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();


// Decorator design pattern is implemented here. 
// A class that follows it both implements the interface as the decorated type and it owns an instance implementing this interface.
// Example below.
public class CachingDataDownloader : IDataDownloader // This class only cares about the caching, not the downloading
{
    private readonly IDataDownloader _dataDownloader; // CachingDataDownloader won't do the downloading itself, this other thing will. What it will do is caching this data.
    private readonly Cache<string, string> _cache = new();

    public CachingDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string id)
    {
        return _cache.Get(id, _dataDownloader.DownloadData); // Now sends the method that _dataDownloader holds.
    }
}
public interface IDataDownloader
{
    public string DownloadData(string id);
}

public class SlowDataDownloader : IDataDownloader // This class is fully dedicated to downloading data
{

    private readonly Cache<string, string> _cache = new();

    public string DownloadData(string id)
    {
        // Slow data grabbing and downloading

        Thread.Sleep(1000);
        return $"some data for {id}";
    }
}

public class Cache<TKey, TData>
{
    private Dictionary<TKey, TData> _cachedData = new Dictionary<TKey, TData>();

    public TData Get(TKey key, Func<TKey, TData> getForTheFirstTime) // key identifies some data, getFor... uses the key to retrieve data. How it does that is decided by the Func method.
    {
        if (!_cachedData.ContainsKey(key))
        {
            _cachedData[key] = getForTheFirstTime(key);
        }

        return _cachedData[key];
    }
}