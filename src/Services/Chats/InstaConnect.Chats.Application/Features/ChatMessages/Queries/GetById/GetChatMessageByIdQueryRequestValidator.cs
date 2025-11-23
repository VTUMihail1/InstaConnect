namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

public class GetChatMessageByIdQueryRequestValidator : AbstractValidator<GetChatMessageByIdQueryRequest>
{
    public GetChatMessageByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.Id.ParticipantOneId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.Id.ParticipantTwoId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.MessageId)
            .NotEmptyWithMessage()
            .ChatMessageIdMinLengthWithMessage()
            .ChatMessageIdMaxLengthWithMessage();
    }
}
