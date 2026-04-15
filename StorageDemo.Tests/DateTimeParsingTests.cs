using System;
using System.Globalization;
using Xunit;

public sealed class DateTimeParsingTests
{
    [Fact]
    public void ParseLocalYmdHms_WithUtc_ReturnsSameInstant()
    {
        var result = DateTimeParsing.ParseLocalYmdHms("2024-05-13 14:30:00", "UTC");
        Assert.Equal(new DateTimeOffset(2024, 5, 13, 14, 30, 0, TimeSpan.Zero), result);
    }

    [Fact]
    public void ParseLocalYmdHms_WithMoscow_ConvertsToUtc()
    {
        var result = DateTimeParsing.ParseLocalYmdHms("2024-05-13 14:30:00", "Europe/Moscow");
        Assert.Equal(new DateTimeOffset(2024, 5, 13, 11, 30, 0, TimeSpan.Zero), result);
    }

    [Fact]
    public void ParseLocalYmdHms_WhenLocalTimeIsInvalidDueToDst_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            DateTimeParsing.ParseLocalYmdHms("2024-03-31 02:30:00", "Europe/Berlin")
        );
    }

    [Fact]
    public void ParseLocalYmdHms_WhenLocalTimeIsAmbiguousDueToDst_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            DateTimeParsing.ParseLocalYmdHms("2024-10-27 02:30:00", "Europe/Berlin")
        );
    }

    [Fact]
    public void ParseLocalYmdHms_IsCultureInvariant()
    {
        var original = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
            var result = DateTimeParsing.ParseLocalYmdHms("2024-05-13 14:30:00", "UTC");
            Assert.Equal(new DateTimeOffset(2024, 5, 13, 14, 30, 0, TimeSpan.Zero), result);
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }
    }
}
