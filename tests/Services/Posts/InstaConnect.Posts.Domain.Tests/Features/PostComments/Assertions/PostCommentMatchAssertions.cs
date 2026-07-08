using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
	extension(PostCommentId response)
	{
		public void ShouldSatisfy(PostComment postComment, AddPostCommentCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(postComment, command));
		}

		public void ShouldSatisfy(PostComment postComment, UpdatePostCommentCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(postComment, command));
		}
	}

	extension(PostCommentResponse response)
	{
		public void ShouldSatisfy(PostComment postComment, GetPostCommentByIdQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(postComment, query));
		}
	}

	extension(PostCommentCollectionResponse response)
	{
		public void ShouldSatisfy(
		Post post,
		ICollection<PostComment> postComments,
		GetAllPostCommentsQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(post, postComments, query));
		}

		public void ShouldSatisfy(
			Post post,
			ICollection<PostComment> postComments,
			GetAllPostCommentsQuery query,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(post, postComments, query, termTransformer));
		}

		public void ShouldSatisfy(
		User user,
		ICollection<PostComment> postComments,
		GetAllPostCommentsForUserQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(user, postComments, query));
		}

		public void ShouldSatisfy(
			User user,
			ICollection<PostComment> postComments,
			GetAllPostCommentsForUserQuery query,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(user, postComments, query, termTransformer));
		}
	}

	extension(PostComment postComment)
	{
		public void ShouldSatisfy(AddPostCommentCommand command)
		{
			postComment.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdatePostCommentCommand command)
		{
			postComment.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
