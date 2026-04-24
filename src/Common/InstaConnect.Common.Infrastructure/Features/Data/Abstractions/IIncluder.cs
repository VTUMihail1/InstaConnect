using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

public interface IIncluder<TEntity, TIncludeType, TDestinationType>
    where TIncludeType : Enum
    where TDestinationType : Enum
{
    TDestinationType DestinationType { get; }

    TIncludeType IncludeType { get; }

    IAggregateFluent<TEntity> Include(IAggregateFluent<TEntity> aggregate);
}
