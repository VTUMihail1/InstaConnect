using InstaConnect.Common.Infrastructure;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure;
public class PostsContext : MongoDbContext, IPostsContext
{
    public PostsContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => ToCollection<User, UserId>(PostCollectionNames.Users);

    public IMongoCollection<Post> Posts => ToCollection<Post, PostId>(PostCollectionNames.Posts);

    public IMongoCollection<PostLike> PostLikes => ToCollection<PostLike, PostLikeId>(PostCollectionNames.PostLikes);

    public IMongoCollection<PostComment> PostComments => ToCollection<PostComment, PostCommentId>(PostCollectionNames.PostComments);

    public IMongoCollection<PostCommentLike> PostCommentLikes => ToCollection<PostCommentLike, PostCommentLikeId>(PostCollectionNames.PostCommentLikes);
}
