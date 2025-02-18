const string filePath = "file.txt";

// This will basically work like a try/finally. Syntactic sugar as they call it. If an exception is thrown, it'll still dispose of it. 
using (var writer = new FileWriter(filePath))
{
writer.Write("Testing this with a fairly larger string that is full of words");
writer.Write("This should be in the second line of the text file due to the environment.newline we set earlier");
}
// writer.Dispose(); // We dispose of it once we're done using it, otherwise an exception is thrown due to the resource still being "open" by the writer.

// Had to move the creation of the reader here, otherwise it wouldn't work.
// This is also a valid use of "using". Dispose at the end of the scope of the variable... Not sure exactly where.
using var reader = new SpecificLineFromTextFileReader(filePath);
Console.WriteLine(reader.ReadLineNumber(1));
Console.WriteLine(reader.ReadLineNumber(2));
Console.WriteLine(reader.ReadLineNumber(3));
Console.WriteLine(reader.ReadLineNumber(4));
Console.WriteLine(reader.ReadLineNumber(5));
// reader.Dispose();

Console.WriteLine("Press any key to close.");
Console.ReadKey();

public class FileWriter : IDisposable
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

    public void Dispose()
    {
        _writer.Dispose();
    }
}

public class SpecificLineFromTextFileReader : IDisposable
{
    private readonly StreamReader _reader;
    public SpecificLineFromTextFileReader(string filePath)
    {
        _reader = new StreamReader(filePath);
    }

    public string ReadLineNumber(int lineNumber)
    {
        // These aren't parametarized, it remembers where it was... Which means we need to run ReadLine() five times to fetch what's in the 5th line.
        // var first = _reader.ReadLine();
        // var second = _reader.ReadLine();
        // var third = _reader.ReadLine();

        _reader.DiscardBufferedData(); // Empties the buffer of it.
        _reader.BaseStream.Seek(0, SeekOrigin.Begin); // Moves the reader to the beginning of the file.

        for (int i = 0; i < lineNumber - 1; i++)
        {
            _reader.ReadLine();
        }

        return _reader.ReadLine();
    }

    public void Dispose()
    {
        _reader.Dispose();
    }
}