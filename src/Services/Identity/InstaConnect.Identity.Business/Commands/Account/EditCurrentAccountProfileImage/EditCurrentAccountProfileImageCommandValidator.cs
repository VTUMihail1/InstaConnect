using FluentValidation;

namespace InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;
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
