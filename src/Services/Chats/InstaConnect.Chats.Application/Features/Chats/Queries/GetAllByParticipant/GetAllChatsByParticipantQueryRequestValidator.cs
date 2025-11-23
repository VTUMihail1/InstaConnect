namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;

public class GetAllChatsByParticipantQueryRequestValidator : AbstractValidator<GetAllChatsByParticipantQueryRequest>
{
    public GetAllChatsByParticipantQueryRequestValidator()
    {
        RuleFor(c => c.Filter.ParticipantId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.Filter.ParticipantName.Value)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.Sorting.Order)
            .NotEmptyWithMessage();

        RuleFor(q => q.Sorting.Property)
            .NotEmptyWithMessage();

        RuleFor(q => q.Pagination.Page)
            .NotEmptyWithMessage()
            .ChatPageMinValueWithMessage()
            .ChatPageMaxValueWithMessage();

        RuleFor(q => q.Pagination.PageSize)
            .NotEmptyWithMessage()
            .ChatPageSizeMinValueWithMessage()
            .ChatPageSizeMaxValueWithMessage();
    }
}
