namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

public class GetAllChatsQueryRequestValidator : AbstractValidator<GetAllChatsQueryRequest>
{
    public GetAllChatsQueryRequestValidator()
    {
        RuleFor(c => c.ParticipantOneId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.ParticipantTwoName)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortTerm)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .ChatPageMinValueWithMessage()
            .ChatPageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .ChatPageSizeMinValueWithMessage()
            .ChatPageSizeMaxValueWithMessage();
    }
}
