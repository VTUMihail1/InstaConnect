namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;

public class GetAllFollowsByFollowerQueryRequestValidator : AbstractValidator<GetAllFollowsByFollowerQueryRequest>
{
    public GetAllFollowsByFollowerQueryRequestValidator()
    {
        RuleFor(c => c.Filter.FollowerId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.Filter.FollowingName.Value)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.Sorting.Order)
            .NotEmptyWithMessage();

        RuleFor(q => q.Sorting.Property)
            .NotEmptyWithMessage();

        RuleFor(q => q.Pagination.Page)
            .NotEmptyWithMessage()
            .FollowPageMinValueWithMessage()
            .FollowPageMaxValueWithMessage();

        RuleFor(q => q.Pagination.PageSize)
            .NotEmptyWithMessage()
            .FollowPageSizeMinValueWithMessage()
            .FollowPageSizeMaxValueWithMessage();
    }
}
