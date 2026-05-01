using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentUserIncluder : IPostCommentLikeIncluder
{
	private readonly IPostsContext _context;

	public PostCommentUserIncluder(IPostsContext context)
	{
		_context = context;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

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
