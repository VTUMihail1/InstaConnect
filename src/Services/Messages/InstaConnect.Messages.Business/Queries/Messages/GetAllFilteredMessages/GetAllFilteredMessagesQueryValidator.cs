using FluentValidation;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;

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
            .MinimumLength(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.ReceiverId));

        RuleFor(q => q.ReceiverName)
            .MinimumLength(MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.ReceiverName));

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

        RuleFor(q => q.Page)
            .LessThanOrEqualTo(MessageBusinessConfigurations.PAGE_MAX_VALUE)
            .GreaterThanOrEqualTo(MessageBusinessConfigurations.PAGE_MIN_VALUE);

        RuleFor(q => q.PageSize)
            .LessThanOrEqualTo(MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE)
            .GreaterThanOrEqualTo(MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE);
    }
}
