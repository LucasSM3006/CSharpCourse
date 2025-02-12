

Console.WriteLine();

public interface IDataDownloader
{
    public string Download(string id);
}

public class SlowDataDownloader : IDataDownloader
{
    public string Download(string id)
    {
        throw new NotImplementedException();
    }
}