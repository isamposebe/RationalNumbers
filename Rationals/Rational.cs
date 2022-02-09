using System.Numerics;

namespace Rationals;

/// <summary>
///     Rational number.
/// </summary>
public struct Rational : IComparable<Rational>, IEquatable<Rational>
{
    private BigInteger Numerator { get; }

    private BigInteger Denominator { get; }

    /// <summary>
    ///     Ctor.
    /// </summary>
    /// <param name="numerator">Numerator</param>
    /// <param name="denominator">Denominator</param>
    /// <exception cref="DivideByZeroException">Throws when denominator is zero</exception>
    public Rational(BigInteger numerator, BigInteger denominator)
    {
        if (denominator.IsZero)
            throw new DivideByZeroException("Denominator cannot be zero.");

        Numerator = numerator;
        Denominator = denominator;
    }

    /// <summary>
    ///     Ctor.
    /// </summary>
    /// <param name="numerator">Numerator</param>
    public Rational(BigInteger numerator) : this(numerator, BigInteger.One)
    {
    }

    /// <summary>
    ///     Ctor.
    /// </summary>
    public Rational() : this(BigInteger.One, BigInteger.One)
    {
    }

    /// <summary>
    ///     Simplifies the numerator and denominator of a rational number.
    /// </summary>
    /// <returns>Reference to simplified version of a rational number.</returns>
    public Rational Simplify()
    {
        var gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
        return new Rational(Numerator / gcd, Denominator / gcd);
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
    /// Опиратор сложения одного числа
    /// </summary>
    /// <param name="a">число для сложения</param>
    /// <returns>выполнения сложения</returns>
    public static Rational operator +(Rational a)
    {
        return a;
    }

    /// <summary>
    /// Отрицание числа <param name="a">
    /// </summary>
    /// <param name="a">Число для отрицания</param>
    /// <returns>Выполнение оператора отрицания</returns>
    public static Rational operator -(Rational a)
    {
        return new Rational(-a.Numerator, a.Denominator);
    }

    /// <summary>
    /// Операция сложения 2 чисел
    /// </summary>
    /// <param name="a">Первое число для сложения</param>
    /// <param name="b">Второе число для сложения</param>
    /// <returns>Выполнения операции сложения двух чисел <param name="a"> и <param name="b"></returns>
    public static Rational operator +(Rational a, Rational b)
    {
        return new Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
            a.Denominator * b.Denominator);
    }

    /// <summary>
    /// Опирация вычитания чисел <param name="a"> и <param name="b">
    /// Пример: 3 - 5 = -2, где 3 = a, 5 = b 
    /// </summary>
    /// <param name="a">Уменьшаемое</param>
    /// <param name="b">Вычитаемое </param>
    /// <returns>Разность</returns>
    public static Rational operator -(Rational a, Rational b)
    {
        return a + -b;
    }

    /// <summary>
    /// Операция умнажения 
    /// </summary>
    /// <param name="a">первое число</param>
    /// <param name="b">второе число</param>
    /// <returns>Произведение</returns>
    public static Rational operator *(Rational a, Rational b)
    {
        return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    /// <summary>
    /// Операция деления 
    /// </summary>
    /// <param name="a">Делимое</param>
    /// <param name="b">Делитель</param>
    /// <returns>Частное</returns>
    /// <exception cref="DivideByZeroException"></exception>
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
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.Equals(right);
    }

    /// <summary>
    ///     Overload of the != operator.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(Rational left, Rational right)
    {
        return !(left == right);
    }

    /// <summary>
    ///     Overload of the &lt; operator.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) < 0;
    }

    /// <summary>
    ///     Overload of the &gt; operator.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) > 0;
    }

    /// <summary>
    ///     Overload of the &lt;= operator.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) <= 0;
    }

    /// <summary>
    ///     Overload of the &gt;= operator.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(Rational left, Rational right)
    {
        return !left.IsNaN && !right.IsNaN && left.CompareTo(right) >= 0;
    }

    public bool Equals(Rational other)
    {
        if (IsNaN)
            return other.IsNaN;

        return !other.IsNaN && (Numerator * other.Denominator).Equals(other.Numerator * Denominator);
    }

    public int CompareTo(Rational other)
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
        return obj is Rational other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }
}