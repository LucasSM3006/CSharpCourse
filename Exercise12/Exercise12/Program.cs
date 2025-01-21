/*
 * Multi-dimensional arrays - FindMax

Implement the FindMax method, which given a two-dimensional array of integers, returns the maximal value from this array.

If any of the array's dimensions is zero, it means the array is empty, and the method should return -1.

For example:

    for an empty array of size [0,3] the result should be -1

    for an array like this, the result should be 12
 * 
 */

using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static int FindMax(int[,] numbers)
        {
            int rows = numbers.GetLength(0);
            int columns = numbers.GetLength(1);

            if (rows == 0 || columns == 0) return -1;

            int maxNumber = numbers[0, 0];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (numbers[i, j] > maxNumber)
                    {
                        maxNumber = numbers[i, j];
                    }
                }
            }

            return maxNumber;
        }
    }
}

