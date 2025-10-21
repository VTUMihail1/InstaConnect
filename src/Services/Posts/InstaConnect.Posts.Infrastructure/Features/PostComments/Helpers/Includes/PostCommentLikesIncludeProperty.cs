using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class PostCommentLikesIncludeProperty : IPostCommentIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostCommentLikesIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostCommentIncludeProperty IncludeProperty => PostCommentIncludeProperty.Likes;

    public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> pipeline)
    {
        return pipeline
            .Lookup<PostComment, PostCommentLike, PostComment>(
                _postsContext.PostCommentLikes,
                p => p.CommentId,
                u => u.CommentId,
                p => p.Likes
            );
    }
}
