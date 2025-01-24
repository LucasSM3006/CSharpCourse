/*
 * Static classes - NumberToDayOfWeekTranslator

Implement the static NumberToDayOfWeekTranslator class that can be used like this:



The Translate method should take a number and return a string with the name of the day of the week, according to the following:

    for 1, "Monday" is returned

    for 2, "Tuesday" is returned

    ...

    for 7, "Sunday" is returned

    for any other number, "Invalid day of the week" is returned
 * 
 */

using System;

namespace Coding.Exercise
{
    public static class NumberToDayOfWeekTranslator
    {
        public static string Translate(int number)
    {
        switch (number)
        {
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thursday";
            case 5:
                return "Friday";
            case 6:
                return "Saturday";
            case 7:
                return "Sunday";
            default:
                return "Invalid day of the week";
        }

    }
}
}
