namespace InstaConnect.Chats.Application.Features.Users.Commands.Update;

public class UpdateUserCommandRequestValidator : AbstractValidator<UpdateUserCommandRequest>
{
	public UpdateUserCommandRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.Name)
			.NotEmptyWithMessage()
			.UserNameMinLengthWithMessage()
			.UserNameMaxLengthWithMessage();

		RuleFor(r => r.FirstName)
			.NotEmptyWithMessage()
			.UserFirstNameMinLengthWithMessage()
			.UserFirstNameMaxLengthWithMessage();

		RuleFor(r => r.LastName)
			.NotEmptyWithMessage()
			.UserLastNameMinLengthWithMessage()
			.UserLastNameMaxLengthWithMessage();

		RuleFor(r => r.Email)
			.NotEmptyWithMessage()
			.UserEmailMinLengthWithMessage()
			.UserEmailMaxLengthWithMessage()
			.InvalidEmailWithMessage();

		RuleFor(r => r.ProfileImageUrl)
			.UserProfileImageUrlMaxLengthWithMessage();

		RuleFor(r => r.UpdatedAtUtc)
			.NotEmptyWithMessage();
	}
}
