using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Shared.Infrastructure.Helpers;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetCurrentUtc()
    {
        var currentDateTime = DateTime.Now;

        return currentDateTime;
    }

    public DateTime GetCurrentUtc(int seconds)
    {
        var currentDateTimeWithSecondsAhead = DateTime.UtcNow.AddSeconds(seconds);

        return currentDateTimeWithSecondsAhead;
    }
}
