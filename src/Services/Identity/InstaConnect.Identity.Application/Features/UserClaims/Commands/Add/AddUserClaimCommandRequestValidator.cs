namespace InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;

public class AddUserClaimCommandRequestValidator : AbstractValidator<AddUserClaimCommandRequest>
{
	public AddUserClaimCommandRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.Claim)
			.NotEmptyWithMessage();
	}
}
