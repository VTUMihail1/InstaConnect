using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
public interface IPostsContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }

    public IMongoCollection<Post> Posts { get; }

    public IMongoCollection<PostLike> PostLikes { get; }

    public IMongoCollection<PostComment> PostComments { get; }

    public IMongoCollection<PostCommentLike> PostCommentLikes { get; }
}
