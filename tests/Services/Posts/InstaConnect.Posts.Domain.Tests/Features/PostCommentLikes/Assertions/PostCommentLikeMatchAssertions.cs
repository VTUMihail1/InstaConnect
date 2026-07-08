using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
	extension(PostCommentLikeId response)
	{
		public void ShouldSatisfy(PostCommentLike postCommentLike, AddPostCommentLikeCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(postCommentLike, command));
		}
	}

	extension(PostCommentLikeResponse response)
	{
		public void ShouldSatisfy(PostCommentLike postCommentLike, GetPostCommentLikeByIdQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(postCommentLike, query));
		}
	}

	extension(PostCommentLikeCollectionResponse response)
	{
		public void ShouldSatisfy(
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes,
		GetAllPostCommentLikesQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, query));
		}

		public void ShouldSatisfy(
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			GetAllPostCommentLikesQuery query,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, query, termTransformer));
		}

		public void ShouldSatisfy(
		User user,
		ICollection<PostCommentLike> postCommentLikes,
		GetAllPostCommentLikesForUserQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, query));
		}

		public void ShouldSatisfy(
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			GetAllPostCommentLikesForUserQuery query,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, query, termTransformer));
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		public void ShouldSatisfy(AddPostCommentLikeCommand command)
		{
			postCommentLike.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
