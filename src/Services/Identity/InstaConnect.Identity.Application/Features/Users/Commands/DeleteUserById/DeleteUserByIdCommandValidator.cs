using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteUserById;

public class DeleteUserByIdCommandValidator : AbstractValidator<DeleteUserByIdCommand>
{
    public DeleteUserByIdCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.ID_MAX_LENGTH);
    }
}
