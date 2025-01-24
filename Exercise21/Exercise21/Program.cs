/*
 * string.Split and string.Join methods

Introduction:

In the next lecture, we will see string.Split and string.Join methods in action. It will be easier to understand them if we first write some code that uses them.


string.Split takes a string and a separator as parameters. It splits the string into pieces by the separator. The separator can either be a string or a char.

                    string inputString = "this,is,some,string";
                    char separator = ',';

                    string[] result = inputString.Split(separator);

For example, for the string "this,is,some,string" and separator ',', it will return a 4-element array with "this" "is" "some" "string" strings inside.

string.Join does the opposite: it takes a collection of strings and joins them with a given separator. Please notice that this method is a static method in the string class. The separator can be a char or a string.

                    string result = string.Join(
                        "--", new[] { "one", "two", "three"});

In this case, the result will be the following string:

"one--two--three"

Exercise:

Implement the TransformSeparators method. Its purpose is to take a string with some separators and replace them with the target separators.


For example, for:

    input equal to "this,is,some,string"

    originalSeparator equal to ","

    targetSeparator equal to "+"

The result should be "this+is+some+string"


 */

using System;

namespace Coding.Exercise
{
    public static class StringsTransformator
    {
        public static string TransformSeparators(
            string input,
            string originalSeparator,
            string targetSeparator)
        {
            string[] separatedString = input.Split(originalSeparator);
            string result = string.Join(targetSeparator, separatedString);

            return result;
        }
    }
}
