﻿using System.Numerics;

namespace Rationals;

/// <summary>
///     Rational number with large arbitary integers.
/// </summary>
public struct BigRational : IComparable<BigRational>, IEquatable<BigRational>
{
    private BigInteger Numerator { get; }

    private BigInteger Denominator { get; }

    /// <summary>
    ///     Ctor.
    /// </summary>
    /// <param name="numerator">Numerator.</param>
    /// <param name="denominator">Denominator.</param>
    /// <exception cref="DivideByZeroException">Throws when denominator is zero.</exception>
    public BigRational(BigInteger numerator, BigInteger denominator)
    {
        if (denominator.IsZero)
            throw new DivideByZeroException("Denominator cannot be zero.");

        Numerator = numerator;
        Denominator = denominator;
    }

    /// <summary>
    ///     Ctor.
    /// </summary>
    /// <param name="numerator">Numerator.</param>
    public BigRational(BigInteger numerator) : this(numerator, BigInteger.One)
    {
    }

    /// <summary>
    ///     Ctor.
    /// </summary>
    public BigRational() : this(BigInteger.One, BigInteger.One)
    {
    }

    /// <summary>
    ///     Simplifies the numerator and denominator of a rational number.
    /// </summary>
    /// <returns>Reference to simplified version of a rational number.</returns>
    public BigRational Simplify()
    {
        var gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
        return new BigRational(Numerator / gcd, Denominator / gcd);
    }

    /// <summary>
    ///     True if the number is equal to zero.
    /// </summary>
    public bool IsZero => !IsNaN && Numerator.IsZero;

    /// <summary>
    ///     True if the number is equal to one.
    /// </summary>
    public bool IsOne => !IsNaN && Numerator == Denominator;

    /// <summary>
    ///     True if the value is not a number.
    /// </summary>
    public bool IsNaN => Denominator.IsZero;

    /// <summary>
    ///     Gets a number that indicates the sign (negative, positive, or zero) of the rational number.
    /// </summary>
    public int Sign => IsNaN ? 0 : Numerator.Sign * Denominator.Sign;

    /// <summary>
    ///     Overload of the + operator before number.
    /// </summary>
    /// <param name="a">Rational number.</param>
    /// <returns>Same rational number.</returns>
    public static BigRational operator +(BigRational a)
    {
        return a;
    }

    /// <summary>
    ///     Negation of a rational number.
    /// </summary>
    /// <param name="a">Rational number.</param>
    /// <returns>Rational number with negation.</returns>
    public static BigRational operator -(BigRational a)
    {
        return new BigRational(-a.Numerator, a.Denominator);
    }

    /// <summary>
    ///     The sum of two rational numbers.
    /// </summary>
    /// <param name="a">Left side rational number.</param>
    /// <param name="b">Right side rational number.</param>
    /// <returns>A rational number from the sum of two rational numbers.</returns>
    public static BigRational operator +(BigRational a, BigRational b)
    {
        return new BigRational(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
            a.Denominator * b.Denominator);
    }

    /// <summary>
    ///     The difference of two rational numbers.
    /// </summary>
    /// <param name="a">Left side rational number.</param>
    /// <param name="b">Right side rational number.</param>
    /// <returns>Rational number from the difference of two rational numbers.</returns>
    public static BigRational operator -(BigRational a, BigRational b)
    {
        return a + -b;
    }

    /// <summary>
    ///     Multiplication of two rational numbers.
    /// </summary>
    /// <param name="a">Left side rational number.</param>
    /// <param name="b">Right side rational number.</param>
    /// <returns>Rational number from the multiplication of two rational numbers.</returns>
    public static BigRational operator *(BigRational a, BigRational b)
    {
        return new BigRational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    /// <summary>
    ///     Division of two rational numbers.
    /// </summary>
    /// <param name="a">Left side rational number.</param>
    /// <param name="b">Right side rational number.</param>
    /// <returns>Rational number from the division of two rational numbers</returns>
    /// <exception cref="DivideByZeroException">If the numerator of the right rational number is zero.</exception>
    public static BigRational operator /(BigRational a, BigRational b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Denominator cannot be zero.");
        return new BigRational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    /// <summary>
    ///     Overload of the ++ operator.
    /// </summary>
    /// <param name="a">Rational number.</param>
    /// <returns>Rational with +1.</returns>
    public static BigRational operator ++(BigRational a)
    {
        return a + new BigRational();
    }

    /// <summary>
    ///     Overload of the -- operator.
    /// </summary>
    /// <param name="a">Rational number.</param>
    /// <returns>Rational with -1.</returns>
    public static BigRational operator --(BigRational a)
    {
        return a - new BigRational();
    }

    /// <summary>
    ///     Overload of the == operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Checks that two rational numbers are equal.</returns>
    public static bool operator ==(BigRational left, BigRational right)
    {
        return !left.IsNaN && !right.IsNaN && left.Equals(right);
    }

    /// <summary>
    ///     Overload of the != operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Produce negative equality of two rational numbers.</returns>
    public static bool operator !=(BigRational left, BigRational right)
    {
        return !(left == right);
    }

    /// <summary>
    ///     Overload of the &lt; operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Check that the left rational number is less than the right rational number.</returns>
    public static bool operator <(BigRational left, BigRational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) < 0;
    }

    /// <summary>
    ///     Overload of the &gt; operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Check that the left rational number is greater than the right rational number.</returns>
    public static bool operator >(BigRational left, BigRational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) > 0;
    }

    /// <summary>
    ///     Overload of the &lt;= operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Check that the left rational number is less than or equal to the right rational number.</returns>
    public static bool operator <=(BigRational left, BigRational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) <= 0;
    }

    /// <summary>
    ///     Overload of the &gt;= operator.
    /// </summary>
    /// <param name="left">Left side rational number.</param>
    /// <param name="right">Right side rational number.</param>
    /// <returns>Check that the left rational number is greater than or equal to the right rational number.</returns>
    public static bool operator >=(BigRational left, BigRational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) >= 0;
    }

    public bool Equals(BigRational other)
    {
        if (IsNaN)
            return other.IsNaN;

        return !other.IsNaN && (Numerator * other.Denominator).Equals(other.Numerator * Denominator);
    }

    public int CompareTo(BigRational other)
    {
        if (IsNaN) return other.IsNaN ? 0 : -1;

        if (other.IsNaN) return 1;

        if (Sign == other.Sign)
        {
            var adjDenominator = BigInteger.Abs(Denominator) * new BigInteger(other.Denominator.Sign);
            var adjOtherDenominator = BigInteger.Abs(other.Denominator) * new BigInteger(Denominator.Sign);
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
        return obj is BigRational other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }
}