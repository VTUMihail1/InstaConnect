using InstaConnect.Common.Tests.Utilities.DataAttributes.String.Value;
using InstaConnect.Common.Tests.Utilities.Variants.Int;
using InstaConnect.Common.Tests.Utilities.Variants.String;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Int.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class DefaultIntValueDataAttribute : IntValueDataAttribute
{
    public DefaultIntValueDataAttribute() : base(IntVariantType.Default)
    {
    }
}

