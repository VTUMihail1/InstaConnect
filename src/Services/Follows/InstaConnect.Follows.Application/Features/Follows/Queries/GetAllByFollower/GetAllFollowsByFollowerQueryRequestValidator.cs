namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;

public class GetAllFollowsByFollowerQueryRequestValidator : AbstractValidator<GetAllFollowsByFollowerQueryRequest>
{
    public GetAllFollowsByFollowerQueryRequestValidator()
    {
        RuleFor(c => c.FollowerId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.FollowingName)
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
