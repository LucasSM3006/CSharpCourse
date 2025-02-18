const string filePath = "file.txt";
var writer = new FileWriter(filePath);

writer.Write("Testing this with a fairly larger string that is full of words");
writer.Write("This should be in the second line of the text file due to the environment.newline we set earlier");

Console.WriteLine("Press any key to close.");
Console.ReadKey();

public class FileWriter
{
    // Streamwriter works in a buffer, so it stores everything until we run "Flush" on it.
    private readonly StreamWriter _writer;
    public FileWriter(string filePath)
    {
        _writer = new StreamWriter(filePath, true); // "true" is to append it.
    }

    public void Write(string text)
    {
        _writer.WriteLine(text);
        // The flush method in question:
        _writer.Flush();
    }
}