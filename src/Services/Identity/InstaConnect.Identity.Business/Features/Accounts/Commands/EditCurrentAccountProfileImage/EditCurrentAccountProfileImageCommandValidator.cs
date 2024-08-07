using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccountProfileImage;
public class EditCurrentAccountProfileImageCommandValidator : AbstractValidator<EditCurrentAccountProfileImageCommand>
{
    public EditCurrentAccountProfileImageCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.ProfileImage)
            .NotEmpty();
    }
}
