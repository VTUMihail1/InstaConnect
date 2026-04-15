using System.Text.RegularExpressions;

using InstaConnect.Common.Domain.Extensions;

using MongoDB.Bson;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class BsonRegularExpressionExtensions
{
    extension(object value)
    {
        public BsonRegularExpression GetEqualsCaseInsensitiveRegex()
        {
            return value.GetCaseInsensitiveRegex("^{0}$");
        }

        public BsonRegularExpression GetStartsWithCaseInsensitiveRegex()
        {
            return value.GetCaseInsensitiveRegex("^{0}");
        }

        public BsonRegularExpression GetEndsWithCaseInsensitiveRegex()
        {
            return value.GetCaseInsensitiveRegex("{0}$");
        }

        public BsonRegularExpression GetContainsCaseInsensitiveRegex()
        {
            return value.GetCaseInsensitiveRegex("{0}");
        }

        public BsonRegularExpression GetCaseInsensitiveRegex(string regexTemplate)
        {
            return new BsonRegularExpression(regexTemplate.FormatCurrentCulture(Regex.Escape(value.ToString()!)), "i");
        }
    }
}
