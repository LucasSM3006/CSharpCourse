/*
 * "is" operator and null object -NumericTypesDescriber class

Implement the Describe method from the NumericTypesDescriber class.

This method takes any object as a parameter. If this object is any of the int, double, or decimal types, it should return the type's name and the object value as a string. If the input is a different type, this method should return null.


Depending on the type of input, the Describe method should behave as follows:

    for ints, the result will be, for example, "Int of value 5"

    for doubles, the result will be, for example, "Double of value 5.6"

    for decimals, the result will be, for example, "Decimal of value 5.7"

    for any other type, the result shall be null
 * 
 */

string word = "Ämogus";
int number = 400;
decimal decimalNumber = 10.01m;
double doubleNumber = 10.01;

Console.WriteLine(NumericTypesDescriber.Describe(word));
Console.WriteLine(NumericTypesDescriber.Describe(number));
Console.WriteLine(NumericTypesDescriber.Describe(decimalNumber));
Console.WriteLine(NumericTypesDescriber.Describe(doubleNumber));

Console.ReadKey();

public static class NumericTypesDescriber
{
    public static string Describe(object someObject)
    {
        switch (someObject)
        {
            case int:
                return $"Int of value {someObject}";
            case double:
                return $"Double of value {someObject}";
            case decimal:
                return $"Decimal of value {someObject}";
            default:
                return null;
        }
    }
}
