namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

public class GetChatByIdQueryRequestValidator : AbstractValidator<GetChatByIdQueryRequest>
{
    public GetChatByIdQueryRequestValidator()
    {
        RuleFor(r => r.ParticipantOneId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.ParticipantTwoId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
