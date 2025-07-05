using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset GetOffsetUtcNow()
    {
        var currentDateTime = DateTimeOffset.UtcNow;

        return currentDateTime;
    }

    public DateTimeOffset GetOffsetUtcNow(int seconds)
    {
        var currentDateTime = DateTimeOffset.UtcNow.AddSeconds(seconds);

        return currentDateTime;
    }
}
