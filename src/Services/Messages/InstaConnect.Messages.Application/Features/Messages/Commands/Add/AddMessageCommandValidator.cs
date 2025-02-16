using FluentValidation;

using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;

namespace InstaConnect.Messages.Application.Features.Messages.Commands.Add;
public class AddMessageCommandValidator : AbstractValidator<AddMessageCommand>
{
    public AddMessageCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.ReceiverId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.ContentMinLength)
            .MaximumLength(MessageConfigurations.ContentMaxLength);
    }
}
