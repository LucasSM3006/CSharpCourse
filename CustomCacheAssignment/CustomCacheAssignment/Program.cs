SlowDataDownloader dataDownloader = new SlowDataDownloader();

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

public interface IDataDownloader
{
    public string DownloadData(string id);
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string id)
    {
        if(CachedData.FindById(id) is not null)
        {
            return $"some data for {id}";
        }

        // Slow data grabbing and downloading
        Thread.Sleep(1000);
        return $"some data for {id}";
    }
}

public class Cache<TKey, TData>
{
    private Dictionary<TKey, TData> _cachedData = new Dictionary<TKey, TData>();
    private IDataDownloader _dataDownloader;

    public Cache(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    private void StoreData<TData>(TData data)
    {

    }

    private TData Get(TKey key)
    {
        if (!_cachedData.ContainsKey(key))
        {
            _cachedData[key] = _dataDownloader.DownloadData(key);
        }

        return _cachedData[key];
    }
}

public interface IDataRepository<TKey, TData>
{
    public void Save(TKey key, TData data);
    public KeyValuePair<TKey, TData> GetById(TKey key);
}

public class DataRepository<TKey, TData> : IDataRepository<TKey, TData>
{
    private Dictionary<TKey, TData> data = new Dictionary<TKey, TData> ();

    public DataRepository()
    {
        data.Add(new KeyValuePair<TKey, TData>(TKey, TData));
    }

    public KeyValuePair<TKey, TData> GetById(TKey key)
    {
        throw new NotImplementedException();
    }

    public void Save(TKey key, TData data)
    {
        throw new NotImplementedException();
    }
}