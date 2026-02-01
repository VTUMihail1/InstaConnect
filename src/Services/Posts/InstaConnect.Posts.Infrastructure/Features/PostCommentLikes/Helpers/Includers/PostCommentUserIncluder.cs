using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentUserIncluder : IPostCommentLikeIncluder
{
    private readonly IPostsContext _context;

    public PostCommentUserIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostComments;

    public PostsIncludeType IncludeType => PostsIncludeType.Users;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                pcl => pcl.PostComment!.UserId,
                p => p.Id,
                pcl => pcl.PostComment!.User!
            );
    }
}
