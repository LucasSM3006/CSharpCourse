namespace FilesNamespacesDirectivesAndFileScopedNamespaceDeclarations
{
    public class NamesFormatter
    {
        // Format is a different method to that of "Write" from FileRepo because Format's implementation is for the Console.WriteLine() method. "Write" will put things into a text file.
        public string Format(List<string> names) =>
        string.Join(Environment.NewLine, names);
    }
}