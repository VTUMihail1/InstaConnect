using System.Linq.Expressions;

using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Data.Extensions;

public static class AggregateFluentExtensions
{
    extension<TEntity>(IAggregateFluent<TEntity> fluent)
        where TEntity : IEntity
    {
        public async Task<long> GetCount(CancellationToken cancellationToken)
        {
            var result = await fluent
                               .Count()
                               .FirstOrDefaultAsync(cancellationToken);

            return result?.Count ?? default;
        }

        public IAggregateFluent<TEntity> IncludeMany<TForeignEntity, TKey>(
            IMongoCollection<TForeignEntity> foreignCollection,
            Expression<Func<TEntity, TKey>> entityKey,
            Expression<Func<TForeignEntity, TKey>> foreignEntityKey,
            Expression<Func<TEntity, ICollection<TForeignEntity>>> destination)
            where TForeignEntity : IEntity
            where TKey : IEntityId
        {
            return fluent.Lookup(foreignCollection,
                                 entityKey.Box(),
                                 foreignEntityKey.Box(),
                                 destination.Box());
        }

        public IAggregateFluent<TEntity> IncludeOne<TForeignEntity, TKey>(
            IMongoCollection<TForeignEntity> foreignCollection,
            Expression<Func<TEntity, TKey>> entityKey,
            Expression<Func<TForeignEntity, TKey>> foreignEntityKey,
            Expression<Func<TEntity, TForeignEntity>> destination)
            where TForeignEntity : IEntity
            where TKey : IEntityId
        {
            return fluent.Lookup(foreignCollection,
                                 entityKey.Box(),
                                 foreignEntityKey.Box(),
                                 destination.Box())
                         .Unwind(destination.Box(), new AggregateUnwindOptions<TEntity>() { PreserveNullAndEmptyArrays = true });
        }

        public IAggregateFluent<TEntity> Includes<TDestinationType, TIncludeType, TIncludeDescriptor, TInclude, TIncluder>(
            IIncluderFactory<TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder, TEntity> includerFactory,
            TInclude? include)
            where TDestinationType : Enum
            where TIncludeType : Enum
            where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
            where TInclude : IInclude<TDestinationType, TIncludeType, TIncludeDescriptor>
            where TIncluder : IIncluder<TEntity, TIncludeType, TDestinationType>
        {
            var descriptors = includerFactory.Create(include?.Descriptors);
            var tempPipeline = fluent;

            foreach (var descriptor in descriptors)
            {
                tempPipeline = descriptor.Include(tempPipeline);
            }

            return tempPipeline;
        }
    }

    extension<TEntityResponse>(IAggregateFluent<TEntityResponse> fluent)
        where TEntityResponse : IEntityResponse
    {
        public IAggregateFluent<TEntityResponse> Sort<TSortTerm, TSortTermer, TSortingQuery>(
            ISortOrdererFactory sortOrdererFactory,
            ISortTermerFactory<TSortTerm, TSortTermer, TEntityResponse> sortTermerFactory,
            TSortingQuery sorting)
            where TSortingQuery : ISortingQuery<TSortTerm>
            where TSortTerm : Enum
            where TSortTermer : ISortTermer<TSortTerm, TEntityResponse>
        {
            var order = sortOrdererFactory.Create(sorting.Order);
            var term = sortTermerFactory.Create(sorting.Term);

            return fluent.Sort(Builders<TEntityResponse>.Sort.Combine(order.Sort(term.Term), order.Sort<TEntityResponse>(a => a.CreatedAtUtc)));
        }

        public IAggregateFluent<TEntityResponse> Paginate<TPaginationQuery>(IPaginator paginator, TPaginationQuery pagination)
            where TPaginationQuery : IPaginationQuery
        {
            var offset = paginator.GetOffset(pagination.Page, pagination.PageSize);

            return fluent
                .Skip(offset)
                .Limit(pagination.PageSize);
        }
    }
}
