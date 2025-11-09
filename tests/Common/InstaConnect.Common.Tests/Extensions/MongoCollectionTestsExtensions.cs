using MongoDB.Driver;

namespace InstaConnect.Common.Tests.Extensions;
public static class MongoCollectionTestsExtensions
{
    public static async Task ResetAsync<TDocument>(
            this IMongoCollection<TDocument> collection,
            CancellationToken cancellationToken = default)
    {
        await collection.DeleteManyAsync(FilterDefinition<TDocument>.Empty, cancellationToken);
    }
}
