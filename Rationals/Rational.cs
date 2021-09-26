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

        /// <summary>
        /// True if the number is equal to zero.
        /// </summary>
        public bool IsZero => !IsNaN && Numerator == 0;

        /// <summary>
        /// True if the number is equal to one.
        /// </summary>
        public bool IsOne => !IsNaN && Numerator == Denominator;

        /// <summary>
        /// True if the value is not a number.
        /// <see cref="NaN"/>
        /// </summary>
        public bool IsNaN => Denominator == 0;

        /// <summary>
        /// Gets a number that indicates the sign (negative, positive, or zero) of the rational number.
        /// </summary>
        public int Sign => IsNaN ? 0 : Math.Sign(Numerator) * Math.Sign(Denominator);

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

        public bool Equals(Rational other)
        {
            if (IsNaN)
                return other.IsNaN;

            if (other.IsNaN)
                return false;

            return (Numerator * other.Denominator).Equals(other.Numerator * Denominator);
        }

        public int CompareTo(Rational other)
        {
            if (IsNaN)
            {
                return other.IsNaN ? 0 : -1;
            }

            if (other.IsNaN)
            {
                return 1;
            }

            if (Sign == other.Sign)
            {

                var adjDenominator = Math.Abs(Denominator) * Math.Sign(other.Denominator);
                var adjOtherDenominator = Math.Abs(other.Denominator) * Math.Sign(Denominator);
                return (Numerator * adjOtherDenominator).CompareTo(other.Numerator * adjDenominator);
            }

            if (Sign > other.Sign)
                return 1;

            return -1;
        }

        /// <summary>
        /// Overload of the ++ operator.
        /// </summary>
        public static Rational operator ++(Rational a) => a + new Rational(1);

        /// <summary>
        /// Overload of the -- operator.
        /// </summary>
        public static Rational operator --(Rational a) => a - new Rational(1);

        /// <summary>
        /// Overload of the == operator.
        /// </summary>
        public static bool operator ==(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.Equals(right);

        /// <summary>
        /// Overload of the != operator.
        /// </summary>
        public static bool operator !=(Rational left, Rational right) => !(left == right);

        /// <summary>
        /// Overload of the &lt; operator.
        /// </summary>
        public static bool operator <(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.CompareTo(right) < 0;

        /// <summary>
        /// Overload of the &gt; operator.
        /// </summary>
        public static bool operator >(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.CompareTo(right) > 0;

        /// <summary>
        /// Overload of the &lt;= operator.
        /// </summary>
        public static bool operator <=(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.CompareTo(right) <= 0;

        /// <summary>
        /// Overload of the &gt;= operator.
        /// </summary>
        public static bool operator >=(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.CompareTo(right) >= 0;

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
            return $"{Numerator} / {Denominator}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
