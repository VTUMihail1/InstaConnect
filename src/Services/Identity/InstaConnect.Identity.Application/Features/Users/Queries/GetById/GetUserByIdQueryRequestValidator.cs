namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryRequestValidator : AbstractValidator<GetUserByIdQueryRequest>
{
    public GetUserByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
