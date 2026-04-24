namespace InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

public interface IDateTimeProvider
{
    public DateTime GetUtcNow();

    public DateTime GetUtcNow(int seconds);

    public DateTimeOffset GetOffsetUtcNow();

    public DateTimeOffset GetOffsetUtcNow(int seconds);
}
