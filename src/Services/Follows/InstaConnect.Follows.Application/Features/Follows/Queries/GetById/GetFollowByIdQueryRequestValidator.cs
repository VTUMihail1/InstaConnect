namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public class GetFollowByIdQueryRequestValidator : AbstractValidator<GetFollowByIdQueryRequest>
{
	public GetFollowByIdQueryRequestValidator()
	{
		RuleFor(r => r.FollowerId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.FollowingId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(c => c.CurrentUserId)
			.UserIdMaxLengthWithMessage();
	}
}
