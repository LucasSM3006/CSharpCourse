using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// There's no 'using System.Diagnostics;' here because it's declared on Program.cs as a global usage.

public class DifferentProgram
{
    static public void DoThat()
    {
        var stopWatch = Stopwatch.StartNew();

        for (int i = 0; i< 1000; i++)
        {
            Console.WriteLine($"Current iteration: {i}");
        }
        stopWatch.Stop();

        Console.WriteLine($"Time in stopwatch (ms): {stopWatch.ElapsedMilliseconds}");

        Console.ReadKey();
    }
}