using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class UserIncluder : IPostCommentIncluder
{
	private readonly IPostsContext _context;

	public UserIncluder(IPostsContext context)
	{
		_context = context;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

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
