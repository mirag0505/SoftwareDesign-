using System;
using Xunit;

public sealed class GradeCalculatorTests
{
    [Fact]
    public void CalculateAverage_Null_Throws()
    {
        var calculator = new GradeCalculator();

        Assert.Throws<ArgumentNullException>(() => calculator.CalculateAverage(null!));
    }

    [Fact]
    public void CalculateAverage_Empty_Throws()
    {
        var calculator = new GradeCalculator();

        Assert.Throws<ArgumentException>(() => calculator.CalculateAverage(Array.Empty<int>()));
    }

    [Fact]
    public void CalculateAverage_SingleElement_ReturnsThatElement()
    {
        var calculator = new GradeCalculator();

        var result = calculator.CalculateAverage(new[] { 73 });

        Assert.Equal(73, result);
    }

    [Fact]
    public void CalculateAverage_BoundaryValues_ReturnsExpectedAverage()
    {
        var calculator = new GradeCalculator();

        var result = calculator.CalculateAverage(new[] { 0, 100 });

        Assert.Equal(50, result);
    }

    [Fact]
    public void CalculateAverage_OutOfRangeGrade_Throws()
    {
        var calculator = new GradeCalculator();

        Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateAverage(new[] { 10, 101 }));
    }
}
