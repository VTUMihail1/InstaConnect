using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostUserIncluder : IPostLikeIncluder
{
    private readonly IPostsContext _context;

    public PostUserIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Posts;

    public PostsIncludeType IncludeType => PostsIncludeType.Users;

    public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                pc => pc.Post!.UserId,
                u => u.Id,
                pc => pc.Post!.User!
            );
    }
}
