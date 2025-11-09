namespace InstaConnect.Posts.Application.Features.Users.Commands.Add;
public class AddUserCommandRequestValidator : AbstractValidator<AddUserCommandRequest>
{
    public AddUserCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetNameEmpty())
            .MinimumLength(UserConfigurations.NameMinLength)
            .WithMessage(r => UserErrorMessages.GetNameTooShort(r.Name.Length))
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(r => UserErrorMessages.GetNameTooLong(r.Name.Length));

        RuleFor(r => r.FirstName)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetFirstNameEmpty())
            .MinimumLength(UserConfigurations.FirstNameMinLength)
            .WithMessage(r => UserErrorMessages.GetFirstNameTooShort(r.FirstName.Length))
            .MaximumLength(UserConfigurations.FirstNameMaxLength)
            .WithMessage(r => UserErrorMessages.GetFirstNameTooLong(r.FirstName.Length));

        RuleFor(r => r.LastName)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetLastNameEmpty())
            .MinimumLength(UserConfigurations.LastNameMinLength)
            .WithMessage(r => UserErrorMessages.GetLastNameTooShort(r.LastName.Length))
            .MaximumLength(UserConfigurations.LastNameMaxLength)
            .WithMessage(r => UserErrorMessages.GetLastNameTooLong(r.LastName.Length));

        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetEmailEmpty())
            .MinimumLength(UserConfigurations.EmailMinLength)
            .WithMessage(r => UserErrorMessages.GetEmailTooShort(r.Email.Length))
            .MaximumLength(UserConfigurations.EmailMaxLength)
            .WithMessage(r => UserErrorMessages.GetEmailTooLong(r.Email.Length));

        RuleFor(r => r.ProfileImage)
            .MaximumLength(UserConfigurations.ProfileImageMaxLength)
            .WithMessage(r => UserErrorMessages.GetProfileImageTooLong(r.ProfileImage!.Length))
            .When(p => p.ProfileImage != null);
    }
}
