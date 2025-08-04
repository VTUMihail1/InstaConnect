using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected DefaultStringWithMessageDataAttribute(string message) : base(new DefaultStringTransformer(), message)
    {
    }
}
