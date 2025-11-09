using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected NullStringWithMessageDataAttribute(string message) : base(new NullStringTransformer(), message)
    {
    }
}
