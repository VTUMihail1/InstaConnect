using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class PostUserIncludeProperty : IPostIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostUserIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostIncludeProperty IncludeProperty => PostIncludeProperty.User;

    public IAggregateFluent<Post> Include(IAggregateFluent<Post> pipeline)
    {
        return pipeline
            .Lookup<Post, User, Post>(
                _postsContext.Users,
                p => p.UserId,
                u => u.Id,
                p => p.User 
            );
    }
}
