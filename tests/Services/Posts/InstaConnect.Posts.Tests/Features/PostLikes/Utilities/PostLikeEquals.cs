using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
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
			return p.Matches(id.Id, id.UserId);
		}

		public bool Matches(PostId id, UserId userId)
		{
			return p.Matches(id.Id, userId.Id);
		}

		public bool Matches(string id, string userId)
		{
			return p.Id.Matches(id) &&
				   p.UserId.Matches(userId);
		}
	}
}
