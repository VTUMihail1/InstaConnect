using InstaConnect.Common.Application.Validators;
using InstaConnect.Common.Utilities;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryValidator : AbstractValidator<GetAllPostsQuery>
{
    public GetAllPostsQueryValidator()
    {
        RuleFor(c => c.Filter.UserId)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.Filter.UserName)
            .MaximumLength(UserConfigurations.NameMaxLength);

        RuleFor(c => c.Filter.Title)
            .MaximumLength(PostConfigurations.TitleMaxLength);

        RuleFor(q => q.Sorting.Order)
            .NotEmpty();

        RuleFor(q => q.Sorting.Property)
            .NotEmpty();

        RuleFor(q => q.Pagination.Page)
            .LessThanOrEqualTo(PostConfigurations.PageMaxValue)
            .GreaterThanOrEqualTo(PostConfigurations.PageMinValue);

        RuleFor(q => q.Pagination.PageSize)
            .LessThanOrEqualTo(PostConfigurations.PageSizeMaxValue)
            .GreaterThanOrEqualTo(PostConfigurations.PageSizeMinValue);
    }
}
