namespace InstaConnect.Common.Tests.Utilities.Variants.String;

internal class EmptyStringVariantProvider : IStringVariantProvider
{
    public StringVariantType Type => StringVariantType.Empty;

    public string GetVariant(string? value)
    {
        return string.Empty;
    }
}

