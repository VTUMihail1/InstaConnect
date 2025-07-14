using InstaConnect.Common.Tests.Utilities.Variants.String;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.String.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class EmptyStringValueDataAttribute : StringValueDataAttribute
{
    public EmptyStringValueDataAttribute() : base(StringVariantType.Empty)
    {
    }
}

