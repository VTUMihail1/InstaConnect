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

    public IMongoCollection<User> Users => Collection<User>(PostCollectionNames.Users);

    public IMongoCollection<Post> Posts => Collection<Post>(PostCollectionNames.Posts);

    public IMongoCollection<PostLike> PostLikes => Collection<PostLike>(PostCollectionNames.PostLikes);

    public IMongoCollection<PostComment> PostComments => Collection<PostComment>(PostCollectionNames.PostComments);

    public IMongoCollection<PostCommentLike> PostCommentLikes => Collection<PostCommentLike>(PostCollectionNames.PostCommentLikes);
}
