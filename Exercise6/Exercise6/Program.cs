/*
 * Switch statement - DescribeDay

Implement the DescribeDay method, which given a day of the week as a number, should return:

    "Working day" for numbers 1 to 5

    "Weekend" for numbers 6 and 7

    "Invalid day number" for any other number
*/

using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static string DescribeDay(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return "Working day";
                case 6:
                case 7:
                    return "Weekend";
                default:
                    return "Invalid day number";
            }
        }
    }
}
