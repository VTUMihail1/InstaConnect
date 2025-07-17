using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected EmptyStringWithMessageDataAttribute(string message) : base(new EmptyStringTransformer(), message)
    {
    }
}
