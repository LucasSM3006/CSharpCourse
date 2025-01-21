/*
 * Arrays (2) - IsWordPresentInCollection

Implement the IsWordPresentInCollection method, which given an array of words and a wordToBeChecked, returns true if wordToBeChecked is present in this collection and false otherwise.

For example:

    For words equal to {"one", "two", "three"} and wordToBeChecked equal to "hello" the result shall be false because the word "hello" is not present in the words array.

    For words equal to {"one", "two", "three"} and wordToBeChecked equal to "two" the result shall be true because the word "two" is present in the words array.
 * 
 */

using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static bool IsWordPresentInCollection(string[] words, string wordToBeChecked)
        {
            foreach (string word in words)
            {
                if (word.Equals(wordToBeChecked)) return true;
            }
            return false;
        }
    }
}
