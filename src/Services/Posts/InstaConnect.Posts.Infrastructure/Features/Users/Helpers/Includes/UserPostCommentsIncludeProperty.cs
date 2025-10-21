using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Infrastructure.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class UserPostCommentsIncludeProperty : IUserIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public UserPostCommentsIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.PostComments;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, PostComment, User>(
                _postsContext.PostComments,
                p => p.Id,
                l => l.UserId,
                p => p.PostComments
            );
    }
}
