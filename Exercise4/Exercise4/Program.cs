using System;

namespace Coding.Exercise
{
    /*
     * Define the AbsoluteOfSum method, which takes two int parameters, and returns the absolute value of their sum.
    Absolute value is the non-negative value of the number, without regard to its sign. So for example, the absolute value of 5 is 5, and the absolute value of -10 is 10.
    */

    public class Exercise
    {
        public static int AbsoluteOfSum(int a, int b)
        {
            if (a + b < 0)
            {
                return ((a + b) * -1);
            }
            return (a + b);
        }
    }
}
