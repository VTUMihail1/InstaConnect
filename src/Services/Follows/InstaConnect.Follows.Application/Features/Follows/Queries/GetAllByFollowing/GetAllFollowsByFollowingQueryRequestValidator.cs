namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;

public class GetAllFollowsByFollowingQueryRequestValidator : AbstractValidator<GetAllFollowsByFollowingQueryRequest>
{
    public GetAllFollowsByFollowingQueryRequestValidator()
    {
        RuleFor(c => c.Filter.FollowingId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.Filter.FollowerName.Value)
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
