using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(PostCommentLike postCommentLike)
	{
		public PostCommentLikeId ToId()
		{
			return postCommentLike.Id;
		}

		public PostCommentLike ToFull()
		{
			return new PostCommentLike(postCommentLike.Id,
					   postCommentLike.CreatedAtUtc)
				.AddUser(postCommentLike.User?.ToFull())
				.AddPostComment(postCommentLike.PostComment?.ToFull());
		}

		public PostCommentLike ToWithoutUser()
		{
			return new PostCommentLike(postCommentLike.Id,
					   postCommentLike.CreatedAtUtc)
				.AddPostComment(postCommentLike.PostComment?.ToFull());
		}

		public PostCommentLike ToWithoutPostComment()
		{
			return new PostCommentLike(postCommentLike.Id,
					   postCommentLike.CreatedAtUtc)
				.AddUser(postCommentLike.User?.ToFull());
		}
	}
}
