using System.Formats.Asn1;
using System.Text.RegularExpressions;

using InstaConnect.Common.Domain.Extensions;

using MongoDB.Bson;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class BsonRegularExpressionExtensions
{
    public static BsonRegularExpression GetEqualsCaseInsensitiveRegex(this object value)
    {
        return value.GetCaseInsensitiveRegex("^{0}$");
    }

    public static BsonRegularExpression GetStartsWithCaseInsensitiveRegex(this object value)
    {
        return value.GetCaseInsensitiveRegex("^{0}");
    }

    public static BsonRegularExpression GetEndsWithCaseInsensitiveRegex(this object value)
    {
        return value.GetCaseInsensitiveRegex("{0}$");
    }

    public static BsonRegularExpression GetContainsCaseInsensitiveRegex(this object value)
    {
        return value.GetCaseInsensitiveRegex("{0}");
    }

    public static BsonRegularExpression GetCaseInsensitiveRegex(this object value, string regexTemplate)
    {
        return new BsonRegularExpression(regexTemplate.FormatCurrentCulture(Regex.Escape(value.ToString()!)), "i");
    }
}
