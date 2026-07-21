using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLike? entity)
	{
		public bool Matches(PostLikeEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.Id, request.UserId) &&
				   entity.User.Matches(request.User) &&
				   entity.Post.Matches(request.Post) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}
	}
	extension(PostLike entity)
	{
		public bool Matches(PostLike postLike)
		{
			return entity.Id.Matches(postLike.Id) &&
				   entity.CreatedAtUtc == postLike.CreatedAtUtc;
		}
	}

	extension(PostLikeId p)
	{
		public bool Matches(PostLikeId id)
		{
			return p.Matches(id.Id.Id, id.UserId.Id);
		}

		public bool Matches(string id, string userId)
		{
			return p.Id.Matches(id) &&
				   p.UserId.Matches(userId);
		}
	}
}
