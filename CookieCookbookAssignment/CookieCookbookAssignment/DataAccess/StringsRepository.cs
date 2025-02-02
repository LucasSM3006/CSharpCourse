namespace CookieCookbookAssignment.DataAccess;

public abstract class StringsRepository : IStringsRepository
{
    public List<string> Read(string filename)
    {
        if (File.Exists(filename))
        {
            var fileContents = File.ReadAllText(filename);
            return TextToStrings(fileContents);
        }
        return new List<string>();
    }

    protected abstract List<string> TextToStrings(string fileContents);

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, StringsToText(strings));
    }

    protected abstract string StringsToText(List<string> strings);
}
