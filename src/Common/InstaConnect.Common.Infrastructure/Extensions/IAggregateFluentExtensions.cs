using System.Linq.Expressions;

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
        var tempPipeline = pipeline;

        foreach (var include in includes)
        {
            tempPipeline = include.Include(tempPipeline);
        }

        return tempPipeline;
    }

    public static IAggregateFluent<TEntity> IncludeMany<TEntity, TForeignEntity>(
            this IAggregateFluent<TEntity> pipeline,
            IMongoCollection<TForeignEntity> foreignCollection,
            Expression<Func<TEntity, object>> localField,
            Expression<Func<TForeignEntity, object>> foreignField,
            Expression<Func<TEntity, object>> @as)
    {
        return pipeline.Lookup(foreignCollection,
                               localField,
                               foreignField,
                               @as);
    }

    public static IAggregateFluent<TEntity> IncludeOne<TEntity, TForeignEntity>(
            this IAggregateFluent<TEntity> pipeline,
            IMongoCollection<TForeignEntity> foreignCollection,
            Expression<Func<TEntity, object>> localField,
            Expression<Func<TForeignEntity, object>> foreignField,
            Expression<Func<TEntity, object>> @as)
    {
        return pipeline.IncludeMany(foreignCollection,
                               localField,
                               foreignField,
                               @as)
                       .Unwind(@as, new AggregateUnwindOptions<TEntity>() { PreserveNullAndEmptyArrays = true });
    }
}
