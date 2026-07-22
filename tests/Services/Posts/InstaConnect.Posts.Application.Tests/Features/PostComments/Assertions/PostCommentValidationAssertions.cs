using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationAssertions
{
	extension(TestValidationResult<AddPostCommentCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(AddPostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForContent(AddPostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Content, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(AddPostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<UpdatePostCommentCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(UpdatePostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCommentId(UpdatePostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CommentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForContent(UpdatePostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Content, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(UpdatePostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<DeletePostCommentCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(DeletePostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCommentId(DeletePostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CommentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(DeletePostCommentCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetPostCommentByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(GetPostCommentByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCommentId(GetPostCommentByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CommentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(GetPostCommentByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllPostCommentsQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(GetAllPostCommentsQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(GetAllPostCommentsQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserName(GetAllPostCommentsQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(GetAllPostCommentsQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(GetAllPostCommentsQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(GetAllPostCommentsQueryRequest request, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(GetAllPostCommentsQueryRequest request, IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllPostCommentsForUserQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForUserId(GetAllPostCommentsForUserQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(GetAllPostCommentsForUserQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(GetAllPostCommentsForUserQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(GetAllPostCommentsForUserQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(GetAllPostCommentsForUserQueryRequest request, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(GetAllPostCommentsForUserQueryRequest request, IEnumMessageTransformer<PostCommentsForUserSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
