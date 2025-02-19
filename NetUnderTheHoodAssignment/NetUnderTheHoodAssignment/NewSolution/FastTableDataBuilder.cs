using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            var newRow = new FastRow();

            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];

                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if (valueAsString == "TRUE")
                {
                    newRow.AssignBool(column, true);
                }
                else if (valueAsString == "FALSE")
                {
                    newRow.AssignBool(column, false);
                }
                else if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    newRow.AssignDecimals(column, valueAsDecimal);
                }
                else if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    newRow.AssignInts(column, valueAsInt);
                }
                else
                {
                    newRow.AssignStrings(column, valueAsString);
                }
            }

            resultRows.Add(newRow);
        }

        return new FastTableData(csvData.Columns, resultRows);
    }
}
