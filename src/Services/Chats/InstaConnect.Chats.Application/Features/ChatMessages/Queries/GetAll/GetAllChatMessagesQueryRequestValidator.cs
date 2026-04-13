namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

public class GetAllChatMessagesQueryRequestValidator : AbstractValidator<GetAllChatMessagesQueryRequest>
{
    public GetAllChatMessagesQueryRequestValidator()
    {
        RuleFor(c => c.ParticipantTwoId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.CurrentUserId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortTerm)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .ChatMessagePageMinValueWithMessage()
            .ChatMessagePageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .ChatMessagePageSizeMinValueWithMessage()
            .ChatMessagePageSizeMaxValueWithMessage();
    }
}
