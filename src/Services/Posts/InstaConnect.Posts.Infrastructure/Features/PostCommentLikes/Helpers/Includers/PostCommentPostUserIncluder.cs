using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostUserIncluder : IPostCommentLikeIncluder
{
    private readonly IPostsContext _context;

    public PostCommentPostUserIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Posts;

    public PostsIncludeType IncludeType => PostsIncludeType.Users;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                pcl => pcl.PostComment!.Post!.UserId,
                p => p.Id,
                pcl => pcl.PostComment!.Post!.User!
            );
    }
}
