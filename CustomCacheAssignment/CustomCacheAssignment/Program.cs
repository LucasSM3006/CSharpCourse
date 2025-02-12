SlowDataDownloader dataDownloader = new SlowDataDownloader();

Console.WriteLine(dataDownloader.Download("id1"));
Console.WriteLine(dataDownloader.Download("id2"));
Console.WriteLine(dataDownloader.Download("id3"));
Console.WriteLine(dataDownloader.Download("id1"));
Console.WriteLine(dataDownloader.Download("id3"));
Console.WriteLine(dataDownloader.Download("id1"));
Console.WriteLine(dataDownloader.Download("id2"));

public interface IDataDownloader
{
    public string Download(string id);
}

public class SlowDataDownloader : IDataDownloader
{
    public string Download(string id)
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
    private Dictionary<TKey, TData> cachedData = new Dictionary<TKey, TData>();

    private void StoreData<TData>(TData data)
    {

    }

    private TData Get(TKey key)
    {
        if (!cachedData.ContainsKey(key))
        {
            cachedData.Add(key, dataRepository.GetDataById(key));
        }

        return cachedData[key];
    }
}

public interface IDataRepository<TKey, TData>
{
    public void Save(TKey key, TData data);
    public KeyValuePair<TKey, TData> GetById(TKey key);
}

public class DataRepository<TKey, TData> : IDataRepository<TKey, TData>
{
    public KeyValuePair<TKey, TData> GetById(TKey key)
    {
        throw new NotImplementedException();
    }

    public void Save(TKey key, TData data)
    {
        throw new NotImplementedException();
    }
}