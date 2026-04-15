using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostUserIncluder : IPostCommentIncluder
{
    private readonly IPostsContext _context;

    public PostUserIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Post;

    public PostsIncludeType IncludeType => PostsIncludeType.User;

    public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
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
