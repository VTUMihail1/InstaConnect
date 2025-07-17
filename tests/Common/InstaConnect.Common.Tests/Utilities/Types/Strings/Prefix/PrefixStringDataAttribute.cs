using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Prefix;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PrefixStringDataAttribute : StringDataAttribute
{
    protected PrefixStringDataAttribute() : base(new PrefixStringTransformer())
    {

    }
}
