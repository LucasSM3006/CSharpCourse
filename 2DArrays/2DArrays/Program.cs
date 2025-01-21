char[,] letters = new char[2, 3];

letters[0, 0] = 'a';
letters[0, 1] = 'b';
letters[0, 2] = 'c';
letters[1, 0] = 'd';
letters[1, 1] = 'e';
letters[1, 2] = 'f';

var letters2 = new char[,]
{
    { 'A', 'B', 'C' },
    { 'D', 'E', 'F' },
};

int rows = letters.GetLength(0);
int columns = letters.GetLength(1);

Console.WriteLine($"N of rows: {rows}");
Console.WriteLine($"N of columns: {columns}");

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.WriteLine(letters[i, j]);
    }
}

Console.ReadKey();