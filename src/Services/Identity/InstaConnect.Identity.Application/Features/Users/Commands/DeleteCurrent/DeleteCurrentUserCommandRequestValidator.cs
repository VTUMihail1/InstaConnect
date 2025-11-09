namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;
public class DeleteCurrentUserCommandRequestValidator : AbstractValidator<DeleteCurrentUserCommandRequest>
{
    public DeleteCurrentUserCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Id.Length));
    }
}
