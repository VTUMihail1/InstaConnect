using InstaConnect.Common.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public class GetAllFollowsByFollowerQueryRequestValidator : AbstractValidator<GetAllFollowsByFollowerQueryRequest>
{
    public GetAllFollowsByFollowerQueryRequestValidator()
    {
        RuleFor(r => r.Filter.FollowerId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Filter.FollowerId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Filter.FollowerId.Length));

        RuleFor(c => c.Filter.FollowingName)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(q => UserErrorMessages.GetNameTooLong(q.Filter.FollowingName.Length));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(FollowErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .NotEmpty()
            .WithMessage(FollowErrorMessages.GetPageEmpty())
            .GreaterThanOrEqualTo(FollowConfigurations.PageMinValue)
            .WithMessage(q => FollowErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(FollowConfigurations.PageMaxValue)
            .WithMessage(q => FollowErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .NotEmpty()
            .WithMessage(FollowErrorMessages.GetPageSizeEmpty())
            .GreaterThanOrEqualTo(FollowConfigurations.PageSizeMinValue)
            .WithMessage(q => FollowErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(FollowConfigurations.PageSizeMaxValue)
            .WithMessage(q => FollowErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
