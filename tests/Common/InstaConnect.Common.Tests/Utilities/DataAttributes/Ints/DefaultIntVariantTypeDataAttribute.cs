using InstaConnect.Common.Tests.Utilities.DataAttributes.String.Value;
using InstaConnect.Common.Tests.Utilities.Variants.Int;
using InstaConnect.Common.Tests.Utilities.Variants.String;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Int;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class DefaultIntVariantTypeDataAttribute : IntVariantTypeDataAttribute
{
    public DefaultIntVariantTypeDataAttribute() : base(IntVariantType.Default)
    {
    }
}

