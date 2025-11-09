using InstaConnect.Common.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class IAggregateFluentExtensions
{
    public static IAggregateFluent<TEntity> Includes<TEntity, TIncludeProperty>(
        this IAggregateFluent<TEntity> pipeline,
        IEnumerable<TIncludeProperty> includes)
        where TIncludeProperty : IIncludeProperty<TEntity>
    {
        foreach (var include in includes)
        {
            include.Include(pipeline);
        }

        return pipeline;
    }
}
