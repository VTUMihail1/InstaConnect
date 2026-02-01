using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class UserIncluder : IPostCommentLikeIncluder
{
    private readonly IPostsContext _context;

    public UserIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostCommentLikes;

    public PostsIncludeType IncludeType => PostsIncludeType.Users;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                pcl => pcl.Id.UserId,
                u => u.Id,
                pcl => pcl.User!
            );
    }
}
