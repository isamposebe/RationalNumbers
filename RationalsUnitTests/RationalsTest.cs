using Rationals;
using Xunit;

namespace RationalsUnitTests;

public class RationalsTest
{
    [Fact]
    public void TestSum()
    {
        var a = new BigRational(2, 3);
        var b = new BigRational(2, 3);
        Assert.True((a + b).Equals(new BigRational(4, 3)));
    }

    [Fact]
    public void TestMinus()
    {
        var a = new BigRational(3, 3);
        var b = new BigRational(2, 3);
        Assert.True((a - b).Equals(new BigRational(1, 3)));
    }

    [Fact]
    public void TestMultiplication()
    {
        var a = new BigRational(3, 3);
        var b = new BigRational(2, 3);
        Assert.True((a * b).Equals(new BigRational(6, 9)));
    }

    [Fact]
    public void TestDivide()
    {
        var a = new BigRational(3, 3);
        var b = new BigRational(2, 3);
        Assert.True((a / b).Equals(new BigRational(3, 2)));
    }
}