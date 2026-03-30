public sealed class AverageCalculator
{
    public double CalculateAverage(int[] numbers)
    {
        var sum = 0;
        foreach (var n in numbers)
        {
            sum += n;
        }

        return sum / numbers.Length;
    }
}
