/*
 * Count & Contains

Implement the CountListsContainingZeroLongerThan method. It takes the following parameters:

    length of type int

    listsOfNumbers of type List of Lists of ints

This method should return the count of the lists that meet the following conditions:

    Contain the number zero

    Are longer than length

For example, for length 3 and the following lists contained in the listsOfNumbers:

    {1, 2, 5, -1}

    {0, 4, 4, 6}

    {9, 0}

The result shall be 1 because there is only one list that contains zero, and has more than 3 items.
 * 
 */

List<List<int>> listOfListsOfNumbers = new List<List<int>>
{
    new List<int> { 1, 2, -5, -1 },
    new List<int> { 0, 4, 4, 6},
    new List<int> { 9, 0}
};

int lol = Exercise.CountListsContainingZeroLongerThan(3,listOfListsOfNumbers);

Console.ReadKey();

public class Exercise
{
    public static int CountListsContainingZeroLongerThan(
         int length,
         List<List<int>> listsOfNumbers)
    {
        return listsOfNumbers.Count(list => list.Contains(0) && list.Count > length);
    }
}