namespace CsvDataAccess.NewSolution;

public class FastRow
{
    private Dictionary<string, bool> _boolsData = new();
    private Dictionary<string, int> _intsData = new();
    private Dictionary<string, decimal> _decsData = new();
    private Dictionary<string, string> _stringsData = new();

    public void AssignBool(string columnName, bool value)
    {
        _boolsData[columnName] = value;
    }

    public void AssignInts(string columnName, int value)
    {
        _intsData[columnName] = value;
    }

    public void AssignDecimals(string columnName, decimal value)
    {
        _decsData[columnName] = value;
    }

    public void AssignStrings(string columnName, string value)
    {
        _stringsData[columnName] = value;
    }

    public object GetAtColumn(string columnName)
    {
        if(_boolsData.ContainsKey(columnName)) return _boolsData[columnName];
        if(_intsData.ContainsKey(columnName)) return _intsData[columnName];
        if(_decsData.ContainsKey(columnName)) return _decsData[columnName];
        if(_stringsData.ContainsKey(columnName)) return _stringsData[columnName];
        return null;
    }
}
