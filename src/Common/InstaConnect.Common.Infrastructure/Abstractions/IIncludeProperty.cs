using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IIncludeProperty<TEntity>
{
    IAggregateFluent<TEntity> Include(IAggregateFluent<TEntity> pipeline);
}
