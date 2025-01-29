using FluentValidation;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Validators;

namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;

public class GetAllMessagesQueryValidator : AbstractValidator<GetAllMessagesQuery>
{
    public GetAllMessagesQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(MessageConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(q => q.ReceiverId)
            .MinimumLength(MessageConfigurations.RECEIVER_ID_MIN_LENGTH)
            .MaximumLength(MessageConfigurations.RECEIVER_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.ReceiverId));

        RuleFor(q => q.ReceiverName)
            .MinimumLength(MessageConfigurations.RECEIVER_NAME_MIN_LENGTH)
            .MaximumLength(MessageConfigurations.RECEIVER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.ReceiverName));

        RuleFor(q => q.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<Message>);
    }
}
