using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers;
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
