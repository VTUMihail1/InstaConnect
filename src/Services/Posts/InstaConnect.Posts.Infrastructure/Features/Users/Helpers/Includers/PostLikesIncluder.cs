using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class PostLikesIncluder : IUserIncluder
{
	private readonly IPostsContext _context;

	public PostLikesIncluder(IPostsContext context)
	{
		_context = context;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.User;

	public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_context.PostLikes,
				p => p.Id,
				l => l.Id.UserId,
				p => p.PostLikes
			);
	}
}
