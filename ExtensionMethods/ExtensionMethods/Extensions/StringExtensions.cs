using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods.Extensions
{
    public static class StringExtensions
    {
        public static int CountLines(this string input) =>
            input.Split(Environment.NewLine).Length;
    }
}
