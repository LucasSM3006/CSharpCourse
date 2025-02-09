/*
 * Basics of Funcs and Actions

In the code, you will see three variables: someMethod1, someMethod2, and someMethod3. Specify their types, so the code compiles. Do not use implicitly-typed variables (var).
 * 
 */

public class Exercise
{
    public void TestMethod()
    {
        Func<int, bool, double> someMethod1 = Method1;
        Func<DateTime> someMethod2 = Method2;
        Action<string, string> someMethod3 = Method3;
    }

    public double Method1(int a, bool b) => 0;
    public DateTime Method2() => default(DateTime);
    public void Method3(string a, string b) { }
}