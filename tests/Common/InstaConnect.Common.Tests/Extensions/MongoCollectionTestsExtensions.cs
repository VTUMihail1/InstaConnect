using MongoDB.Driver;

namespace InstaConnect.Common.Tests.Extensions;

public static class MongoCollectionTestsExtensions
{
    extension<TDocument>(IMongoCollection<TDocument> collection)
    {
        public async Task ResetAsync(CancellationToken cancellationToken = default)
        {
            await collection.DeleteManyAsync(d => true, cancellationToken);
        }
    }
}
