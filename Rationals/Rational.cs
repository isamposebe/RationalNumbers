using System;

namespace Rationals
{
    public class Rational
    {
        /// <summary>
        /// Constructs rational Numeratorber out of a whole Numeratorber.
        /// </summary>
        public Rational(int whole)
            : this(whole, 1)
        {
        }

        /// <summary>
        /// Constructs rational numerator out of numerator and denominator.
        /// </summary>
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Numerator part of the rational numerator.
        /// </summary>
        public int Numerator { get; set; }

        /// <summary>
        /// Denominator part of the rational number.
        /// </summary>
        public int Denominator { get; set; }

        public static Rational operator +(Rational a) => a;
        public static Rational operator -(Rational a) => new(-a.Numerator, a.Denominator);

        public static Rational operator +(Rational a, Rational b)
        => new(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Rational operator -(Rational a, Rational b)
            => a + (-b);

        public static Rational operator *(Rational a, Rational b)
            => new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");
            return new(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        private void Simplify()
        {
            var gcd = Gcd(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private static int Gcd(int a, int b)
        {
            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        public override string ToString()
        {
            Simplify();
            if (Numerator != 0)
                return $"{Numerator} / {Denominator}";
            else
                return "0";
        }
    }
}
