using Rationals;
using Xunit;

namespace RationalsUnitTests;

public sealed class RationalNumbersTest
{
    [Fact]
    public void Sum()
    {
        var a = new Rational(1, 4);
        var b = new Rational(2, 4);
        var rez = (a + b).AsDouble();
        Assert.True(rez == 0.75);
    }

    [Fact]
    public void TestMinus()
    {
        var a = new Rational(3, 3);
        var b = new Rational(2, 3);
        Assert.True((a - b).Equals(new Rational(1, 3)));
    }

    [Fact]
    public void TestMultiplication()
    {
        var a = new Rational(3, 3);
        var b = new Rational(2, 3);
        Assert.True((a * b).Equals(new Rational(6, 9)));
    }

    [Fact]
    public void TestDivide()
    {
        var a = new Rational(3, 3);
        var b = new Rational(2, 3);
        Assert.True((a / b).Equals(new Rational(3, 2)));
    }
    [Fact]
    public void Test1()
    {
        var a = new Rational(1);
        var b = new Rational(2);
        Assert.True((a / b).Equals(new Rational(1, 2)));
    }
    [Fact]
    public void Test2()
    {
        var a = new Rational(1);
        var b = new Rational(2);
        var d = new Rational(2, 3);
        var c = (a / b)+d;
        Assert.True(c.Equals(new Rational(7, 6)));
    }

}