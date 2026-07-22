using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
	extension(AddPostCommentApiResponse response)
	{
		public void ShouldSatisfy(
		AddPostCommentApiRequest request,
		PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(UpdatePostCommentApiResponse response)
	{
		public void ShouldSatisfy(
		UpdatePostCommentApiRequest request,
		PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(GetPostCommentByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetPostCommentByIdApiRequest request,
		PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(GetAllPostCommentsApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentsApiRequest request,
		Post post,
		ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(request, post, postComments));
		}

		public void ShouldSatisfy(
			GetAllPostCommentsApiRequest request,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, post, postComments, termTransformer));
		}
	}

	extension(GetAllPostCommentsForUserApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentsForUserApiRequest request,
		User user,
		ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postComments));
		}

		public void ShouldSatisfy(
			GetAllPostCommentsForUserApiRequest request,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postComments, termTransformer));
		}
	}

	extension(ActionResult<AddPostCommentApiResponse> response)
	{
		public void ShouldSatisfy(
		AddPostCommentApiRequest request,
		PostComment postComment)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(ActionResult<UpdatePostCommentApiResponse> response)
	{
		public void ShouldSatisfy(
		UpdatePostCommentApiRequest request,
		PostComment postComment)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(ActionResult<GetPostCommentByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetPostCommentByIdApiRequest request,
		PostComment postComment)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(ActionResult<GetAllPostCommentsApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentsApiRequest request,
		Post post,
		ICollection<PostComment> postComments)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, post, postComments));
		}
	}

	extension(ActionResult<GetAllPostCommentsForUserApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentsForUserApiRequest request,
		User user,
		ICollection<PostComment> postComments)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, postComments));
		}
	}

	extension(PostComment postComment)
	{
		public void ShouldSatisfy(AddPostCommentApiRequest request)
		{
			postComment.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(UpdatePostCommentApiRequest request)
		{
			postComment.ShouldSatisfy(p => p.Matches(request));
		}
	}
}
