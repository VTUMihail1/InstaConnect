using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Length;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class LengthStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected LengthStringWithMessageDataAttribute(int value, string message) : base(new LengthStringTransformer(value), message)
    {
    }
}
