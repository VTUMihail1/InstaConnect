using System.Linq.Expressions;

using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class AggregateFluentExtensions
{
    public static IAggregateFluent<TEntity> Paginate<TEntity, TPaginationQuery>(
        this IAggregateFluent<TEntity> aggregate,
        IPaginator paginator,
        TPaginationQuery pagination)
        where TPaginationQuery : IPaginationQuery
    {
        var offset = paginator.GetOffset(pagination.Page, pagination.PageSize);

        return aggregate
            .Skip(offset)
            .Limit(pagination.PageSize);
    }

    public static IAggregateFluent<TEntity> Sort<TEntity, TSortTerm, TSortTermer, TSortingQuery>(
        this IAggregateFluent<TEntity> aggregate,
        ISortOrdererFactory sortOrdererFactory,
        ISortTermerFactory<TSortTerm, TSortTermer, TEntity> sortTermerFactory,
        TSortingQuery sorting)
        where TSortingQuery : ISortingQuery<TSortTerm>
        where TSortTerm : Enum
        where TSortTermer : ISortTermer<TSortTerm, TEntity>
    {
        var order = sortOrdererFactory.Create(sorting.Order);
        var term = sortTermerFactory.Create(sorting.Term);

        return aggregate.Sort(order.Sort(term.Term));
    }

    public static IAggregateFluent<TEntity> Includes<
        TEntity, TDestinationType, TIncludeType, TIncludeDescriptor, TInclude, TIncluder>(
        this IAggregateFluent<TEntity> aggregate,
        IIncluderFactory<TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder, TEntity> includerFactory,
        TInclude? include)
        where TDestinationType : Enum
        where TIncludeType : Enum
        where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
        where TInclude : IInclude<TDestinationType, TIncludeType, TIncludeDescriptor>
        where TIncluder : IIncluder<TEntity, TIncludeType, TDestinationType>
    {
        var descriptors = includerFactory.Create(include?.Descriptors);
        var tempPipeline = aggregate;

        foreach (var includeProperty in descriptors)
        {
            tempPipeline = includeProperty.Include(tempPipeline);
        }

        return tempPipeline;
    }

    public static IAggregateFluent<TEntity> IncludeMany<TEntity, TForeignEntity, TKey>(
            this IAggregateFluent<TEntity> aggregate,
            IMongoCollection<TForeignEntity> foreignCollection,
            Expression<Func<TEntity, TKey>> entityKey,
            Expression<Func<TForeignEntity, TKey>> foreignEntityKey,
            Expression<Func<TEntity, ICollection<TForeignEntity>>> destination)
        where TEntity : IEntity
        where TForeignEntity : IEntity
        where TKey : IEntityId
    {
        return aggregate.Lookup(foreignCollection,
                                entityKey.Box(),
                                foreignEntityKey.Box(),
                                destination.Box());
    }

    public static IAggregateFluent<TEntity> IncludeOne<TEntity, TForeignEntity, TKey>(
            this IAggregateFluent<TEntity> aggregate,
            IMongoCollection<TForeignEntity> foreignCollection,
            Expression<Func<TEntity, TKey>> entityKey,
            Expression<Func<TForeignEntity, TKey>> foreignEntityKey,
            Expression<Func<TEntity, TForeignEntity>> destination)
        where TEntity : IEntity
        where TForeignEntity : IEntity
        where TKey : IEntityId
    {
        return aggregate.Lookup(foreignCollection,
                                     entityKey.Box(),
                                     foreignEntityKey.Box(),
                                     destination.Box())
                       .Unwind(destination.Box(), new AggregateUnwindOptions<TEntity>() { PreserveNullAndEmptyArrays = true });
    }
}
