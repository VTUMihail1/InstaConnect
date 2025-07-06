using FluentValidation;

using InstaConnect.Common.Application.Validators;
using InstaConnect.Common.Utilities;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryValidator : AbstractValidator<GetAllPostsQuery>
{
    public GetAllPostsQueryValidator()
    {
        RuleFor(c => c.Filter.UserId)
    .MaximumLength(UserConfigurations.IdMaxLength)
    .WithMessage(q => UserErrorMessages.GetIdTooLong(q.Filter.UserId));

        RuleFor(c => c.Filter.UserName)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(q => UserErrorMessages.GetNameTooLong(q.Filter.UserName));

        RuleFor(c => c.Filter.Title)
            .MaximumLength(PostConfigurations.TitleMaxLength)
            .WithMessage(q => PostErrorMessages.GetTitleTooLong(q.Filter.Title));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .GreaterThanOrEqualTo(PostConfigurations.PageMinValue)
            .WithMessage(q => PostErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(PostConfigurations.PageMaxValue)
            .WithMessage(q => PostErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .GreaterThanOrEqualTo(PostConfigurations.PageSizeMinValue)
            .WithMessage(q => PostErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(PostConfigurations.PageSizeMaxValue)
            .WithMessage(q => PostErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
