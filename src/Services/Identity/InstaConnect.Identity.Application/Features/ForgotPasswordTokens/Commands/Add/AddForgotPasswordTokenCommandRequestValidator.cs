namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

public class AddForgotPasswordTokenCommandRequestValidator : AbstractValidator<AddForgotPasswordTokenCommandRequest>
{
	public AddForgotPasswordTokenCommandRequestValidator()
	{
		RuleFor(r => r.Name)
			.NotEmptyWithMessage()
			.UserNameMinLengthWithMessage()
			.UserNameMaxLengthWithMessage();
	}
}
