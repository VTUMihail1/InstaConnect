namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
public class AddForgotPasswordTokenCommandRequestValidator : AbstractValidator<AddForgotPasswordTokenCommandRequest>
{
    public AddForgotPasswordTokenCommandRequestValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetNameEmpty())
            .MinimumLength(UserConfigurations.NameMinLength)
            .WithMessage(r => UserErrorMessages.GetNameTooShort(r.Name.Length))
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(r => UserErrorMessages.GetNameTooLong(r.Name.Length));
    }
}
