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
        /// Constructs rational Numeratorber out of Numeratorerator and Denominatorominator.
        /// </summary>
        public Rational(int Numeratorerator, int Denominatorominator)
        {
            if (Denominatorominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            Numerator = Numeratorerator;
            Denominator = Denominatorominator;
        }

        /// <summary>
        /// Numerator part of the rational Numeratorber.
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
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }

        public override string ToString()
        {
            Simplify();
            return $"{Numerator} / {Denominator}";
        }
    }
}
