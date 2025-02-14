﻿/*
 * OrderBy, First & Last

Implement the FindShortestWord method, which finds the shortest words in a collection of strings. If more than one word has the same minimal length, the first one on order should be returned.

For example:

    For words {"aaa", "b", "c", "dd"}, the result shall be "b" because it is the shortest (only 1 letter) and is before another word with the same length ("c")

    For an empty collection, an exception should be thrown
 */

List<string> strings = new List<string>
{
    "aaa", "b", "c", "dd"
};

string shortes = Exercise.FindShortestWord(strings);

Console.WriteLine(shortes);

Console.ReadKey();

public class Exercise
{
    public static string FindShortestWord(List<string> words)
    {
        return words.OrderBy(word => word.Length).First();
    }
}