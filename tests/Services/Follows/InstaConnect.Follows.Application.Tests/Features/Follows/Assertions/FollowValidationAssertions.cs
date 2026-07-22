using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowValidationAssertions
{
	extension(TestValidationResult<DeleteFollowCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForFollowerId(
			DeleteFollowCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowerId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowingId(
			DeleteFollowCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowingId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetFollowByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForFollowerId(
			GetFollowByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowerId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowingId(
			GetFollowByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowingId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetFollowByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddFollowCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForFollowerId(
			AddFollowCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowerId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowingId(
			AddFollowCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowingId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllFollowsQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForFollowerId(
			GetAllFollowsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowerId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllFollowsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowingName(
			GetAllFollowsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowingName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllFollowsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllFollowsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllFollowsQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllFollowsQueryRequest request,
			IEnumMessageTransformer<FollowsSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllFollowsForFollowingQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForFollowingId(
			GetAllFollowsForFollowingQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowingId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowerName(
			GetAllFollowsForFollowingQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FollowerName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllFollowsForFollowingQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllFollowsForFollowingQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllFollowsForFollowingQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllFollowsForFollowingQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllFollowsForFollowingQueryRequest request,
			IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
