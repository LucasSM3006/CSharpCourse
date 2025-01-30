// When a type lacks a method we need, if this type is defined in the code, we can just add it.
// It's also possible to just create a type derived from that type, and then add the method there.
// Though, it can complicate code, or what we want to extend might be sealed.

// In this example, we'll add a method to the string class without modifying it.

// There's an extra folder and file here with the extension method. We're not actually modifying the string class, nor really doing anything to it, it's more so for ease of readability.

using ExtensionMethods.Extensions;

string multilinetext = @"aaaa
bbbb
cccc
dddd";

Console.WriteLine($"Count of lines: {multilinetext.CountLines()}");

// Note how we can just call it like a static method (Because that's what it just is)

Console.WriteLine($"Count of lines: {StringExtensions.CountLines(multilinetext)}");

// Enum.

Console.WriteLine($"Next after summer is: {Season.Summer.Next()}");
Console.WriteLine($"Next after winter is: {Season.Winter.Next()}");

Console.ReadKey();


// Extensions also let us add things to... Enums!

public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}