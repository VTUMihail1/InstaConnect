using InstaConnect.Common.Infrastructure;
using InstaConnect.Follows.Infrastructure.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure;

public class FollowsContext : MongoDbContext, IFollowsContext
{
    public FollowsContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => ToCollection<User, UserId>(FollowsCollectionNames.Users);

    public IMongoCollection<Follow> Follows => ToCollection<Follow, FollowId>(FollowsCollectionNames.Follows);
}
