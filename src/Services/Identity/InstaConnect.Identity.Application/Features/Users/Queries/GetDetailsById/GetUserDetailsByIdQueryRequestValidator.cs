namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

public class GetUserDetailsByIdQueryRequestValidator : AbstractValidator<GetUserDetailsByIdQueryRequest>
{
    public GetUserDetailsByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.CurrentId)
            .UserIdMaxLengthWithMessage();
    }
}
