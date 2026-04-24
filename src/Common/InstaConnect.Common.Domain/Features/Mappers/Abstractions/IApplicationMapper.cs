namespace InstaConnect.Common.Domain.Features.Mappers.Abstractions;

public interface IApplicationMapper
{
    T Map<T>(object source);
}
