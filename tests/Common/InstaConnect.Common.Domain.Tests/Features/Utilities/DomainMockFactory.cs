using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Common.Domain.Tests.Features.Utilities;

public static class DomainMockFactory
{
	public static IEventPublisher CreateEventPublisher()
	{
		return Mocker.Mock<IEventPublisher>();
	}

	public static IGuidProvider CreateGuidProvider()
	{
		return Mocker.Mock<IGuidProvider>();
	}

	public static IDateTimeProvider CreateDateTimeProvider()
	{
		return Mocker.Mock<IDateTimeProvider>();
	}
}
