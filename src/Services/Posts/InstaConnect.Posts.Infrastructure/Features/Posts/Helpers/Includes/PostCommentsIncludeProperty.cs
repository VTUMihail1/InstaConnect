using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class PostCommentsIncludeProperty : IPostIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostCommentsIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostIncludeProperty IncludeProperty => PostIncludeProperty.Comments;

    public IAggregateFluent<Post> Include(IAggregateFluent<Post> pipeline)
    {
        return pipeline
            .Lookup<Post, PostComment, Post>(
                _postsContext.PostComments,
                p => p.Id,
                c => c.Id,
                p => p.Comments
            );
    }
}
