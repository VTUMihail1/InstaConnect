using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationAssertions
{
	extension(TestValidationResult<AddPostCommentCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, AddPostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForContent(IStringMessageTransformer messageTransformer, AddPostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserId(IStringMessageTransformer messageTransformer, AddPostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
		}
	}

	extension(TestValidationResult<UpdatePostCommentCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, UpdatePostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCommentId(IStringMessageTransformer messageTransformer, UpdatePostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForContent(IStringMessageTransformer messageTransformer, UpdatePostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserId(IStringMessageTransformer messageTransformer, UpdatePostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
		}
	}

	extension(TestValidationResult<DeletePostCommentCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, DeletePostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCommentId(IStringMessageTransformer messageTransformer, DeletePostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserId(IStringMessageTransformer messageTransformer, DeletePostCommentCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
		}
	}

	extension(TestValidationResult<GetPostCommentByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, GetPostCommentByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCommentId(IStringMessageTransformer messageTransformer, GetPostCommentByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(IStringMessageTransformer messageTransformer, GetPostCommentByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
		}
	}

	extension(TestValidationResult<GetAllPostCommentsQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, GetAllPostCommentsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(IStringMessageTransformer messageTransformer, GetAllPostCommentsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserName(IStringMessageTransformer messageTransformer, GetAllPostCommentsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserName, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPage(IIntMessageTransformer messageTransformer, GetAllPostCommentsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPageSize(IIntMessageTransformer messageTransformer, GetAllPostCommentsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForSortOrder(IEnumMessageTransformer<CommonSortOrder> messageTransformer, GetAllPostCommentsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForSortTerm(IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer, GetAllPostCommentsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
		}
	}

	extension(TestValidationResult<GetAllPostCommentsForUserQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForUserId(IStringMessageTransformer messageTransformer, GetAllPostCommentsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(IStringMessageTransformer messageTransformer, GetAllPostCommentsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPage(IIntMessageTransformer messageTransformer, GetAllPostCommentsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPageSize(IIntMessageTransformer messageTransformer, GetAllPostCommentsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForSortOrder(IEnumMessageTransformer<CommonSortOrder> messageTransformer, GetAllPostCommentsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForSortTerm(IEnumMessageTransformer<PostCommentsForUserSortTerm> messageTransformer, GetAllPostCommentsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
		}
	}
}
