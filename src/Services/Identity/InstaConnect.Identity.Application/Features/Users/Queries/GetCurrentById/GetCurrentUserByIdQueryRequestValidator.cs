namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;

public class GetCurrentUserByIdQueryRequestValidator : AbstractValidator<GetCurrentUserByIdQueryRequest>
{
	public GetCurrentUserByIdQueryRequestValidator()
	{
		RuleFor(r => r.CurrentId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();
	}
}
