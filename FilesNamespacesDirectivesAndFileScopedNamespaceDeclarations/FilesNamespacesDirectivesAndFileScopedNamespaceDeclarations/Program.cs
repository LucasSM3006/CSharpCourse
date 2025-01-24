var names = new Names();
var path = new NamesFilePath().BuildFilePath();
var stringsFromTextRepo = new FileRepository();
var namesFormatter = new NamesFormatter();

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
Console.WriteLine(namesFormatter.Format(names.All));

Console.ReadLine();

public class NamesFilePath
{
    public string BuildFilePath()
    {
        return "name.txt";
    }
}