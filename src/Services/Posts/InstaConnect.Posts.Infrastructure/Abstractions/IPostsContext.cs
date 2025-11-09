using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Abstractions;
public interface IPostsContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }

    public IMongoCollection<Post> Posts { get; }

    public IMongoCollection<PostLike> PostLikes { get; }

    public IMongoCollection<PostComment> PostComments { get; }

    public IMongoCollection<PostCommentLike> PostCommentLikes { get; }
}
