using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Prefix;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PrefixStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected PrefixStringWithMessageDataAttribute(string message) : base(new PrefixStringTransformer(), message)
    {
    }
}
