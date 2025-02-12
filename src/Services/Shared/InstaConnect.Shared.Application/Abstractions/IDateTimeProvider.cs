namespace InstaConnect.Shared.Application.Abstractions;
public interface IDateTimeProvider
{
    public DateTime GetCurrentUtc();

    public DateTime GetCurrentUtc(int seconds);
}
