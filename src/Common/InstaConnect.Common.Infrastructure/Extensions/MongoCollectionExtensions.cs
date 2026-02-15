using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class MongoCollectionExtensions
{
    public static IAggregateFluent<T> AggregateWithCaseInsensitiveCollation<T>(
        this IMongoCollection<T> collection)
    {
        var options = new AggregateOptions
        {
            Collation = new Collation("en", strength: CollationStrength.Primary)
        };

        return collection.Aggregate(options);
    }

    public static async Task AddAsync<T>(
        this IMongoCollection<T> collection,
        IClientSessionHandle? session,
        T entity,
        CancellationToken cancellationToken)
    {
        if (session.IsNotInTransaction())
        {
            await collection.InsertOneAsync(entity, null, cancellationToken);

            return;
        }

        await collection.InsertOneAsync(session, entity, null, cancellationToken);
    }

    public static async Task AddRangeAsync<T>(
        this IMongoCollection<T> collection,
        IClientSessionHandle? session,
        IEnumerable<T> entities,
        CancellationToken cancellationToken)
    {
        if (session.IsNotInTransaction())
        {
            await collection.InsertManyAsync(entities, null, cancellationToken);

            return;
        }

        await collection.InsertManyAsync(session, entities, null, cancellationToken);
    }

    public static async Task UpdateAsync<T>(
        this IMongoCollection<T> collection,
        IClientSessionHandle? session,
        FilterDefinition<T> filter,
        T entity,
        CancellationToken cancellationToken)
    {
        var options = new ReplaceOptions { IsUpsert = false };

        if (session.IsNotInTransaction())
        {
            await collection.ReplaceOneAsync(filter, entity, options, cancellationToken);

            return;
        }

        await collection.ReplaceOneAsync(session, filter, entity, options, cancellationToken);
    }

    public static async Task DeleteAsync<T>(
        this IMongoCollection<T> collection,
        IClientSessionHandle? session,
        FilterDefinition<T> filter,
        CancellationToken cancellationToken)
    {
        if (session.IsNotInTransaction())
        {
            await collection.DeleteOneAsync(filter, null, cancellationToken);

            return;
        }

        await collection.DeleteOneAsync(session, filter, null, cancellationToken);
    }

    public static async Task DeleteRangeAsync<T>(
        this IMongoCollection<T> collection,
        IClientSessionHandle? session,
        FilterDefinition<T> filter,
        CancellationToken cancellationToken)
    {
        if (session.IsNotInTransaction())
        {
            await collection.DeleteManyAsync(filter, null, cancellationToken);
            return;
        }

        await collection.DeleteManyAsync(session, filter, null, cancellationToken);
    }
}
