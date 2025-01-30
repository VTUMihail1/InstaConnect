using FluentValidation;
using InstaConnect.Messages.Common.Features.Messages.Utilities;

namespace InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
public class AddMessageCommandValidator : AbstractValidator<AddMessageCommand>
{
    public AddMessageCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(MessageConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.ReceiverId)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.RECEIVER_ID_MIN_LENGTH)
            .MaximumLength(MessageConfigurations.RECEIVER_ID_MAX_LENGTH);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.ContentMinLength)
            .MaximumLength(MessageConfigurations.ContentMaxLength);
    }
}
