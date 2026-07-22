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
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Email, messageTransformer);
		}
	}

	extension(TestValidationResult<DeleteUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			DeleteUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}
	}

	extension(TestValidationResult<DeleteCurrentUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			DeleteCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetUserByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			GetUserByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			GetUserByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetCurrentUserByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForCurrentId(
			GetCurrentUserByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetUserDetailsByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			GetUserDetailsByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			GetUserDetailsByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetCurrentUserDetailsByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForCurrentId(
			GetCurrentUserDetailsByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForFirstName(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Email, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPassword(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Password, messageTransformer);
		}

		public void ShouldHaveValidationErrorForConfirmPassword(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ConfirmPassword, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllUsersQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			GetAllUsersQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFirstName(
			GetAllUsersQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			GetAllUsersQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			GetAllUsersQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllUsersQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllUsersQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllUsersQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllUsersQueryRequest request,
			IEnumMessageTransformer<UsersSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
