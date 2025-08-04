using InstaConnect.Common.Tests.DataAttributes.Strings.Empty;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyStringDataAttribute : StringDataAttribute
{
    protected EmptyStringDataAttribute() : base(new EmptyStringTransformer())
    {

    }
}
