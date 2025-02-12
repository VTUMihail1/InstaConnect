using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(c => c.UserName)
            .NotEmpty()
            .MinimumLength(UserConfigurations.NameMinLength)
            .MaximumLength(UserConfigurations.NameMaxLength);

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(UserConfigurations.FirstNameMinLength)
            .MaximumLength(UserConfigurations.FirstNameMaxLength);

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(UserConfigurations.LastNameMinLength)
            .MaximumLength(UserConfigurations.LastNameMaxLength);

        RuleFor(c => c.Email)
            .NotEmpty()
            .MinimumLength(UserConfigurations.EmailMinLength)
            .MaximumLength(UserConfigurations.EmailMaxLength);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(UserConfigurations.PasswordMinLength)
            .MaximumLength(UserConfigurations.PasswordMaxLength);

        RuleFor(c => c.ConfirmPassword)
            .Equal(c => c.Password);
    }
}
