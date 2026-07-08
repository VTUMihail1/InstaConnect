using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(PostLike postLike)
	{
		public PostLikeId ToId()
		{
			return postLike.Id;
		}

		public PostLike ToFull()
		{
			return new PostLike(postLike.Id,
					   postLike.CreatedAtUtc)
				.AddUser(postLike.User?.ToFull())
				.AddPost(postLike.Post?.ToFull());
		}

		public PostLike ToWithoutUser()
		{
			return new PostLike(postLike.Id,
					   postLike.CreatedAtUtc)
				.AddPost(postLike.Post?.ToFull());
		}

		public PostLike ToWithoutPost()
		{
			return new PostLike(postLike.Id,
					   postLike.CreatedAtUtc)
				.AddUser(postLike.User?.ToFull());
		}
	}
}
