using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Prefix;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PrefixStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected PrefixStringWithMessageDataAttribute(string message) : base(new PrefixStringTransformer(), message)
    {
    }
}
