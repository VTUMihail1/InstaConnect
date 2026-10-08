using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Common.Domain.Tests.Features.Utilities;

public static class MockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(string value)
		{
			guidProvider
				.NewStringGuid()
				.ReturnsResponse(value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(DateTimeOffset utcNow)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(utcNow);
		}

		public void SetupGetOffsetUtcNow(
			int seconds,
			DateTimeOffset utcNow)
		{
			dateTimeProvider
				.GetOffsetUtcNow(seconds)
				.ReturnsResponse(utcNow);
		}
	}
}
