using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

public interface IIncluder<TEntity, TIncludeType, TDestinationType>
	where TIncludeType : Enum
	where TDestinationType : Enum
{
	public TDestinationType DestinationType { get; }

	public TIncludeType IncludeType { get; }

	public IAggregateFluent<TEntity> Include(IAggregateFluent<TEntity> aggregate);
}
