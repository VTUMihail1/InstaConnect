using InstaConnect.Common.Utilities;
using InstaConnect.Chats.Common.Features.Chats.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

public class GetAllChatsByParticipantQueryRequestValidator : AbstractValidator<GetAllChatsByParticipantQueryRequest>
{
    public GetAllChatsByParticipantQueryRequestValidator()
    {
        RuleFor(r => r.Filter.ParticipantId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Filter.ParticipantId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Filter.ParticipantId.Length));

        RuleFor(c => c.Filter.ParticipantName)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(q => UserErrorMessages.GetNameTooLong(q.Filter.ParticipantName.Length));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(ChatErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .NotEmpty()
            .WithMessage(ChatErrorMessages.GetPageEmpty())
            .GreaterThanOrEqualTo(ChatConfigurations.PageMinValue)
            .WithMessage(q => ChatErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(ChatConfigurations.PageMaxValue)
            .WithMessage(q => ChatErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .NotEmpty()
            .WithMessage(ChatErrorMessages.GetPageSizeEmpty())
            .GreaterThanOrEqualTo(ChatConfigurations.PageSizeMinValue)
            .WithMessage(q => ChatErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(ChatConfigurations.PageSizeMaxValue)
            .WithMessage(q => ChatErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
