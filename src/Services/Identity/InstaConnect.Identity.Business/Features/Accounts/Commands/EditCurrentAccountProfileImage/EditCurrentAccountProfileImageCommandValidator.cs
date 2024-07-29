using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccountProfileImage;
public class EditCurrentAccountProfileImageCommandValidator : AbstractValidator<EditCurrentAccountProfileImageCommand>
{
    public EditCurrentAccountProfileImageCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.ProfileImage)
            .NotEmpty();
    }
}
