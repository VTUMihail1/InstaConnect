namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

public class GetChatByIdQueryRequestValidator : AbstractValidator<GetChatByIdQueryRequest>
{
    public GetChatByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.ParticipantOneId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.ParticipantTwoId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
