using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostIncluder : IPostCommentLikeIncluder
{
	private readonly IPostsContext _context;

	public PostCommentPostIncluder(IPostsContext context)
	{
		_context = context;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.Post;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_context.Posts,
				pcl => pcl.Id.CommentId.Id,
				p => p.Id,
				pcl => pcl.PostComment!.Post!
			);
	}
}
