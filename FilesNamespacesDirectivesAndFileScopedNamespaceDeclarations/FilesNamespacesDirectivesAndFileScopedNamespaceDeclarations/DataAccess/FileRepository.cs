namespace FilesNamespacesDirectivesAndFileScopedNamespaceDeclarations.DataAccess;

public class FileRepository
{
    private readonly string Separator = Environment.NewLine; // Cannot be a constant because the symbol for a new line is different depending on the system. Aka, not made in compile time, but in runtime.
    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(Separator).ToList();
    }

    public void Write(string path, List<string> strings) =>
        File.WriteAllText(path, string.Join(Separator, strings));
}