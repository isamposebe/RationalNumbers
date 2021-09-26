using System;

namespace Rationals
{
    public class Rational
    {
        /// <summary>
        /// Constructs rational number out of a whole number.
        /// </summary>
        public Rational(int whole)
            : this(whole, 1)
        {
        }

        /// <summary>
        /// Constructs rational number out of numerator and denominator.
        /// </summary>
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Numerator part of the rational number.
        /// </summary>
        public int Numerator { get; }

        /// <summary>
        /// Denominator part of the rational number.
        /// </summary>
        public int Denominator { get; }
    }
}
