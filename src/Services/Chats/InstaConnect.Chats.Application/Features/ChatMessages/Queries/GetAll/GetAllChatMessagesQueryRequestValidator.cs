namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

public class GetAllChatMessagesQueryRequestValidator : AbstractValidator<GetAllChatMessagesQueryRequest>
{
    public GetAllChatMessagesQueryRequestValidator()
    {
        RuleFor(c => c.Filter.Id.ParticipantOneId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.Filter.Id.ParticipantTwoId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(q => q.Sorting.Order)
            .NotEmptyWithMessage();

        RuleFor(q => q.Sorting.Property)
            .NotEmptyWithMessage();

        RuleFor(q => q.Pagination.Page)
            .NotEmptyWithMessage()
            .ChatMessagePageMinValueWithMessage()
            .ChatMessagePageMaxValueWithMessage();

        RuleFor(q => q.Pagination.PageSize)
            .NotEmptyWithMessage()
            .ChatMessagePageSizeMinValueWithMessage()
            .ChatMessagePageSizeMaxValueWithMessage();
    }
}
