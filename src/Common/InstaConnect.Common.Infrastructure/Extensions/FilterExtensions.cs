using System.Linq.Expressions;

using InstaConnect.Common.Domain.Models.ValueObjects;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class FilterExtensions
{
    public static FilterDefinition<T> EqualsCaseInsensitive<T>(
        this FilterDefinitionBuilder<T> builder,
        Expression<Func<T, object>> field,
        object value,
        bool isEmpty = false)
    {
        if (isEmpty)
        {
            return builder.Empty;
        }

        return builder.Regex(field, value.GetEqualsCaseInsensitiveRegex());
    }

    public static FilterDefinition<T> StartsWithCaseInsensitive<T>(
        this FilterDefinitionBuilder<T> builder,
        Expression<Func<T, object>> field,
        object value,
        bool isEmpty = false)
    {
        if (isEmpty)
        {
            return builder.Empty;
        }

        return builder.Regex(field, value.GetStartsWithCaseInsensitiveRegex());
    }

    public static FilterDefinition<T> EndsWithCaseInsensitive<T>(
        this FilterDefinitionBuilder<T> builder,
        Expression<Func<T, object>> field,
        object value,
        bool isEmpty = false)
    {
        if (isEmpty)
        {
            return builder.Empty;
        }

        return builder.Regex(field, value.GetEndsWithCaseInsensitiveRegex());
    }

    public static FilterDefinition<T> ContainsCaseInsensitive<T>(
        this FilterDefinitionBuilder<T> builder,
        Expression<Func<T, object>> field,
        object value,
        bool isEmpty = false)
    {
        if (isEmpty)
        {
            return builder.Empty;
        }

        return builder.Regex(field, value.GetContainsCaseInsensitiveRegex());
    }

    public static FilterDefinition<T> InCaseInsensitive<T>(
        this FilterDefinitionBuilder<T> builder,
        Expression<Func<T, object>> field,
        IEnumerable<object> values,
        bool isEmpty = false)
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

    public static FilterDefinition<T> GetFilterForNameEquals<T>(
        this Name filter,
        Expression<Func<T, object>> nameField)
    {
        return Builders<T>.Filter
            .EqualsCaseInsensitive(nameField, filter.Value, filter.IsEmpty());
    }

    public static FilterDefinition<T> GetFilterForNameStartsWith<T>(
        this Name filter,
        Expression<Func<T, object>> nameField)
    {
        return Builders<T>.Filter
            .StartsWithCaseInsensitive(nameField, filter.Value, filter.IsEmpty());
    }

    public static FilterDefinition<T> GetFilterForEmailEquals<T>(
        this Email filter,
        Expression<Func<T, object>> emailField)
    {
        return Builders<T>.Filter
            .EqualsCaseInsensitive(emailField, filter.Value, filter.IsEmpty());
    }
}
