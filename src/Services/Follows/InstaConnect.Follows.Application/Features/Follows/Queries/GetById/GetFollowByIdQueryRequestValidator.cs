namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public class GetFollowByIdQueryRequestValidator : AbstractValidator<GetFollowByIdQueryRequest>
{
    public GetFollowByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.FollowerId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.FollowingId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
