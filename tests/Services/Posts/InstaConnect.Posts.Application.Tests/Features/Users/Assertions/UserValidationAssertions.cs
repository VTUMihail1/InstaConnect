namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserValidationAssertions
{
	extension(TestValidationResult<UpdateUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			UpdateUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			UpdateUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFirstName(
			UpdateUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			UpdateUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			UpdateUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.Email, messageTransformer);
		}

		public void ShouldHaveValidationErrorForProfileImage(
			UpdateUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.ProfileImageUrl, messageTransformer!);
		}

		public void ShouldHaveValidationErrorForUpdatedAtUtc(
			UpdateUserCommandRequest value,
			IDateTimeOffsetMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.UpdatedAtUtc, messageTransformer);
		}
	}

	extension(TestValidationResult<DeleteUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			DeleteUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.Id, messageTransformer);
		}
	}

	extension(TestValidationResult<AddUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			AddUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			AddUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFirstName(
			AddUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			AddUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			AddUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.Email, messageTransformer);
		}

		public void ShouldHaveValidationErrorForProfileImage(
			AddUserCommandRequest value,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.ProfileImageUrl, messageTransformer!);
		}

		public void ShouldHaveValidationErrorForCreatedAtUtc(
			AddUserCommandRequest value,
			IDateTimeOffsetMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.CreatedAtUtc, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUpdatedAtUtc(
			AddUserCommandRequest value,
			IDateTimeOffsetMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(value, p => p.UpdatedAtUtc, messageTransformer);
		}
	}
}
