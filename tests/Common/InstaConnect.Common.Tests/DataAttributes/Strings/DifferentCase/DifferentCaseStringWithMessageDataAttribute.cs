using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.DifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DifferentCaseStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected DifferentCaseStringWithMessageDataAttribute(string message) : base(new DifferentCaseStringTransformer(), message)
    {
    }
}
