using InstaConnect.Common.Domain.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class MongoCollectionExtensions
{
    extension<T>(IMongoCollection<T> collection)
        where T : IEntity
    {
        public IAggregateFluent<T> AggregateWithCaseInsensitiveCollation()
        {
            var options = new AggregateOptions
            {
                Collation = new Collation("en", strength: CollationStrength.Primary)
            };

            return collection.Aggregate(options);
        }

        public async Task AddAsync(IClientSessionHandle? session, T entity, CancellationToken cancellationToken)
        {
            if (session.IsNotInTransaction())
            {
                await collection.InsertOneAsync(entity, null, cancellationToken);
                return;
            }

            await collection.InsertOneAsync(session, entity, null, cancellationToken);
        }

        public async Task AddRangeAsync(IClientSessionHandle? session, IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            if (session.IsNotInTransaction())
            {
                await collection.InsertManyAsync(entities, null, cancellationToken);
                return;
            }

            await collection.InsertManyAsync(session, entities, null, cancellationToken);
        }

        public async Task UpdateAsync(IClientSessionHandle? session, FilterDefinition<T> filter, T entity, CancellationToken cancellationToken)
        {
            var options = new ReplaceOptions { IsUpsert = false };

            if (session.IsNotInTransaction())
            {
                await collection.ReplaceOneAsync(filter, entity, options, cancellationToken);
                return;
            }

            await collection.ReplaceOneAsync(session, filter, entity, options, cancellationToken);
        }

        public async Task DeleteAsync(IClientSessionHandle? session, FilterDefinition<T> filter, CancellationToken cancellationToken)
        {
            if (session.IsNotInTransaction())
            {
                await collection.DeleteOneAsync(filter, null, cancellationToken);
                return;
            }

            await collection.DeleteOneAsync(session, filter, null, cancellationToken);
        }

        public async Task DeleteRangeAsync(IClientSessionHandle? session, FilterDefinition<T> filter, CancellationToken cancellationToken)
        {
            if (session.IsNotInTransaction())
            {
                await collection.DeleteManyAsync(filter, null, cancellationToken);
                return;
            }

            await collection.DeleteManyAsync(session, filter, null, cancellationToken);
        }
    }
}
