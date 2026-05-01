using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class UserIncluder : IPostIncluder
{
	private readonly IPostsContext _context;

	public UserIncluder(IPostsContext context)
	{
		_context = context;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<Post> Include(IAggregateFluent<Post> aggregate)
	{
		return aggregate
			.IncludeOne(
				_context.Users,
				p => p.UserId,
				u => u.Id,
				p => p.User!
			);
	}
}
