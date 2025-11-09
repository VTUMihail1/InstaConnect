using InstaConnect.Common.Infrastructure;
using InstaConnect.Follows.Infrastructure.Abstractions;
using InstaConnect.Follows.Infrastructure.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure;
public class FollowsContext : MongoDbContext, IFollowsContext
{
    public FollowsContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => Collection<User>(FollowCollectionNames.Users);

    public IMongoCollection<Follow> Follows => Collection<Follow>(FollowCollectionNames.Follows);
}
