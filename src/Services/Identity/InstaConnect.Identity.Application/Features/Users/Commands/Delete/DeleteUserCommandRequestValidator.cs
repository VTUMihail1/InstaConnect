namespace InstaConnect.Identity.Application.Features.Users.Commands.Delete;

public class DeleteUserCommandRequestValidator : AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
