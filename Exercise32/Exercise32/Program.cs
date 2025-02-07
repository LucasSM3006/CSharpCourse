/*
 * Generic methods - SwapTupleItems method

Implement the static SwapTupleItems method. Its purpose is to take a Tuple of two items as a parameter and, as a result, return a tuple in which those items are swapped.

For example:

    for an input equal to Tuple<int, string>(1, "hello"), the result should be Tuple<string, int>("hello", 1)

    for an input equal to Tuple<int, int>(1, 2), the result should be Tuple<int, int>(2, 1)
 * 
 */

Tuple<int, int> unswappedIntTuple = new Tuple<int, int>(1, 2);
Tuple<int, int> swappedIntTuple = TupleSwapExercise.SwapTupleItems(unswappedIntTuple);

Tuple<string, string> unswappedStringTuple = new Tuple<string, string>("TestStringNumberONE", "TestStringNumberTWO");
Tuple<string, string> swappedStringTuple = TupleSwapExercise.SwapTupleItems(unswappedStringTuple);

Console.WriteLine(unswappedIntTuple.Item1);
Console.WriteLine(unswappedIntTuple.Item2);
Console.WriteLine(swappedIntTuple.Item1);
Console.WriteLine(swappedIntTuple.Item2);

Console.WriteLine(unswappedStringTuple.Item1);
Console.WriteLine(unswappedStringTuple.Item2);
Console.WriteLine(swappedStringTuple.Item1);
Console.WriteLine(swappedStringTuple.Item2);

Console.ReadKey();


public static class TupleSwapExercise
{
    public static Tuple<T2, T1> SwapTupleItems<T1, T2>(Tuple<T1, T2> tupleToSwap)
    {
        return new Tuple<T2, T1>(tupleToSwap.Item2, tupleToSwap.Item1);
    }
}