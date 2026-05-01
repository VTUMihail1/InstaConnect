namespace InstaConnect.Common.Domain.Features.Mappers.Abstractions;

public interface IApplicationMapper
{
	public T Map<T>(object source);
}
