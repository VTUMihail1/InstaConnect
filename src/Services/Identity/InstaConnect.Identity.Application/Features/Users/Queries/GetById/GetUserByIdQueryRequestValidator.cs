namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryRequestValidator : AbstractValidator<GetUserByIdQueryRequest>
{
    public GetUserByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.CurrentId)
            .UserIdMaxLengthWithMessage();
    }
}
