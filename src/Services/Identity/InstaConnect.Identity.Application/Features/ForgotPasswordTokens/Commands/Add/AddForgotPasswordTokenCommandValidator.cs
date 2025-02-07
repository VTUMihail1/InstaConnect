using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.SendUserPasswordReset;
public class AddForgotPasswordTokenCommandValidator : AbstractValidator<AddForgotPasswordTokenCommand>
{
    public AddForgotPasswordTokenCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty()
            .MinimumLength(UserConfigurations.EmailMinLength)
            .MaximumLength(UserConfigurations.EmailMaxLength);
        ;
    }
}
