namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

public class GetCurrentUserDetailsByIdQueryRequestValidator : AbstractValidator<GetCurrentUserDetailsByIdQueryRequest>
{
    public GetCurrentUserDetailsByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
