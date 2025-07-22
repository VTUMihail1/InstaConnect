using InstaConnect.Common.Tests.Utilities.Types.DateTimes.Base;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums.Default;

internal class DefaultDateTimeOffsetTransformer : IDateTimeOffsetTransformer
{
    public DateTimeOffset Transform(DateTimeOffset value)
    {
        return value;
    }
}

