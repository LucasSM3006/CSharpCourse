const string filePath = "E:\\Downloads\\";
const string fileName = "sampleData.csv";

var data = new CsvReader().Read(filePath + fileName);

Console.ReadKey();

public class CsvReader
{
    private const string Separator = ",";
    public CsvData Read(string path)
    {
        using var streamReader = new StreamReader(path);

        var columns = streamReader.ReadLine().Split(Separator);

        var rows = new List<string[]>();

        while (!streamReader.EndOfStream)
        {
            var cellsInRow = streamReader.ReadLine().Split(Separator);
            rows.Add(cellsInRow);
        }

        return new CsvData(columns, rows);
    }
}

public class CsvData
{
    public string[] Columns { get; }
    public IEnumerable<string[]> Rows { get; }

    public CsvData(string[] columns, IEnumerable<string[]> rows)
    {
        Columns = columns;
        Rows = rows;
    }
}