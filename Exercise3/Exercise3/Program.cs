using System;

namespace Coding.Exercise
{
    /*
     * To the result variable, assign a string according to the following rules:

    if number is smaller than zero, it should be "negative"

    if number is exactly zero, it should be "zero"

    if number is larger than zero, it should be "positive"
     */
    public class Exercise
    {
        public static string IsElseConditionalStatement()
        {
            int number = 0;

            string result = "";

            if (number > 0)
            {
                result = "positive";
            }
            else if (number < 0)
            {
                result = "negative";
            }
            else
            {
                result = "zero";
            }

            // On the original exercise, 'result' was not initialized.

            return result;
        }
    }
}
