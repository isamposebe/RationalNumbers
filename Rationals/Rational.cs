namespace Rationals;

/// <summary>
///     Rational number with general operations and conversion from and to double number.
/// </summary>
public struct Rational : IComparable<Rational>, IEquatable<Rational>
{
    private int Numerator { get; }

    private int Denominator { get; }

    /// <summary>
    ///     Ctor.
    /// </summary>
    /// <param name="numerator">Numerator.</param>
    /// <param name="denominator">Denominator.</param>
    /// <exception cref="DivideByZeroException">Throws when denominator is zero.</exception>
    public Rational(int numerator = 0, int denominator = 1)
    {
        if (denominator == 0)
            throw new DivideByZeroException("Denominator cannot be zero.");

        Numerator = numerator;
        Denominator = denominator;
    }

    /// <summary>
    ///     Ctor.
    /// </summary>
    /// <param name="number">Double number that we convert to rational number</param>
    /// <param name="bound">Max lenght of denominator</param>
    public Rational(double number, double bound = 4096.0)
    {
        if (number == 0.0)
        {
            Numerator = 0;
            Denominator = 1;
        }

        var temp = Math.Abs(number);
        var best = 1;
        var bestError = double.MaxValue;

        for (var i = 1; i < bound; i++)
        {
            var error = Math.Abs(i * temp - Math.Round(i * temp));
            if (!(error < bestError)) continue;
            best = i;
            bestError = error;
        }

        Numerator = (int) Math.Round(best * temp) * Math.Sign(number);
        Denominator = best;
    }

    /// <summary>
    ///     Convert rational number to double double number.
    /// </summary>
    /// <returns>Division between numerator and denominator.</returns>
    public double AsDouble()
    {
        return (double) Numerator / Denominator;
    }

    /// <summary>
    ///     Simplifies the numerator and denominator of a rational number.
    /// </summary>
    /// <returns>Reference to simplified version of a rational number.</returns>
    public Rational Simplify()
    {
        var gcd = GreatestCommonDivisor(Numerator, Denominator);
        return new Rational(Numerator / gcd, Denominator / gcd);
    }

    /// <summary>
    ///     True if the number is equal to zero.
    /// </summary>
    public bool IsZero => !IsNaN && Numerator == 0;

    /// <summary>
    ///     True if the number is equal to one.
    /// </summary>
    public bool IsOne => !IsNaN && Numerator == Denominator;

    /// <summary>
    ///     True if the value is not a number.
    /// </summary>
    public bool IsNaN => Denominator == 0;

    /// <summary>
    ///     Gets a number that indicates the sign (negative, positive, or zero) of the rational number.
    /// </summary>
    public int Sign => IsNaN ? 0 : Math.Sign(Numerator) * Math.Sign(Denominator);

    /// <summary>
    ///     Overload of the + operator before number.
    /// </summary>
    /// <param name="a">Rational number.</param>
    /// <returns>Same rational number.</returns>
    public static Rational operator +(Rational a)
    {
        return a;
    }

    /// <summary>
    ///     Negation of a rational number.
    /// </summary>
    /// <param name="a">Rational number.</param>
    /// <returns>Rational number with negation.</returns>
    public static Rational operator -(Rational a)
    {
        return new Rational(-a.Numerator, a.Denominator);
    }

    /// <summary>
    ///     The sum of two rational numbers.
    /// </summary>
    /// <param name="a">Left side rational number.</param>
    /// <param name="b">Right side rational number.</param>
    /// <returns>A rational number from the sum of two rational numbers.</returns>
    public static Rational operator +(Rational a, Rational b)
    {
        return new Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
            a.Denominator * b.Denominator);
    }

    /// <summary>
    ///     The difference of two rational numbers.
    /// </summary>
    /// <param name="a">Left side rational number.</param>
    /// <param name="b">Right side rational number.</param>
    /// <returns>Rational number from the difference of two rational numbers.</returns>
    public static Rational operator -(Rational a, Rational b)
    {
        return a + -b;
    }

    /// <summary>
    ///     Multiplication of two rational numbers.
    /// </summary>
    /// <param name="a">Left side rational number.</param>
    /// <param name="b">Right side rational number.</param>
    /// <returns>Rational number from the multiplication of two rational numbers.</returns>
    public static Rational operator *(Rational a, Rational b)
    {
        return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    /// <summary>
    ///     Division of two rational numbers.
    /// </summary>
    /// <param name="a">Left side rational number.</param>
    /// <param name="b">Right side rational number.</param>
    /// <returns>Rational number from the division of two rational numbers</returns>
    /// <exception cref="DivideByZeroException">If the numerator of the right rational number is zero.</exception>
    public static Rational operator /(Rational a, Rational b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Denominator cannot be zero.");
        return new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    /// <summary>
    ///     Overload of the ++ operator.
    /// </summary>
    /// <param name="a">Rational number.</param>
    /// <returns>Rational with +1.</returns>
    public static Rational operator ++(Rational a)
    {
        return a + new Rational();
    }

    /// <summary>
    ///     Overload of the -- operator.
    /// </summary>
    /// <param name="a">Rational number.</param>
    /// <returns>Rational with -1.</returns>
    public static Rational operator --(Rational a)
    {
        return a - new Rational();
    }

    /// <summary>
    ///     Overload of the == operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Checks that two rational numbers are equal.</returns>
    public static bool operator ==(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.Equals(right);
    }

    /// <summary>
    ///     Overload of the != operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Produce negative equality of two rational numbers.</returns>
    public static bool operator !=(Rational left, Rational right)
    {
        return !(left == right);
    }

    /// <summary>
    ///     Overload of the &lt; operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Check that the left rational number is less than the right rational number.</returns>
    public static bool operator <(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) < 0;
    }

    /// <summary>
    ///     Overload of the &gt; operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Check that the left rational number is greater than the right rational number.</returns>
    public static bool operator >(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) > 0;
    }

    /// <summary>
    ///     Overload of the &lt;= operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Check that the left rational number is less than or equal to the right rational number.</returns>
    public static bool operator <=(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) <= 0;
    }

    /// <summary>
    ///     Overload of the &gt;= operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Check that the left rational number is greater than or equal to the right rational number.</returns>
    public static bool operator >=(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) >= 0;
    }

    private static int GreatestCommonDivisor(int p, int q)
    {
        if (q == 0) return p;
        return GreatestCommonDivisor(q, p % q);
    }

    public bool Equals(Rational other)
    {
        return CompareTo(other) == 0;
    }

    public int CompareTo(Rational other)
    {
        if (IsNaN) return other.IsNaN ? 0 : -1;

        if (other.IsNaN) return 1;

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

    public override string ToString()
    {
        this = Simplify();
        return $"{Numerator} / {Denominator}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Rational other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }
}