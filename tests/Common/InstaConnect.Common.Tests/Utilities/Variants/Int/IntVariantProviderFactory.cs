using InstaConnect.Common.Extensions;
using InstaConnect.Common.Tests.Extensions;

namespace InstaConnect.Common.Tests.Utilities.Variants.Int;

public class IntVariantProviderFactory
{
    private readonly IEnumerable<IIntVariantProvider> _intVariantProviders;

    public IntVariantProviderFactory()
    {
        _intVariantProviders = CommonTestReference
            .Assembly
            .AddImplementationOf<IIntVariantProvider>();
    }

    public IIntVariantProvider Create(IntVariantType Type)
    {
        var provider = _intVariantProviders.First(p => p.Type == Type);

        return provider;
    }
}
