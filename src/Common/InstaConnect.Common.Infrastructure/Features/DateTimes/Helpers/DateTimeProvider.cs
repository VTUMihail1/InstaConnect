using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.DateTimes.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
	public DateTimeOffset GetOffsetUtcNow()
	{
		return DateTimeOffset.UtcNow;
	}

	public DateTimeOffset GetOffsetUtcNow(int seconds)
	{
		return DateTimeOffset.UtcNow.AddSeconds(seconds);
	}

	public DateTime GetUtcNow()
	{
		return DateTime.UtcNow;
	}

	public DateTime GetUtcNow(int seconds)
	{
		return DateTime.UtcNow.AddSeconds(seconds);
	}
}
