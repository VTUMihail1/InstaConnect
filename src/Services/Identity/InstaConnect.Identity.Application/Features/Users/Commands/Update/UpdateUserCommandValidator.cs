namespace InstaConnect.Identity.Application.Features.Users.Commands.Update;
public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

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
    }
}
