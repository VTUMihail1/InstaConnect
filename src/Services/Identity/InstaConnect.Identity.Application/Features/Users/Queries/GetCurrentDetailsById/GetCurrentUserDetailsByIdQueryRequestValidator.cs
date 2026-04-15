namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

public class GetCurrentUserDetailsByIdQueryRequestValidator : AbstractValidator<GetCurrentUserDetailsByIdQueryRequest>
{
    public GetCurrentUserDetailsByIdQueryRequestValidator()
    {
        RuleFor(r => r.CurrentId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
