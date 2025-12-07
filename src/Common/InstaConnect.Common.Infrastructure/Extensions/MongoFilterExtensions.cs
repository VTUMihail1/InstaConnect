using System.Linq.Expressions;
using System.Text.RegularExpressions;

using MongoDB.Bson;
using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class MongoFilterExtensions
{
    public static FilterDefinition<T> AndEqualsCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        object value)
    {
        var regex = new BsonRegularExpression($"^{Regex.Escape(value.ToString()!)}$", "i");

        return Builders<T>.Filter.And(current, Builders<T>.Filter.Regex(field, regex));
    }

    public static FilterDefinition<T> OrEqualsCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        object value)
    {
        var regex = new BsonRegularExpression($"^{Regex.Escape(value.ToString()!)}$", "i");

        return Builders<T>.Filter.Or(current, Builders<T>.Filter.Regex(field, regex));
    }

    public static FilterDefinition<T> AndStartsWithCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        object value)
    {
        var regex = new BsonRegularExpression($"^{Regex.Escape(value.ToString()!)}", "i");

        return Builders<T>.Filter.And(current, Builders<T>.Filter.Regex(field, regex));
    }

    public static FilterDefinition<T> OrStartsWithCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        object value)
    {
        var regex = new BsonRegularExpression($"^{Regex.Escape(value.ToString()!)}", "i");

        return Builders<T>.Filter.Or(current, Builders<T>.Filter.Regex(field, regex));
    }

    public static FilterDefinition<T> AndEndsWithCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        object value)
    {
        var regex = new BsonRegularExpression($"{Regex.Escape(value.ToString()!)}$", "i");

        return Builders<T>.Filter.And(current, Builders<T>.Filter.Regex(field, regex));
    }

    public static FilterDefinition<T> AndContainsCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        object value)
    {
        var regex = new BsonRegularExpression(Regex.Escape(value.ToString()!), "i");

        return Builders<T>.Filter.And(current, Builders<T>.Filter.Regex(field, regex));
    }

    public static FilterDefinition<T> AndInCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        IEnumerable<object> values)
    {
        var patterns = values
            .Select(v => new BsonRegularExpression($"^{Regex.Escape(v.ToString()!)}$", "i"))
            .ToList();

        return Builders<T>.Filter.And(current, Builders<T>.Filter.In(field, patterns));
    }

    public static FilterDefinition<T> AndOptionalEqualsCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        bool isEmpty,
        object value)
    {
        if (isEmpty)
        {
            return current;
        }

        return current.AndEqualsCaseInsensitive(field, value);
    }

    public static FilterDefinition<T> AndOptionalStartsWithCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        bool isEmpty,
        object value)
    {
        if (isEmpty)
        {
            return current;
        }

        return current.AndStartsWithCaseInsensitive(field, value);
    }

    public static FilterDefinition<T> OrOptionalStartsWithCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        bool isEmpty,
        object value)
    {
        if (isEmpty)
        {
            return current;
        }

        return current.OrStartsWithCaseInsensitive(field, value);
    }

    public static FilterDefinition<T> AndOptionalEndsWithCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        bool isEmpty,
        object value)
    {
        if (isEmpty)
        {
            return current;
        }

        return current.AndEndsWithCaseInsensitive(field, value);
    }

    public static FilterDefinition<T> AndOptionalContainsCaseInsensitive<T>(
        this FilterDefinition<T> current,
        Expression<Func<T, object>> field,
        bool isEmpty,
        object value)
    {
        if (isEmpty)
        {
            return current;
        }

        return current.AndContainsCaseInsensitive(field, value);
    }
}
