using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includes;

internal class PostCommentsIncluder : IUserIncluder
{
    private readonly IPostsContext _postsContext;

    public PostCommentsIncluder(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Users;

    public PostsIncludeType IncludeType => PostsIncludeType.PostComments;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _postsContext.PostComments,
                p => p.Id,
                l => l.UserId,
                p => p.PostComments
            );
    }
}
