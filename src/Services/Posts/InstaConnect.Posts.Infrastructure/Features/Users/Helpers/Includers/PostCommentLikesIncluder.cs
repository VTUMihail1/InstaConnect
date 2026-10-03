using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class PostCommentLikesIncluder : IUserIncluder
{
	private readonly IMongoCollection<PostCommentLike> _collection;

	public PostCommentLikesIncluder(IMongoCollection<PostCommentLike> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.User;

	public PostsIncludeType IncludeType => PostsIncludeType.PostCommentLike;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.UserId,
				p => p.PostCommentLikes
			);
	}
}
