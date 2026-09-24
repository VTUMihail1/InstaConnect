using System.Text.RegularExpressions;

using MongoDB.Bson;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class BsonRegularExpressionExtensions
{
	extension(string value)
	{
		public BsonRegularExpression ToEqualsIgnoreCaseRegex()
		{
			return value.ToIgnoreCaseRegex("^{0}$");
		}

		public BsonRegularExpression ToStartsWithIgnoreCaseRegex()
		{
			return value.ToIgnoreCaseRegex("^{0}");
		}

		public BsonRegularExpression ToEndsWithIgnoreCaseRegex()
		{
			return value.ToIgnoreCaseRegex("{0}$");
		}

		public BsonRegularExpression ToContainsIgnoreCaseRegex()
		{
			return value.ToIgnoreCaseRegex("{0}");
		}

		public BsonRegularExpression ToIgnoreCaseRegex(string regexTemplate)
		{
			return new BsonRegularExpression(regexTemplate.FormatCurrentCulture(Regex.Escape(value)), "i");
		}
	}
}
