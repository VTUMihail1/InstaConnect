namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

public class GetCurrentUserDetailsByIdQueryRequestValidator : AbstractValidator<GetCurrentUserDetailsByIdQueryRequest>
{
    public GetCurrentUserDetailsByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
