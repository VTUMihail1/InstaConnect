using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class PostLikeUserIncludeProperty : IPostLikeIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostLikeUserIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostLikeIncludeProperty IncludeProperty => PostLikeIncludeProperty.User;

    public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> pipeline)
    {
        return pipeline
            .Lookup<PostLike, PostLike, PostLike>(
                _postsContext.PostLikes,
                p => p.UserId,
                u => u.Id,
                p => p.User 
            );
    }
}
