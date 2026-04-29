using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			DeleteUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			UpdateCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			DeleteCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			GetUserByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			GetUserDetailsByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetUserByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetCurrentUserByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetUserDetailsByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetCurrentUserDetailsByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetAllUsersApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForFirstName(
			IStringMessageTransformer messageTransformer,
			AddUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.FirstName,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForFirstName(
			IStringMessageTransformer messageTransformer,
			UpdateCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.FirstName,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForFirstName(
			IStringMessageTransformer messageTransformer,
			GetAllUsersApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.FirstName,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForLastName(
			IStringMessageTransformer messageTransformer,
			AddUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.LastName,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForLastName(
			IStringMessageTransformer messageTransformer,
			UpdateCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.LastName,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForLastName(
			IStringMessageTransformer messageTransformer,
			GetAllUsersApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.LastName,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForName(
			IStringMessageTransformer messageTransformer,
			AddUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.Name,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForName(
			IStringMessageTransformer messageTransformer,
			UpdateCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.Name,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForName(
			IStringMessageTransformer messageTransformer,
			GetAllUsersApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Name,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForEmail(
			IStringMessageTransformer messageTransformer,
			AddUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.Email,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForEmail(
			IStringMessageTransformer messageTransformer,
			UpdateCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.Email,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForPassword(
			IStringMessageTransformer messageTransformer,
			AddUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.Password,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForConfirmPassword(
			IStringMessageTransformer messageTransformer,
			AddUserApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Form.ConfirmPassword,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			IIntMessageTransformer messageTransformer,
			GetAllUsersApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Page,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			IIntMessageTransformer messageTransformer,
			GetAllUsersApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.PageSize,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllUsersApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.SortOrder,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			IEnumMessageTransformer<UsersSortTerm> messageTransformer,
			GetAllUsersApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.SortTerm,
				messageTransformer,
				request);
		}
	}
}
