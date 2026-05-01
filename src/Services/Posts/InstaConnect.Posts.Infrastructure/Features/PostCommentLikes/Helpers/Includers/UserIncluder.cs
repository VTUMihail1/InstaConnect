using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class UserIncluder : IPostCommentLikeIncluder
{
	private readonly IPostsContext _context;

	public UserIncluder(IPostsContext context)
	{
		_context = context;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostCommentLike;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

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
