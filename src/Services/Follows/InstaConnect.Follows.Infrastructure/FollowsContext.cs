using InstaConnect.Common.Infrastructure;
using InstaConnect.FollowCommentLikes.Domain.Features.FollowCommentLikes.Models.Entities;
using InstaConnect.FollowComments.Domain.Features.FollowComments.Models.Entities;
using InstaConnect.FollowLikes.Domain.Features.FollowLikes.Models.Entities;
using InstaConnect.Follows.Infrastructure.Abstractions;
using InstaConnect.Follows.Infrastructure.Utilities;

using MongoDB.Driver;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.FollowMessages.Domain.Features.FollowMessages.Models.Entities;

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
