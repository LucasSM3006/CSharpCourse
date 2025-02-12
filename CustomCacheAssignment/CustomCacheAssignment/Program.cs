SlowDataDownloader dataDownloader = new SlowDataDownloader();

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();

public interface IDataDownloader
{
    public string DownloadData(string id);
}

public class SlowDataDownloader : IDataDownloader
{

    private readonly Cache<string, string> _cache = new();

    public string DownloadData(string id)
    {
        return _cache.Get(id, DownloadDataWithoutCaching);
    }

    private string DownloadDataWithoutCaching(string id)
    {
        // Slow data grabbing and downloading

        Thread.Sleep(1000);
        return $"some data for {id}";
    }
}

public class Cache<TKey, TData>
{
    private Dictionary<TKey, TData> _cachedData = new Dictionary<TKey, TData>();

    private void StoreData<TData>(TData data)
    {

    }

    public TData Get(TKey key, Func<TKey, TData> getForTheFirstTime) // key identifies some data, getFor... uses the key to retrieve data.
    {
        if (!_cachedData.ContainsKey(key))
        {
            _cachedData[key] = getForTheFirstTime(key);
        }

        return _cachedData[key];
    }
}