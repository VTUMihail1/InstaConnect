using FluentValidation;
using InstaConnect.Identity.Business.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Commands.ConfirmUserEmail;

public class ConfirmUserEmailCommandValidator : AbstractValidator<ConfirmUserEmailCommand>
{
    public ConfirmUserEmailCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.Token)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.TOKEN_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.TOKEN_MAX_LENGTH);
    }
}
