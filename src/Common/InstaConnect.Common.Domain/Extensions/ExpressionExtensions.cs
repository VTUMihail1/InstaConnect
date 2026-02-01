using System.Linq.Expressions;

namespace InstaConnect.Common.Domain.Extensions;

public static class ExpressionExtensions
{
    public static string GetProperty<T, TProperty>(this Expression<Func<T, TProperty>> expr)
    {
        return (expr.Body as MemberExpression)?.Member.Name.ToSpaceBetweenWordsCase() ?? string.Empty;
    }

    public static Expression<Func<T, object>> Box<T, TProperty>(this Expression<Func<T, TProperty>> expr)
    {
        return Expression.Lambda<Func<T, object>>(Expression.Convert(expr.Body, typeof(object)), expr.Parameters);
    }
}
