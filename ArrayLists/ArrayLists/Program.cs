
using System.Collections;

// C# Before generics. ArrayList holds multiple objects, so it can hold multiple different types since everything is an object, which can cause problems.

ArrayList ints = new ArrayList { 1, 2, 3, 4};

int sum = 0;

foreach (object i in ints)
{
    sum += (int) i;
}

ArrayList strings = new ArrayList { "aaa", "bbb", "ccc" };

ArrayList variousTypes = new ArrayList { "aaa", false, 2.0, 'a', 20000, new DateTime() };
object[] objects = new object[] { "aaa", false, 2.0, 'a', 20000, new DateTime() };

Console.ReadKey();