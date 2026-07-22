namespace InstaConnect.Chats.Application.Tests.Features.Users.Assertions;

public static class UserValidationAssertions
{
	extension(TestValidationResult<UpdateUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			UpdateUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			UpdateUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFirstName(
			UpdateUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			UpdateUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			UpdateUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Email, messageTransformer);
		}

		public void ShouldHaveValidationErrorForProfileImage(
			UpdateUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ProfileImageUrl, messageTransformer!);
		}

		public void ShouldHaveValidationErrorForUpdatedAtUtc(
			UpdateUserCommandRequest request,
			IDateTimeOffsetMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UpdatedAtUtc, messageTransformer);
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

	extension(TestValidationResult<AddUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

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

		public void ShouldHaveValidationErrorForEmail(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Email, messageTransformer);
		}

		public void ShouldHaveValidationErrorForProfileImage(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ProfileImageUrl, messageTransformer!);
		}

		public void ShouldHaveValidationErrorForCreatedAtUtc(
			AddUserCommandRequest request,
			IDateTimeOffsetMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CreatedAtUtc, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUpdatedAtUtc(
			AddUserCommandRequest request,
			IDateTimeOffsetMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.UpdatedAtUtc, messageTransformer);
		}
	}
}
