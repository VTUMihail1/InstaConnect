using InstaConnect.Common.Utilities;
using InstaConnect.ChatMessages.Common.Features.ChatMessages.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetAll;

public class GetAllChatMessagesQueryRequestValidator : AbstractValidator<GetAllChatMessagesQueryRequest>
{
    public GetAllChatMessagesQueryRequestValidator()
    {
        RuleFor(r => r.Filter.ParticipantOneId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Filter.ParticipantOneId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Filter.ParticipantOneId.Length));

        RuleFor(r => r.Filter.ParticipantTwoId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Filter.ParticipantTwoId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Filter.ParticipantTwoId.Length));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(ChatMessageErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .NotEmpty()
            .WithMessage(ChatMessageErrorMessages.GetPageEmpty())
            .GreaterThanOrEqualTo(ChatMessageConfigurations.PageMinValue)
            .WithMessage(q => ChatMessageErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(ChatMessageConfigurations.PageMaxValue)
            .WithMessage(q => ChatMessageErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .NotEmpty()
            .WithMessage(ChatMessageErrorMessages.GetPageSizeEmpty())
            .GreaterThanOrEqualTo(ChatMessageConfigurations.PageSizeMinValue)
            .WithMessage(q => ChatMessageErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(ChatMessageConfigurations.PageSizeMaxValue)
            .WithMessage(q => ChatMessageErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
