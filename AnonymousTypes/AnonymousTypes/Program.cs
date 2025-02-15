var listsOfNumbers = new List<List<int>>
{
    new List<int> { 15, 68, 20, 12, 19, 8, 55 },
    new List<int> { 12, 1, 3, 4, -19, 8, 7, 6 },
    new List<int> { 5, -6, -2, -12, -10, 7 }
};

var result = listsOfNumbers.Select(listOfNumber => new CountAndAverage
{
    Count = listOfNumber.Count,
    Average = listOfNumber.Average()
})
    .OrderByDescending(countAndAverage => countAndAverage.Count)
    .Select(c => $"Count is: {c.Count}, Average is: {c.Average}");

foreach(var r in result)
{
    Console.WriteLine(r);
}

Console.ReadKey();

public class CountAndAverage
{
    public int Count { get; set; }
    public double Average { get; set; }
}