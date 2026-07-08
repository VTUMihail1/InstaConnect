using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(PostComment postComment)
	{
		public PostCommentId ToId()
		{
			return postComment.Id;
		}

		public PostComment ToFull()
		{
			return new PostComment(postComment.Id,
					   postComment.Content,
					   postComment.UserId,
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc)
				.AddUser(postComment.User?.ToFull())
				.AddPost(postComment.Post?.ToFull());
		}

		public PostComment ToWithoutUser()
		{
			return new PostComment(postComment.Id,
					   postComment.Content,
					   postComment.UserId,
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc)
				.AddPost(postComment.Post?.ToFull());
		}

		public PostComment ToWithoutPost()
		{
			return new PostComment(postComment.Id,
					   postComment.Content,
					   postComment.UserId,
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc)
				.AddUser(postComment.User?.ToFull());
		}
	}
}
