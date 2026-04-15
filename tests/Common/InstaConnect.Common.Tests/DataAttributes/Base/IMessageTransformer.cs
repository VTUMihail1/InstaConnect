using System.Linq.Expressions;

namespace InstaConnect.Common.Tests.DataAttributes.Base;

public interface IMessageTransformer<TValue>
{
    public string Transform<T>(Expression<Func<T, TValue>> propertyExpression, TValue value);
}
