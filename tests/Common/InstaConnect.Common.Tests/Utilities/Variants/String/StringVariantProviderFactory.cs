using InstaConnect.Common.Extensions;
using InstaConnect.Common.Tests.Extensions;

namespace InstaConnect.Common.Tests.Utilities.Variants.String;

public class StringVariantProviderFactory
{
    private readonly IEnumerable<IStringVariantProvider> _stringVariantProviders;

    public StringVariantProviderFactory()
    {
        _stringVariantProviders = CommonTestReference
            .Assembly
            .AddImplementationOf<IStringVariantProvider>();
    }

    public IStringVariantProvider Create(StringVariantType type)
    {
        var provider = _stringVariantProviders.First(p => p.Type == type);

        return provider;
    }
}
