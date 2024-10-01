using Bogus;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Shared.Common.Utilities;

public class SharedTestUtilities
{
    private static readonly Faker _faker = new();

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;


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
}
