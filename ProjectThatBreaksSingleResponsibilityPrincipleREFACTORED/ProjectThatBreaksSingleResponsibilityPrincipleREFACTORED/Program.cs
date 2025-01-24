var names = new Names();
var path = names.BuildFilePath();
var stringsFromTextRepo = new FileRepository();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    var stringsFromFile = stringsFromTextRepo.Read(path);
    names.AddNames(stringsFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    //let's imagine they are given by the user
    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    stringsFromTextRepo.Write(path, names.All);
}
Console.WriteLine(names.Format());

Console.ReadLine();

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

    public string BuildFilePath()
    {
        return "name.txt";
    }

    public string Format() =>
        string.Join(Environment.NewLine, All);
}

public class NamesValidator
{
    public bool IsValid(string name)
    {
        return
            name.Length >= 2 &&
            name.Length < 25 &&
            char.IsUpper(name[0]) &&
            name.All(char.IsLetter);
    }
}

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