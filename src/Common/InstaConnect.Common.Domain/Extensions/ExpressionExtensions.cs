using System.Linq.Expressions;

namespace InstaConnect.Common.Domain.Extensions;

public static class ExpressionExtensions
{
    public static string GetProperty<T, TProperty>(this Expression<Func<T, TProperty>> expr)
    {
        return (expr.Body as MemberExpression)?.Member.Name.ToSpaceBetweenWordsCase() ?? string.Empty;
    }
}
