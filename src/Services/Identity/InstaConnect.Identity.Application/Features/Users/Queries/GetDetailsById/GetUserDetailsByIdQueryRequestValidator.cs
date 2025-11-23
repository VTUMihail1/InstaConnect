namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

public class GetUserDetailsByIdQueryRequestValidator : AbstractValidator<GetUserDetailsByIdQueryRequest>
{
    public GetUserDetailsByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
