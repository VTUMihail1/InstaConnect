﻿using FluentValidation;
using InstaConnect.Messages.Common.Features.Messages.Utilities;

namespace InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;
public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
{
    public UpdateMessageCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.CONTENT_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.CONTENT_MAX_LENGTH);
    }
}
