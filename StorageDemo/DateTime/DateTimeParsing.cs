using System;
using System.Collections.Generic;
using System.Globalization;

public static class DateTimeParsing
{
    public static DateTimeOffset ParseLocal(string value, string pattern, string timeZoneId)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (pattern == null) throw new ArgumentNullException(nameof(pattern));
        if (timeZoneId == null) throw new ArgumentNullException(nameof(timeZoneId));

        var local = DateTime.ParseExact(
            value,
            pattern,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None
        );

        local = DateTime.SpecifyKind(local, DateTimeKind.Unspecified);
        var zone = FindTimeZone(timeZoneId);

        if (zone.IsInvalidTime(local))
        {
            throw new ArgumentException($"Invalid local time for time zone '{timeZoneId}'.", nameof(value));
        }

        if (zone.IsAmbiguousTime(local))
        {
            throw new ArgumentException($"Ambiguous local time for time zone '{timeZoneId}'.", nameof(value));
        }

        var utc = TimeZoneInfo.ConvertTimeToUtc(local, zone);
        return new DateTimeOffset(utc, TimeSpan.Zero);
    }

    public static DateTimeOffset ParseLocalYmdHms(string value, string timeZoneId) =>
        ParseLocal(value, "yyyy-MM-dd HH:mm:ss", timeZoneId);

    private static TimeZoneInfo FindTimeZone(string timeZoneId)
    {
        if (TryFindTimeZone(timeZoneId, out var direct)) return direct;

        if (IanaToWindows.TryGetValue(timeZoneId, out var windowsId) &&
            TryFindTimeZone(windowsId, out var byWindows))
        {
            return byWindows;
        }

        if (WindowsToIana.TryGetValue(timeZoneId, out var ianaId) &&
            TryFindTimeZone(ianaId, out var byIana))
        {
            return byIana;
        }

        throw new TimeZoneNotFoundException($"Time zone '{timeZoneId}' not found.");
    }

    private static bool TryFindTimeZone(string id, out TimeZoneInfo zone)
    {
        try
        {
            zone = TimeZoneInfo.FindSystemTimeZoneById(id);
            return true;
        }
        catch
        {
            zone = null!;
            return false;
        }
    }

    private static readonly Dictionary<string, string> IanaToWindows = new(StringComparer.OrdinalIgnoreCase)
    {
        ["UTC"] = "UTC",
        ["Etc/UTC"] = "UTC",
        ["Europe/Moscow"] = "Russian Standard Time",
        ["Europe/Berlin"] = "W. Europe Standard Time"
    };

    private static readonly Dictionary<string, string> WindowsToIana = new(StringComparer.OrdinalIgnoreCase)
    {
        ["UTC"] = "Etc/UTC",
        ["Russian Standard Time"] = "Europe/Moscow",
        ["W. Europe Standard Time"] = "Europe/Berlin"
    };
}
