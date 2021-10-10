using Rationals;
using System;

namespace RationalsConsole
{
    class Program
    {
        static void Main()
        {
            Rational a = new(2, 3);
            Rational b = new(1, 5);
            Console.WriteLine(a + b - new Rational(52, 15));
        }
    }
}
