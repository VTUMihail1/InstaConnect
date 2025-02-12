using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
public class AddEmailConfirmationTokenCommandValidator : AbstractValidator<AddEmailConfirmationTokenCommand>
{
    public AddEmailConfirmationTokenCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty()
            .MinimumLength(UserConfigurations.EmailMinLength)
            .MaximumLength(UserConfigurations.EmailMaxLength);
    }
}
