using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostEquals
{
	extension(Post? entity)
	{
		public bool Matches(PostEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.Id) &&
				   entity.UserId.Matches(request.UserId) &&
				   entity.User.Matches(request.User) &&
				   entity.Title == request.Title &&
				   entity.Content == request.Content &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(Post entity)
	{
		public bool Matches(Post post)
		{
			return entity.Id.Matches(post.Id) &&
				   entity.UserId.Matches(post.UserId) &&
				   entity.Title == post.Title &&
				   entity.Content == post.Content &&
				   entity.CreatedAtUtc == post.CreatedAtUtc &&
				   entity.UpdatedAtUtc == post.UpdatedAtUtc;
		}
	}

	extension(PostId p)
	{
		public bool Matches(PostId id)
		{
			return p.Matches(id.Id);
		}

		public bool Matches(string id)
		{
			return p.Id.EqualsOrdinalIgnoreCase(id);
		}
	}
}
