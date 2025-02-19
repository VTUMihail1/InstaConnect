namespace InstaConnect.Shared.Infrastructure.Helpers;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetUtcNow()
    {
        var currentDateTime = DateTime.UtcNow;

        return currentDateTime;
    }

    public DateTime GetUtcNow(int seconds)
    {
        var currentDateTime = DateTime.UtcNow.AddSeconds(seconds);

        return currentDateTime;
    }
}
