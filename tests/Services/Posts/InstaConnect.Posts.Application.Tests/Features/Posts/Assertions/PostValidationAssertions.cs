using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostValidationAssertions
{
	extension(TestValidationResult<UpdatePostCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
		IStringMessageTransformer messageTransformer,
		UpdatePostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForContent(
			IStringMessageTransformer messageTransformer,
			UpdatePostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForTitle(
			IStringMessageTransformer messageTransformer,
			UpdatePostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Title, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserId(
			IStringMessageTransformer messageTransformer,
			UpdatePostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
		}
	}

	extension(TestValidationResult<DeletePostCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
		IStringMessageTransformer messageTransformer,
		DeletePostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserId(
			IStringMessageTransformer messageTransformer,
			DeletePostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
		}
	}

	extension(TestValidationResult<GetPostByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
		IStringMessageTransformer messageTransformer,
		GetPostByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			IStringMessageTransformer messageTransformer,
			GetPostByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
		}
	}

	extension(TestValidationResult<AddPostCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForContent(
		IStringMessageTransformer messageTransformer,
		AddPostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForTitle(
			IStringMessageTransformer messageTransformer,
			AddPostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Title, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserId(
			IStringMessageTransformer messageTransformer,
			AddPostCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
		}
	}

	extension(TestValidationResult<GetAllPostsForUserQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForTitle(
		IStringMessageTransformer messageTransformer,
		GetAllPostsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Title, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserId(
			IStringMessageTransformer messageTransformer,
			GetAllPostsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			IStringMessageTransformer messageTransformer,
			GetAllPostsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPage(
			IIntMessageTransformer messageTransformer,
			GetAllPostsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPageSize(
			IIntMessageTransformer messageTransformer,
			GetAllPostsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllPostsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			IEnumMessageTransformer<PostsForUserSortTerm> messageTransformer,
			GetAllPostsForUserQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
		}
	}

	extension(TestValidationResult<GetAllPostsQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForTitle(
		IStringMessageTransformer messageTransformer,
		GetAllPostsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Title, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			IStringMessageTransformer messageTransformer,
			GetAllPostsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForUserName(
			IStringMessageTransformer messageTransformer,
			GetAllPostsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UserName, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPage(
			IIntMessageTransformer messageTransformer,
			GetAllPostsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPageSize(
			IIntMessageTransformer messageTransformer,
			GetAllPostsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllPostsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			IEnumMessageTransformer<PostsSortTerm> messageTransformer,
			GetAllPostsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
		}
	}
}
