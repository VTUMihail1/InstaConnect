using FluentValidation;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;

public class GetAllFilteredMessagesQueryValidator : AbstractValidator<GetAllFilteredMessagesQuery>
{
    public GetAllFilteredMessagesQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(q => q.ReceiverId)
            .MinimumLength(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.ReceiverId));

        RuleFor(q => q.ReceiverName)
            .MinimumLength(MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.ReceiverName));

        RuleFor(q => q.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<Message>);
    }
}
