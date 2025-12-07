using InstaConnect.Common.Infrastructure;
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
