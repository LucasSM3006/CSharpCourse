/*
 * Create an extension method for the List<int> type called TakeEverySecond.


This method should return a new List of ints with every second element from the input list.

For example:

    for input  { 1, 5, 10, 8, 12, 4, 5 }, the result shall be { 1, 10, 12, 5 }

    for input  { 1, 5, 10, 8, 12, 4, 5, 6 }, the result shall be { 1, 10, 12, 5 }

    for input  { 1 } , the result shall be { 1 }

    for empty input, the result shall be empty

    don't handle the null input in any way (let it throw an exception)

It must be possible to call this method like this:

var list = new List<int> { 1, 5, 10, 8, 12, 4, 5};
var result = list.TakeEverySecond();
 */

var list = new List<int> { 1, 5, 10, 8, 12, 4, 5 };
var result = list.TakeEverySecond();

foreach (var item in result)
{
    Console.WriteLine(item);
}

Console.ReadKey();

public static class ListExtensions
{
    public static List<int> TakeEverySecond(this List<int> input)
    {
        List<int> newList = new List<int>();
        int count = 2;

        foreach (int i in input)
        {
            if(count % 2 == 0)
            {
                newList.Add(i);
            }
            count++;
        }

        return newList;
    }
}
