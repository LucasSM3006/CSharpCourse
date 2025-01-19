int a = 10;
int b = 5;
++a;
--b;
a++;
b--;

Console.WriteLine(a + b);
Console.WriteLine(a - b);
Console.WriteLine(a * b);
Console.WriteLine(a / b);
Console.WriteLine(a % b);

Console.WriteLine("Addition: " + (a + b));
Console.WriteLine("Subtraction: " + (a - b));
Console.WriteLine("Multiplication: " + (a * b));
Console.WriteLine("Division: " + (a / b));
Console.WriteLine("Remainder: " + (a % b));

Console.WriteLine("String" + "Concatenation" + ".");
string word = "abc";
Console.WriteLine(word + "def");

Console.ReadKey();