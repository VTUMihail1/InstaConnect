namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;

public class DeleteCurrentUserCommandRequestValidator : AbstractValidator<DeleteCurrentUserCommandRequest>
{
	public DeleteCurrentUserCommandRequestValidator()
	{
		RuleFor(r => r.CurrentId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();
	}
}
