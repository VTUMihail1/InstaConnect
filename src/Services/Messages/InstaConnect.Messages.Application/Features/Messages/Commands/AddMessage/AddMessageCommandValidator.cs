using FluentValidation;
using InstaConnect.Messages.Common.Features.Messages.Utilities;

namespace InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
public class AddMessageCommandValidator : AbstractValidator<AddMessageCommand>
{
    public AddMessageCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.ReceiverId)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.CONTENT_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.CONTENT_MAX_LENGTH);
    }
}
