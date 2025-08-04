using InstaConnect.Common.Tests.Utilities.DataAttributes.DateTimeOffsets.Base;
using InstaConnect.Common.Tests.Utilities.Types.DateTimeOffsets.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.DateTimeOffsets.Default;

internal class DefaultDateTimeOffsetTransformer : IDateTimeOffsetTransformer
{
    public DateTimeOffset Transform(DateTimeOffset value)
    {
        return value;
    }
}

