using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class PostCommentUserIncludeProperty : IPostCommentIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostCommentUserIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostCommentIncludeProperty IncludeProperty => PostCommentIncludeProperty.User;

    public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> pipeline)
    {
        return pipeline
            .Lookup<PostComment, PostComment, PostComment>(
                _postsContext.PostComments,
                p => p.UserId,
                u => u.Id,
                p => p.User 
            );
    }
}
