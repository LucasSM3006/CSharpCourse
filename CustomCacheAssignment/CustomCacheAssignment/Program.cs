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