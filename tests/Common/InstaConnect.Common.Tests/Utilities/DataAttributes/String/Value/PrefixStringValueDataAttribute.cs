using InstaConnect.Common.Tests.Utilities.Variants.String;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.String.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PrefixStringValueDataAttribute : StringValueDataAttribute
{
    public PrefixStringValueDataAttribute() : base(StringVariantType.Prefix)
    {
    }
}

