using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Common.Domain.Tests.Features.Assertions;

public static class MockAssertions
{
	extension(IGuidProvider guidProvider)
	{
		public void ShouldReceiveOneNewGuid()
		{
			guidProvider.ShouldHaveReceivedOne().NewGuid();
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldReceiveOneGetOffsetUtcNow()
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}
}
