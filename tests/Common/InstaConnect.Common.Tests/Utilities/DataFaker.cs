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
        return _faker.Random.Guid().ToString();
    }

    public static DateTimeOffset GetRecentDate()
    {
        return _faker.Date.Recent();
    }

    public static string GetUrl()
    {
        return _faker.Internet.Url();
    }

    public static string GetString(int length = DefaultStringLength)
    {
        return _faker.Random.AlphaNumeric(length);
    }

    public static string GetAverageString(int maxLength, int minLength = default)
    {
        return _faker.Random.AlphaNumeric(GetAverageNumber(maxLength, minLength));
    }

    public static int GetAverageNumber(int maxLength, int minLength)
    {
        return (maxLength + minLength) / 2;
    }

    public static string GetPrefixString(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        return value[..(value.Length / 2)];
    }

    public static string GetDifferentCaseString(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        return value.ToUpper(CultureInfo.CurrentCulture);
    }

    public static TEnum GetEmptyEnum<TEnum>()
        where TEnum : Enum
    {
        return default!;
    }

    public static CommonSortOrder GetSortOrder()
    {
        const CommonSortOrder SortOrder = CommonSortOrder.ASC;

        return SortOrder;
    }
}
