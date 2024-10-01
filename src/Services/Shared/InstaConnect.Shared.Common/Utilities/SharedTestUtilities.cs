﻿using Bogus;

namespace InstaConnect.Shared.Common.Utilities;

public class SharedTestUtilities
{
    private static readonly Faker _faker = new();

    public static string GetGuid()
    {
        var result = _faker.Random.Guid().ToString();

        return result;
    }

    public static DateTime GetMaxDate()
    {
        var result = _faker.Date.Future();

        return result;
    }

    public static string GetUrl()
    {
        var result = _faker.Internet.Url();

        return result;
    }

    public static string GetString(int length)
    {
        var result = _faker.Random.AlphaNumeric(length);

        return result;
    }

    public static string GetAverageString(int maxLength, int minLength)
    {
        var result = _faker.Random.AlphaNumeric(GetAverageNumber(maxLength, minLength));

        return result;
    }

    public static int GetAverageNumber(int maxLength, int minLength)
    {
        var result = (maxLength + minLength) / 2;

        return result;
    }

    public static string GetHalfStartString(string value)
    {
        var result = value[..(value.Length / 2)];

        return result;
    }

    public static string GetNonCaseMatchingString(string value)
    {
        var result = value.ToUpper();

        return result;
    }
}
