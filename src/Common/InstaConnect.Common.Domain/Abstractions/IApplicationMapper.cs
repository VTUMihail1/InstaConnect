namespace InstaConnect.Common.Domain.Abstractions;

public interface IApplicationMapper
{
    T Map<T>(object source);
}
