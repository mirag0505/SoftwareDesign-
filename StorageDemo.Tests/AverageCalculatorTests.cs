using Xunit;

public sealed class AverageCalculatorTests
{
    [Fact]
    public void CalculateAverage_WhenAverageIsInteger_ReturnsExpectedValue()
    {
        var calculator = new AverageCalculator();

        var result = calculator.CalculateAverage(new[] { 1, 2, 3 });

        Assert.Equal(2, result);
    }

    [Fact]
    public void CalculateAverage_WithSingleElement_ReturnsThatElement()
    {
        var calculator = new AverageCalculator();

        var result = calculator.CalculateAverage(new[] { 10 });

        Assert.Equal(10, result);
    }
}

public sealed class AverageCalculatorEdgeCaseTests
{
    [Fact(Skip = "Демонстрация неполного покрытия: этот тест выявляет баг (целочисленное деление), но обычно его забывают добавить.")]
    public void CalculateAverage_WhenAverageIsFractional_ReturnsExpectedFraction()
    {
        var calculator = new AverageCalculator();

        var result = calculator.CalculateAverage(new[] { 1, 2 });

        Assert.Equal(1.5, result);
    }

    [Fact(Skip = "Демонстрация неполного покрытия: пустой массив может привести к ошибке (деление на 0), но это часто не тестируют.")]
    public void CalculateAverage_WithEmptyArray_Throws()
    {
        var calculator = new AverageCalculator();

        Assert.ThrowsAny<Exception>(() => calculator.CalculateAverage(Array.Empty<int>()));
    }
}
