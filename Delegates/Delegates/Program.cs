// A delegate is a type whose instances hold a reference to a method or methods with a particular parameter list and return type
// A delegate var that holds references to more than one function is a multicast delegate
// The reason why bother to use delegates is that they're more generic than funcs or actions, and existed before funcs and actions.

ProcessString processString1 = TrimToFiveLetters; // Stores a function
ProcessString processString2 = ToUpper;

// Code below is the code above translated to funcs.
Func<string, string> processString4 = TrimToFiveLetters;
Func<string, string> processString5 = ToUpper;

Console.WriteLine(processString1("abcdefhijklmnopqrstuvwxyz")); // Uses that function
Console.WriteLine(processString2("started as lower case"));



Print print1 = text => Console.WriteLine(text.ToUpper());
Print print2 = text => Console.WriteLine(text.ToLower());
Print print3 = text => Console.WriteLine(text.Substring(0, 3));

Print multicast = print1 + print2;
multicast += print3;

multicast("Crocodillus");

// Funcs and Actions are generic delegates by the way

Func<string, string, int> sumLengths = SumLengths;

Console.ReadKey();

int SumLengths(string text1, string text2)
{
    return text1.Length + text2.Length;
}

string TrimToFiveLetters(string input)
{
    return input.Substring(0, 5);
}

string ToUpper(string input)
{
    return input.ToUpper();
}

// Declared the same as a function
delegate string ProcessString(string input);

delegate void Print(string input);