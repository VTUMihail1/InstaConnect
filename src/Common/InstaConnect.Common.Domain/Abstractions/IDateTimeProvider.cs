namespace InstaConnect.Common.Domain.Abstractions;
public interface IDateTimeProvider
{
    public DateTimeOffset GetOffsetUtcNow();

    public DateTimeOffset GetOffsetUtcNow(int seconds);
}
