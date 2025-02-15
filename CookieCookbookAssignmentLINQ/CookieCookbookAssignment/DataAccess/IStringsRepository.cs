namespace CookieCookbookAssignment.DataAccess;

public interface IStringsRepository
{
    List<string> Read(string filename);
    void Write(string filePath, List<string> strings);
}
