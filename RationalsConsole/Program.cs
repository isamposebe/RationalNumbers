using Rationals;
using System;

namespace RationalsConsole
{
    class Program
    {
        static void Main()
        {
            var a = new Rational(2, 4);
            var b = new Rational(3, 4);
            Console.WriteLine(a * b * new Rational(0));
        }
    }
}
