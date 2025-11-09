using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class ValueIntWithMessageDataAttribute : IntWithMessageDataAttribute
{
    protected ValueIntWithMessageDataAttribute(int value, string message) : base(new ValueIntTransformer(value), message)
    {
    }
}
