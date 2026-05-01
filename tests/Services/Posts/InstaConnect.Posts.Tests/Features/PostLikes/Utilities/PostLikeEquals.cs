using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLikeAddedEventRequest request)
	{
		public bool Matches(PostLike entity)
		{
			return entity.Matches(request.PostLike);
		}
	}

	extension(PostLikeDeletedEventRequest request)
	{
		public bool Matches(PostLike entity)
		{
			return entity.Matches(request.PostLike);
		}
	}

	extension(PostLikeEventRequest r)
	{
		public bool Matches(PostLikeEventRequest request)
		{
			return r.Id == request.Id &&
				   r.UserId == request.UserId &&
				   r.User.Matches(request.User) &&
				   r.Post.Matches(request.Post) &&
				   r.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(PostLike entity)
	{
		public bool Matches(PostLikeEventRequest request)
		{
			return entity.Id.Matches(request.Id, request.UserId) &&
				   entity.User != null && entity.User.Matches(request.User) &&
				   entity.Post != null && entity.Post.Matches(request.Post) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(PostLikeId p)
	{
		public bool Matches(string id, string userId)
		{
			return p.Id.Matches(id) &&
				   p.UserId.Matches(userId);
		}
	}
}
