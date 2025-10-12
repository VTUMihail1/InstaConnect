using System.Linq.Expressions;

using InstaConnect.Common.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class MongoCollectionExtensions
{
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

    public static async Task UpdateAsync<T>(
        this IMongoCollection<T> collection,
        IClientSessionHandle? session,
        Expression<Func<T, bool>> filter,
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
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken)
    {
        if (session.IsNotInTransaction())
        {
            await collection.DeleteOneAsync(filter, null, cancellationToken);

            return;
        }

        await collection.DeleteOneAsync(session, filter, null, cancellationToken);
            
    }
}
