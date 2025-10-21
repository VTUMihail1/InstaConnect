using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class PostLikesIncludeProperty : IPostIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostLikesIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostIncludeProperty IncludeProperty => PostIncludeProperty.Likes;

    public IAggregateFluent<Post> Include(IAggregateFluent<Post> pipeline)
    {
        return pipeline
            .Lookup<Post, PostLike, Post>(
                _postsContext.PostLikes,
                p => p.Id, 
                l => l.Id,
                p => p.Likes
            );
    }
}
