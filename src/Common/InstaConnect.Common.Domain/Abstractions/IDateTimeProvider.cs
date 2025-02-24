namespace InstaConnect.Shared.Application.Abstractions;
public interface IDateTimeProvider
{
    public DateTimeOffset GetUtcNow();

    public DateTimeOffset GetUtcNow(int seconds);
}
