namespace InstaConnect.Common.Tests.Utilities.Variants.String;

internal class PrefixStringVariantProvider : IStringVariantProvider
{
    public StringVariantType Type => StringVariantType.Prefix;

    public string GetVariant(string? value)
    {
        var result = DataFaker.GetPrefixString(value);

        return result;
    }
}

