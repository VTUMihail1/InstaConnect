using System.Linq.Expressions;

namespace InstaConnect.Common.Domain.Extensions;

public static class ExpressionExtensions
{
    public static string GetFullPropertyPath<T, TProperty>(this Expression<Func<T, TProperty>> expr)
    {
        var path = new List<string>();
        var current = expr.Body;

        while (current is MemberExpression member)
        {
            path.Add(member.Member.Name);
            current = member.Expression;
        }

        path.Reverse();

        return path.JoinAsStringWithDot();
    }
}
