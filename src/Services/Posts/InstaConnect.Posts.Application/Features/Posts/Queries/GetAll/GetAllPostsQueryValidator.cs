using InstaConnect.Common.Application.Validators;
using InstaConnect.Common.Utilities;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryValidator : AbstractValidator<GetAllPostsQuery>
{
    public GetAllPostsQueryValidator()
    {
        RuleFor(c => c.Filter.UserId)
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(UserErrorMessages.IdTooLong);

        RuleFor(c => c.Filter.UserName)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(UserErrorMessages.NameTooLong);

        RuleFor(c => c.Filter.Title)
            .MaximumLength(PostConfigurations.TitleMaxLength)
            .WithMessage(PostErrorMessages.TitleTooLong);

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.SortOrderEmpty);

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(PostErrorMessages.SortPropertyEmpty);

        RuleFor(q => q.Pagination.Page)
            .GreaterThanOrEqualTo(PostConfigurations.PageMinValue)
            .WithMessage(PostErrorMessages.PageSizeTooSmall)
            .LessThanOrEqualTo(PostConfigurations.PageMaxValue)
            .WithMessage(PostErrorMessages.PageSizeTooLarge);

        RuleFor(q => q.Pagination.PageSize)
            .GreaterThanOrEqualTo(PostConfigurations.PageSizeMinValue)
            .LessThanOrEqualTo(PostConfigurations.PageSizeMaxValue);
    }
}
