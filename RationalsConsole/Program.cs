using System;
using Rationals;

namespace RationalsConsole
{
    class Program
    {
        static void Main()
        {
            var a = new Rational(2, 4);
            var b = new Rational(2, 4);
            System.Console.WriteLine(a*b);
        }
    }
}
