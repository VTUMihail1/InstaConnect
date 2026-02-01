using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class UserIncluder : IPostCommentIncluder
{
    private readonly IPostsContext _context;

    public UserIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostComments;

    public PostsIncludeType IncludeType => PostsIncludeType.Users;

    public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                pc => pc.UserId,
                u => u.Id,
                pc => pc.User!
            );
    }
}
