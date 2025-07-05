namespace InstaConnect.Common.Abstractions;

public interface IApplicationMapper
{
    T Map<T>(object source);
}
