namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollower;

public class GetAllFollowsForFollowerQueryRequestValidator : AbstractValidator<GetAllFollowsForFollowerQueryRequest>
{
    public GetAllFollowsForFollowerQueryRequestValidator()
    {
        RuleFor(c => c.FollowerId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.FollowingName)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortTerm)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .FollowPageMinValueWithMessage()
            .FollowPageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .FollowPageSizeMinValueWithMessage()
            .FollowPageSizeMaxValueWithMessage();
    }
}
