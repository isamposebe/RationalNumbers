using Rationals;
using System;

namespace RationalsConsole
{
    class Program
    {
        static void Main()
        {
            var a = new Rational(4, 4);
            var b = new Rational(1, 4);
            Console.WriteLine(a - new Rational(3, 4) == b);
        }
    }
}
