using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Users.Application.Features.Users.Commands.Delete;
public class DeleteUserCommandRequestValidator : AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Id.Length));
    }
}
