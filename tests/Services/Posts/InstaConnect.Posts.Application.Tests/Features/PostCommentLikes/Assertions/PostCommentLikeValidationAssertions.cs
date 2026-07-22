using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeValidationAssertions
{
	extension(TestValidationResult<DeletePostCommentLikeCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(DeletePostCommentLikeCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCommentId(DeletePostCommentLikeCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CommentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(DeletePostCommentLikeCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetPostCommentLikeByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(GetPostCommentLikeByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCommentId(GetPostCommentLikeByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CommentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(GetPostCommentLikeByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(GetPostCommentLikeByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddPostCommentLikeCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(AddPostCommentLikeCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCommentId(AddPostCommentLikeCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CommentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(AddPostCommentLikeCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllPostCommentLikesQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(GetAllPostCommentLikesQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCommentId(GetAllPostCommentLikesQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CommentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(GetAllPostCommentLikesQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserName(GetAllPostCommentLikesQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(GetAllPostCommentLikesQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(GetAllPostCommentLikesQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(GetAllPostCommentLikesQueryRequest request, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(GetAllPostCommentLikesQueryRequest request, IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllPostCommentLikesForUserQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForUserId(GetAllPostCommentLikesForUserQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(GetAllPostCommentLikesForUserQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(GetAllPostCommentLikesForUserQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(GetAllPostCommentLikesForUserQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(GetAllPostCommentLikesForUserQueryRequest request, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(GetAllPostCommentLikesForUserQueryRequest request, IEnumMessageTransformer<PostCommentLikesForUserSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
