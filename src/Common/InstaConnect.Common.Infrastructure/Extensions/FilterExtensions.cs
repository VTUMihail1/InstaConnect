using System.Linq.Expressions;

using InstaConnect.Common.Domain.Models.ValueObjects;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class FilterExtensions
{
    extension<T>(FilterDefinitionBuilder<T> builder)
    {
        public FilterDefinition<T> EqualsCaseInsensitive(Expression<Func<T, object>> field, object value, bool isEmpty = false)
        {
            if (isEmpty)
            {
                return builder.Empty;
            }

            return builder.Regex(field, value.GetEqualsCaseInsensitiveRegex());
        }

        public FilterDefinition<T> StartsWithCaseInsensitive(Expression<Func<T, object>> field, object value, bool isEmpty = false)
        {
            if (isEmpty)
            {
                return builder.Empty;
            }

            return builder.Regex(field, value.GetStartsWithCaseInsensitiveRegex());
        }

        public FilterDefinition<T> EndsWithCaseInsensitive(Expression<Func<T, object>> field, object value, bool isEmpty = false)
        {
            if (isEmpty)
            {
                return builder.Empty;
            }

            return builder.Regex(field, value.GetEndsWithCaseInsensitiveRegex());
        }

        public FilterDefinition<T> ContainsCaseInsensitive(Expression<Func<T, object>> field, object value, bool isEmpty = false)
        {
            if (isEmpty)
            {
                return builder.Empty;
            }

            return builder.Regex(field, value.GetContainsCaseInsensitiveRegex());
        }

        public FilterDefinition<T> InCaseInsensitive(Expression<Func<T, object>> field, IEnumerable<object> values, bool isEmpty = false)
        {
            if (isEmpty)
            {
                return builder.Empty;
            }

            var patterns = values
                .Select(value => value.GetEqualsCaseInsensitiveRegex())
                .ToList();

            return builder.In(field, patterns);
        }
    }

    extension<T>(Name filter)
    {
        public FilterDefinition<T> GetFilterForNameEquals(Expression<Func<T, object>> nameField)
        {
            return Builders<T>.Filter
                .EqualsCaseInsensitive(nameField, filter.Value, filter.IsEmpty());
        }

        public FilterDefinition<T> GetFilterForNameStartsWith(Expression<Func<T, object>> nameField)
        {
            return Builders<T>.Filter
                .StartsWithCaseInsensitive(nameField, filter.Value, filter.IsEmpty());
        }
    }

    extension<T>(Email filter)
    {
        public FilterDefinition<T> GetFilterForEmailEquals(Expression<Func<T, object>> emailField)
        {
            return Builders<T>.Filter
                .EqualsCaseInsensitive(emailField, filter.Value, filter.IsEmpty());
        }
    }
}
