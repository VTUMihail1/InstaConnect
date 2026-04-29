using InstaConnect.Common.Infrastructure.Features.Data.Helpers;
using InstaConnect.Follows.Infrastructure.Features.Common.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Common.Helpers;

internal class FollowsContext : MongoDbContext, IFollowsContext
{
	public FollowsContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
		: base(mongoClient, mongoDatabase)
	{
	}

	public IMongoCollection<User> Users => ToCollection<User, UserId>(FollowsCollectionNames.Users);

	public IMongoCollection<Follow> Follows => ToCollection<Follow, FollowId>(FollowsCollectionNames.Follows);
}
