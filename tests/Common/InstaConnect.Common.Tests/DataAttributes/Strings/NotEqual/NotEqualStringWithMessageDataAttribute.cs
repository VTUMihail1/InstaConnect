using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.NotEqual;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NotEqualStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected NotEqualStringWithMessageDataAttribute(string equalPropertyName)
        : base(
            new NotEqualStringTransformer(),
            new NotEqualStringMessageTransformer(equalPropertyName)
        )
    {
    }
}
