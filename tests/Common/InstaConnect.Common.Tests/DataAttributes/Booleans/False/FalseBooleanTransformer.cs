using InstaConnect.Common.Tests.DataAttributes.Booleans.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Booleans.False;

internal class FalseBooleanTransformer : IBooleanTransformer
{
    public bool Transform(bool value)
    {
        return false;
    }
}

