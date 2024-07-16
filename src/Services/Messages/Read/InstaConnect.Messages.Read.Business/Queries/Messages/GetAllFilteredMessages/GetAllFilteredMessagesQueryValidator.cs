using FluentValidation;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

public class GetAllFilteredMessagesQueryValidator : AbstractValidator<GetAllFilteredMessagesQuery>
{
    public GetAllFilteredMessagesQueryValidator(
        IEnumValidator enumValidator,
        IEntityPropertyValidator entityPropertyValidator)
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(q => q.ReceiverId)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH);

        RuleFor(q => q.ReceiverName)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH);

        RuleFor(q => q.SortOrder)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH)
            .Must(enumValidator.IsEnumValid<SortOrder>);

        RuleFor(q => q.SortPropertyName)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH)
            .Must(entityPropertyValidator.IsEntityPropertyValid<Message>);

        RuleFor(q => q.Limit)
            .LessThanOrEqualTo(MessageBusinessConfigurations.LIMIT_MAX_VALUE)
            .GreaterThanOrEqualTo(MessageBusinessConfigurations.LIMIT_MIN_VALUE);

        RuleFor(q => q.Offset)
            .LessThanOrEqualTo(MessageBusinessConfigurations.OFFSET_MAX_VALUE)
            .GreaterThanOrEqualTo(MessageBusinessConfigurations.OFFSET_MIN_VALUE);
    }
}
