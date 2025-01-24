namespace FilesNamespacesDirectivesAndFileScopedNamespaceDeclarations;

public class Names
{
    public List<string> All { get; } = new List<string>();

    private NamesValidator _validator = new NamesValidator();

    public void AddNames(List<string> names)
    {
        foreach (var name in names)
        {
            AddName(name);
        }
    }

    public void AddName(string name)
    {
        if (_validator.IsValid(name))
        {
            All.Add(name);
        }
    }
}