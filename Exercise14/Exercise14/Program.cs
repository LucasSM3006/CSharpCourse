/*
 * Lists - GetOnlyUpperCaseWords

Implement the GetOnlyUpperCaseWords method, which given a collection of strings, returns a List with only those strings which contain only uppercase letters.

The result collection should not contain duplicates.


For example:

    for input List {"one", "TWO", "THREE", "four"} the result shall be {"TWO", "THREE"}

    for input List {"one", "TWO", "THREE", "four", "TWO"} the result shall be {"TWO", "THREE"} (the second "TWO" is ignored)

    for input List {"one", "TWO123", "THREE!&^", "four"} the result shall be an empty List because no word in this collection is built from only uppercase letters (digits and special characters are not letters at all).
 */

using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public List<string> GetOnlyUpperCaseWords(List<string> words)
        {
            bool isUpper = false;
            List<string> upperCaseWords = new List<string>();

            foreach (string word in words)
            {
                if (upperCaseWords.Contains(word)) continue;
                if (isUpperCase(word)) upperCaseWords.Add(word);
            }

            return upperCaseWords;
        }

        public bool isUpperCase(string word)
        {
            for (int i = 0; i < word.Length; ++i)
            {
                if (char.IsUpper(word[i]))
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}
