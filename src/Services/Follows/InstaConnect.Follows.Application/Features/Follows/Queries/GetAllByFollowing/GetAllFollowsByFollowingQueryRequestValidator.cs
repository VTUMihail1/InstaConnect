namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;

public class GetAllFollowsByFollowingQueryRequestValidator : AbstractValidator<GetAllFollowsByFollowingQueryRequest>
{
    public GetAllFollowsByFollowingQueryRequestValidator()
    {
        RuleFor(c => c.FollowingId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.FollowerName)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortProperty)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .FollowPageMinValueWithMessage()
            .FollowPageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .FollowPageSizeMinValueWithMessage()
            .FollowPageSizeMaxValueWithMessage();
    }
}
