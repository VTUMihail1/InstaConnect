using InstaConnect.Common.Tests.Utilities.Types.DateTimeOffsets.Base;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.DateTimeOffsets.Default;

internal class DefaultDateTimeOffsetTransformer : IDateTimeOffsetTransformer
{
    public DateTimeOffset Transform(DateTimeOffset value)
    {
        return value;
    }
}

