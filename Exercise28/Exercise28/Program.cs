﻿/*
 * Try-catch-finally. DivideNumbers

In the exercise, you will find the DivideNumbers method, which for now, simply divides two integers. Currently, this method throws an exception when the b argument is zero.


Modify this method in such a way that:

    When the b argument is zero, the result returned from this method is zero. Also, "Division by zero." is printed to the console.

    No matter if b is zero or not, after the calculation has been performed, this method should also print "The DivideNumbers method ends."

This means when dividing by zero, the following will be printed:

"Division by zero.

The DivideNumbers method ends."


And when devising by another number than zero, only the following will be printed:

"The DivideNumbers method ends."
 */

Console.WriteLine(ExceptionsDivisionExercise.DivideNumbers(100, 20));
Console.WriteLine(ExceptionsDivisionExercise.DivideNumbers(10, 0));

Console.ReadKey();


public static class ExceptionsDivisionExercise
{
    public static int DivideNumbers(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (Exception e)
        {
            Console.WriteLine("Division by zero.");
            return 0;
        }
        finally
        {
            Console.WriteLine("The DivideNumbers method ends.");
        }
    }
}
