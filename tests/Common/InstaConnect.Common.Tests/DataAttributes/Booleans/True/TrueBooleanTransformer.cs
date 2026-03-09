using InstaConnect.Common.Tests.DataAttributes.Booleans.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Booleans.True;

internal class TrueBooleanTransformer : IBooleanTransformer
{
    public bool Transform(bool value)
    {
        return true;
    }
}

