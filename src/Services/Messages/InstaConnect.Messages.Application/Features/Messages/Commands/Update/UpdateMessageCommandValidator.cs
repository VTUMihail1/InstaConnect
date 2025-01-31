using FluentValidation;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;

namespace InstaConnect.Messages.Application.Features.Messages.Commands.UpdateMessage;
public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
{
    public UpdateMessageCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.IdMinLength)
            .MaximumLength(MessageConfigurations.IdMaxLength);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.ContentMinLength)
            .MaximumLength(MessageConfigurations.ContentMaxLength);
    }
}
