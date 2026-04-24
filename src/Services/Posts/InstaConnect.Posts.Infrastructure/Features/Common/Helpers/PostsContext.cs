using InstaConnect.Common.Infrastructure.Features.Data.Helpers;
using InstaConnect.Posts.Infrastructure.Features.Common.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Common.Helpers;

public class PostsContext : MongoDbContext, IPostsContext
{
    public PostsContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => ToCollection<User, UserId>(PostsCollectionNames.Users);

    public IMongoCollection<Post> Posts => ToCollection<Post, PostId>(PostsCollectionNames.Posts);

    public IMongoCollection<PostLike> PostLikes => ToCollection<PostLike, PostLikeId>(PostsCollectionNames.PostLikes);

    public IMongoCollection<PostComment> PostComments => ToCollection<PostComment, PostCommentId>(PostsCollectionNames.PostComments);

    public IMongoCollection<PostCommentLike> PostCommentLikes => ToCollection<PostCommentLike, PostCommentLikeId>(PostsCollectionNames.PostCommentLikes);
}
