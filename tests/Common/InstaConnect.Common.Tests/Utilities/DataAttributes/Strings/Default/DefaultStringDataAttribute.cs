using InstaConnect.Common.Tests.DataAttributes.Strings.Default;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Default;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultStringDataAttribute : StringDataAttribute
{
    protected DefaultStringDataAttribute() : base(new DefaultStringTransformer())
    {

    }
}
