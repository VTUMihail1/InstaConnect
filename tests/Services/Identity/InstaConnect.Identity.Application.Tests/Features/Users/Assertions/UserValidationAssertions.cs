using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserValidationAssertions
{
	extension(TestValidationResult<UpdateCurrentUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFirstName(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			IStringMessageTransformer messageTransformer,
			UpdateCurrentUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			UpdateCurrentUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			IStringMessageTransformer messageTransformer,
			UpdateCurrentUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Email, messageTransformer);
		}
	}

	extension(TestValidationResult<DeleteUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			DeleteUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}
	}

	extension(TestValidationResult<DeleteCurrentUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			DeleteCurrentUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetUserByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			GetUserByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetUserByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetCurrentUserByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetCurrentUserByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetUserDetailsByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			GetUserDetailsByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetUserDetailsByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetCurrentUserDetailsByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetCurrentUserDetailsByIdQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForFirstName(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Email, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPassword(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Password, messageTransformer);
		}

		public void ShouldHaveValidationErrorForConfirmPassword(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ConfirmPassword, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllUsersQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			GetAllUsersQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFirstName(
			IStringMessageTransformer messageTransformer,
			GetAllUsersQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			IStringMessageTransformer messageTransformer,
			GetAllUsersQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetAllUsersQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			IIntMessageTransformer messageTransformer,
			GetAllUsersQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			IIntMessageTransformer messageTransformer,
			GetAllUsersQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllUsersQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			IEnumMessageTransformer<UsersSortTerm> messageTransformer,
			GetAllUsersQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
