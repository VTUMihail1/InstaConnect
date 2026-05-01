namespace InstaConnect.Follows.Application.Tests.Features.Users.Assertions;

public static class UserValidationAssertions
{
	extension(TestValidationResult<UpdateUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForFirstName(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.FirstName, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForLastName(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.LastName, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForEmail(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Email, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForProfileImage(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.ProfileImageUrl, messageTransformer!, value);
		}

		public void ShouldHaveValidationErrorForUpdatedAtUtc(
			IDateTimeOffsetMessageTransformer messageTransformer,
			UpdateUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UpdatedAtUtc, messageTransformer, value);
		}
	}

	extension(TestValidationResult<DeleteUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			DeleteUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, value);
		}
	}

	extension(TestValidationResult<AddUserCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForFirstName(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.FirstName, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForLastName(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.LastName, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForEmail(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Email, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForProfileImage(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.ProfileImageUrl, messageTransformer!, value);
		}

		public void ShouldHaveValidationErrorForCreatedAtUtc(
			IDateTimeOffsetMessageTransformer messageTransformer,
			AddUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.CreatedAtUtc, messageTransformer, value);
		}

		public void ShouldHaveValidationErrorForUpdatedAtUtc(
			IDateTimeOffsetMessageTransformer messageTransformer,
			AddUserCommandRequest value)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.UpdatedAtUtc, messageTransformer, value);
		}
	}
}
