using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Commands.ResendUserEmailConfirmation;
public class ResendUserEmailConfirmationCommandValidator : AbstractValidator<ResendUserEmailConfirmationCommand>
{
    public ResendUserEmailConfirmationCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.EMAIL_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.EMAIL_MAX_LENGTH);
    }
}
