using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected EmptyStringWithMessageDataAttribute(string message) : base(new EmptyStringTransformer(), message)
    {
    }
}
