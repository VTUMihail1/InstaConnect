using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class UserIncluder : IPostLikeIncluder
{
    private readonly IPostsContext _context;

    public UserIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostLikes;

    public PostsIncludeType IncludeType => PostsIncludeType.Users;

    public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.Id.UserId,
                u => u.Id,
                p => p.User!
            );
    }
}
