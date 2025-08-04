using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.DifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DifferentCaseStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected DifferentCaseStringWithMessageDataAttribute(string message) : base(new DifferentCaseStringTransformer(), message)
    {
    }
}
