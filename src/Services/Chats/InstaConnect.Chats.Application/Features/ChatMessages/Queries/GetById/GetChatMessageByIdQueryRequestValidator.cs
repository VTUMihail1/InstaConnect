namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

public class GetChatMessageByIdQueryRequestValidator : AbstractValidator<GetChatMessageByIdQueryRequest>
{
    public GetChatMessageByIdQueryRequestValidator()
    {
        RuleFor(r => r.ParticipantTwoId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.MessageId)
            .NotEmptyWithMessage()
            .ChatMessageIdMinLengthWithMessage()
            .ChatMessageIdMaxLengthWithMessage();

        RuleFor(r => r.CurrentUserId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
