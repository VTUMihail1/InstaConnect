using InstaConnect.Common.Tests.Features.DataAttributes.Booleans.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.True;

internal class TrueBooleanTransformer : IBooleanTransformer
{
    public bool Transform(bool value)
    {
        return true;
    }
}

