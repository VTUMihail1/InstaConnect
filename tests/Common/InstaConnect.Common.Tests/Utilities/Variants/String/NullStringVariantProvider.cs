namespace InstaConnect.Common.Tests.Utilities.Variants.String;

internal class NullStringVariantProvider : IStringVariantProvider
{
    public StringVariantType Type => StringVariantType.Null;

    public string GetVariant(string? value)
    {
        return null!;
    }
}

