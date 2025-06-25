namespace InstaConnect.Common.Abstractions;

public interface IApplicationMapper
{
    void Map(object source, object destination);

    T Map<T>(object source);
}
