/*
 * 
 * Basics of lambda expressions

The Exercise class has two fields of Func type. To each of them, assign a lambda expression so that:

    GetLength stores a function taking a string and returning its length.

    GetRandomNumberBetween1And10 stores a parameterless function generating a random number between 1 and 10.
 * 
 * 
 */



public class Exercise
{
    public Func<string, int> GetLength = n => n.Length;
    public Func<int> GetRandomNumberBetween1And10 = () => new Random().Next(1, 11);
}