using InstaConnect.Common.Tests.DataAttributes.Strings.Prefix;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Prefix;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Prefix;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PrefixStringDataAttribute : StringDataAttribute
{
    protected PrefixStringDataAttribute() : base(new PrefixStringTransformer())
    {

    }
}
