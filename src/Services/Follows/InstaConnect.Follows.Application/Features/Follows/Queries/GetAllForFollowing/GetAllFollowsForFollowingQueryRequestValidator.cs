namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;

public class GetAllFollowsForFollowingQueryRequestValidator : AbstractValidator<GetAllFollowsForFollowingQueryRequest>
{
    public GetAllFollowsForFollowingQueryRequestValidator()
    {
        RuleFor(c => c.FollowingId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.FollowerName)
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
