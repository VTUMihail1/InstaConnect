namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

public class GetChatByIdQueryRequestValidator : AbstractValidator<GetChatByIdQueryRequest>
{
	public GetChatByIdQueryRequestValidator()
	{
		RuleFor(r => r.ParticipantTwoId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(c => c.CurrentUserId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();
	}
}
