using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class PostCommentLikesIncluder : IUserIncluder
{
    private readonly IPostsContext _context;

    public PostCommentLikesIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.User;

    public PostsIncludeType IncludeType => PostsIncludeType.PostCommentLike;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.PostCommentLikes,
                p => p.Id,
                l => l.Id.UserId,
                p => p.PostCommentLikes
            );
    }
}
