using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class UserIncluder : IPostLikeIncluder
{
	private readonly IPostsContext _context;

	public UserIncluder(IPostsContext context)
	{
		_context = context;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostLike;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_context.Users,
				p => p.Id.UserId,
				u => u.Id,
				p => p.User!
			);
	}
}
