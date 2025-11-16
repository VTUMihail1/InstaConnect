using System.Globalization;
using System.Text;

using Bogus;

using InstaConnect.Common.Domain.Models;

using Microsoft.AspNetCore.Http;

using NSubstitute;

namespace InstaConnect.Common.Tests.Utilities;

public abstract class DataFaker
{
    private const int DefaultStringLength = 100;

    private static readonly Faker _faker = new();

    public static IFormFile GetFile(string name)
    {
        var formFile = Substitute.For<IFormFile>();

        var fileContent = Encoding.UTF8.GetBytes("This is a test file.");
        var stream = new MemoryStream(fileContent)
        {
            Position = 0
        };

        formFile.OpenReadStream().Returns(stream);
        formFile.Name.Returns(name);
        formFile.FileName.Returns(name);
        formFile.ContentType.Returns("text/plain");
        formFile.Length.Returns(stream.Length);

        return formFile;

    }

    public static string GetGuid()
    {
        var result = _faker.Random.Guid().ToString();

        return result;
    }

    public static DateTimeOffset GetMaxDate()
    {
        var result = _faker.Date.Future();

        return result;
    }

    public static string GetUrl()
    {
        var result = _faker.Internet.Url();

        return result;
    }

    public static string GetString(int length = DefaultStringLength)
    {
        var result = _faker.Random.AlphaNumeric(length);

        return result;
    }

    public static string GetAverageString(int maxLength, int minLength = default)
    {
        var result = _faker.Random.AlphaNumeric(GetAverageNumber(maxLength, minLength));

        return result;
    }

    public static int GetAverageNumber(int maxLength, int minLength)
    {
        var result = (maxLength + minLength) / 2;

        return result;
    }

    public static string GetPrefixString(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        var result = value[..(value.Length / 2)];

        return result;
    }

    public static string GetDifferentCaseString(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        var result = value.ToUpper(CultureInfo.CurrentCulture);

        return result;
    }

    public static TEnum GetEmptyEnum<TEnum>()
        where TEnum : Enum
    {
        var emptyEnum = default(TEnum);

        return emptyEnum!;
    }

    public static CommonSortOrder GetSortOrder()
    {
        const CommonSortOrder SortOrder = CommonSortOrder.ASC;

        return SortOrder;
    }
}
