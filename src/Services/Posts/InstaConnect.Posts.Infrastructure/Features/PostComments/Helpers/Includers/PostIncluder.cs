using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostIncluder : IPostCommentIncluder
{
    private readonly IPostsContext _context;

    public PostIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

    public PostsIncludeType IncludeType => PostsIncludeType.Post;

    public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Posts,
                pc => pc.Id.Id,
                p => p.Id,
                pc => pc.Post!
            );
    }
}
