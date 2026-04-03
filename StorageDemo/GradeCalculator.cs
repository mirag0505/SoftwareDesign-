using System;
using System.Collections.Generic;

public sealed class GradeCalculator
{
    public double CalculateAverage(IReadOnlyList<int> grades)
    {
        if (grades is null)
        {
            throw new ArgumentNullException(nameof(grades));
        }

        if (grades.Count == 0)
        {
            throw new ArgumentException("Grades must not be empty.", nameof(grades));
        }

        long sum = 0;
        foreach (var grade in grades)
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(grades), "Each grade must be between 0 and 100.");
            }

            sum += grade;
        }

        return (double)sum / grades.Count;
    }
}
