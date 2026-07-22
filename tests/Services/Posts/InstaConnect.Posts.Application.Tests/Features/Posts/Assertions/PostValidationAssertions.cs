using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostValidationAssertions
{
	extension(TestValidationResult<UpdatePostCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			UpdatePostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForContent(
			UpdatePostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Content, messageTransformer);
		}

		public void ShouldHaveValidationErrorForTitle(
			UpdatePostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Title, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(
			UpdatePostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<DeletePostCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			DeletePostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(
			DeletePostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetPostByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			GetPostByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetPostByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddPostCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForContent(
			AddPostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Content, messageTransformer);
		}

		public void ShouldHaveValidationErrorForTitle(
			AddPostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Title, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(
			AddPostCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllPostsForUserQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForTitle(
			GetAllPostsForUserQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Title, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(
			GetAllPostsForUserQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllPostsForUserQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllPostsForUserQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllPostsForUserQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllPostsForUserQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllPostsForUserQueryRequest request,
			IEnumMessageTransformer<PostsForUserSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllPostsQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForTitle(
			GetAllPostsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Title, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllPostsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserName(
			GetAllPostsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UserName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllPostsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllPostsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllPostsQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllPostsQueryRequest request,
			IEnumMessageTransformer<PostsSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
