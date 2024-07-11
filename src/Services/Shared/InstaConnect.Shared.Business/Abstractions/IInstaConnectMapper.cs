namespace InstaConnect.Shared.Business.Abstractions;

public interface IInstaConnectMapper
{
    void Map(object source, object destination);
    T Map<T>(object source);
}