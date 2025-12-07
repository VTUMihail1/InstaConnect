using InstaConnect.Common.Tests.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Common.Tests.DataAttributes.DateTimeOffsets.Empty;

internal class EmptyDateTimeOffsetTransformer : IDateTimeOffsetTransformer
{
    public DateTimeOffset Transform(DateTimeOffset value)
    {
        return DateTimeOffset.MinValue;
    }
}

