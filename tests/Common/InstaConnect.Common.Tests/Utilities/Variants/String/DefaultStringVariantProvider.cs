namespace InstaConnect.Common.Tests.Utilities.Variants.String;

internal class DefaultStringVariantProvider : IStringVariantProvider
{
    public StringVariantType Type => StringVariantType.Default;

    public string GetVariant(string? value)
    {
        return value;
    }
}

