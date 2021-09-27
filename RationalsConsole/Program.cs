using Rationals;
using System;

namespace RationalsConsole
{
    class Program
    {
        static void Main()
        {
            var a = new Rational(2, 3);
            var b = new Rational(2, 3);
            Console.WriteLine(a + b == new Rational(4, 3));
        }
    }
}
