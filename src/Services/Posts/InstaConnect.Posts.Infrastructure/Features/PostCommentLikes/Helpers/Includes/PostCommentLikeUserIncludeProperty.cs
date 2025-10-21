using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class PostCommentLikeUserIncludeProperty : IPostCommentLikeIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostCommentLikeUserIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostCommentLikeIncludeProperty IncludeProperty => PostCommentLikeIncludeProperty.User;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> pipeline)
    {
        return pipeline
            .Lookup<PostCommentLike, User, PostCommentLike>(
                _postsContext.Users,
                p => p.UserId,
                u => u.Id,
                p => p.User 
            );
    }
}
