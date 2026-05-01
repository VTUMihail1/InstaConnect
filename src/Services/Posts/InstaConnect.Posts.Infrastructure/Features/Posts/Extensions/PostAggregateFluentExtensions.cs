using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class PostAggregateFluentExtensions
{
	extension(IAggregateFluent<Post> aggregate)
	{
		public IAggregateFluent<Post> Match(PostsFilterQuery filter)
		{
			return aggregate.Match(filter.GetFilter());
		}

		public IAggregateFluent<Post> Match(PostsForUserFilterQuery filter)
		{
			return aggregate.Match(filter.GetFilter());
		}

		public IAggregateFluent<Post> Match(PostId filter)
		{
			return aggregate.Match(filter.GetFilter());
		}

		public IAggregateFluent<PostResponse> ProjectToFullResponse(CurrentUserQuery currentUser)
		{
			var currentUserId = currentUser.Id.Id?.ToLower();
			var projection = Builders<Post>.Projection.Expression(
				 p => new PostResponse(
					 p.Id,
					 p.UserId,
					 p.Title,
					 p.Content,
					 new UserResponse(
						 p.User!.Id,
						 p.User.FirstName,
						 p.User.LastName,
						 p.User.Email,
						 p.User.Name,
						 p.User.ProfileImage,
						 p.User.CreatedAtUtc,
						 p.User.UpdatedAtUtc),
					 p.PostLikes.Any(
						 pl => pl.Id.UserId.Id.ToLower() == currentUserId),
					 p.CreatedAtUtc,
					 p.UpdatedAtUtc));

			return aggregate.Project(projection);
		}

		public IAggregateFluent<PostResponse> ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
		{
			var currentUserId = currentUser.Id.Id?.ToLower();
			var projection = Builders<Post>.Projection.Expression(
				 p => new PostResponse(
					 p.Id,
					 p.UserId,
					 p.Title,
					 p.Content,
					 null,
					 p.PostLikes.Any(
						 pl => pl.Id.UserId.Id.ToLower() == currentUserId),
					 p.CreatedAtUtc,
					 p.UpdatedAtUtc));

			return aggregate.Project(projection);
		}
	}
}
