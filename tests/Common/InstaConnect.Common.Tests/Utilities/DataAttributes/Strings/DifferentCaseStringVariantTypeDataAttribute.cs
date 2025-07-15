using InstaConnect.Common.Tests.Utilities.Variants.String;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.String;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class DifferentCaseStringVariantTypeDataAttribute : StringVariantTypeDataAttribute
{
    public DifferentCaseStringVariantTypeDataAttribute() : base(StringVariantType.DifferentCaseString)
    {
    }
}

