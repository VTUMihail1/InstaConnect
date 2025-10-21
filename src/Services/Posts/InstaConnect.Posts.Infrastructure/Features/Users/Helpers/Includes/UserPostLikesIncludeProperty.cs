using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Infrastructure.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class UserPostLikesIncludeProperty : IUserIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public UserPostLikesIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.PostLikes;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, PostLike, User>(
                _postsContext.PostLikes,
                p => p.Id,
                l => l.UserId,
                p => p.PostLikes
            );
    }
}
