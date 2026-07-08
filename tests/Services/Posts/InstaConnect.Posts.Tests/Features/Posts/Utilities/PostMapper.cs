using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		public PostId ToId()
		{
			return post.Id;
		}

		public Post ToFull()
		{
			return new Post(post.Id,
					   post.Title,
					   post.Content,
					   post.UserId,
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc).AddUser(post.User?.ToFull());
		}

		public Post ToWithoutUser()
		{
			return new(post.Id,
					   post.Title,
					   post.Content,
					   post.UserId,
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}
	}
}
