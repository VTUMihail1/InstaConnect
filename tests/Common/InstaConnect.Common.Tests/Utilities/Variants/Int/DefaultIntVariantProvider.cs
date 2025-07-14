namespace InstaConnect.Common.Tests.Utilities.Variants.Int;

internal class DefaultIntVariantProvider : IIntVariantProvider
{
    public IntVariantType Type => IntVariantType.Default;

    public int GetVariant(int value)
    {
        return value;
    }
}

