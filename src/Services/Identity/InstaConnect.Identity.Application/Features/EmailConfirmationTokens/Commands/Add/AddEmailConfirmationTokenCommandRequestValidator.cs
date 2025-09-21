using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Commands.Add;
public class AddEmailConfirmationTokenCommandRequestValidator : AbstractValidator<AddEmailConfirmationTokenCommandRequest>
{
    public AddEmailConfirmationTokenCommandRequestValidator()
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
