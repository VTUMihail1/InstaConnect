namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;

public class GetAllChatsByParticipantQueryRequestValidator : AbstractValidator<GetAllChatsByParticipantQueryRequest>
{
    public GetAllChatsByParticipantQueryRequestValidator()
    {
        RuleFor(c => c.ParticipantId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.ParticipantName)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortProperty)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .ChatPageMinValueWithMessage()
            .ChatPageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .ChatPageSizeMinValueWithMessage()
            .ChatPageSizeMaxValueWithMessage();
    }
}
