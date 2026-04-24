using System.Linq.Expressions;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class ExpressionExtensions
{
    extension<T, TProperty>(Expression<Func<T, TProperty>> expr)
    {
        public string GetProperty()
        {
            return (expr.Body as MemberExpression)?.Member.Name
                   .ToSpaceBetweenWordsCase() ?? string.Empty;
        }

        public Expression<Func<T, object>> Box()
        {
            return Expression.Lambda<Func<T, object>>(
                Expression.Convert(expr.Body, typeof(object)),
                expr.Parameters);
        }
    }
}
