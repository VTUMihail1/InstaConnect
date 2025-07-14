namespace InstaConnect.Common.Tests.Utilities.Variants.String;

internal class DifferentCaseStringVariantProvider : IStringVariantProvider
{
    public StringVariantType Type => StringVariantType.DifferentCaseString;

    public string GetVariant(string? value)
    {
        var result = DataFaker.GetDifferentCaseString(value);

        return result;
    }
}

