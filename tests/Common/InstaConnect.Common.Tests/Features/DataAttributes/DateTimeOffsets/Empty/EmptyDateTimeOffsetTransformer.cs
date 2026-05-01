using InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Empty;

internal class EmptyDateTimeOffsetTransformer : IDateTimeOffsetTransformer
{
	public DateTimeOffset Transform(DateTimeOffset value)
	{
		return DateTimeOffset.MinValue;
	}
}

