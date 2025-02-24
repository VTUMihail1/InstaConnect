namespace InstaConnect.Shared.Infrastructure.Helpers;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset GetUtcNow()
    {
        var currentDateTime = DateTimeOffset.UtcNow;

        return currentDateTime;
    }

    public DateTimeOffset GetUtcNow(int seconds)
    {
        var currentDateTime = DateTimeOffset.UtcNow.AddSeconds(seconds);

        return currentDateTime;
    }
}
