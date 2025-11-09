namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryRequestValidator : AbstractValidator<GetAllPostsQueryRequest>
{
    public GetAllPostsQueryRequestValidator()
    {
        RuleFor(c => c.Filter.UserId)
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(q => UserErrorMessages.GetIdTooLong(q.Filter.UserId.Length));

        RuleFor(c => c.Filter.UserName)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(q => UserErrorMessages.GetNameTooLong(q.Filter.UserName.Length));

        RuleFor(c => c.Filter.Title)
            .MaximumLength(PostConfigurations.TitleMaxLength)
            .WithMessage(q => PostErrorMessages.GetTitleTooLong(q.Filter.Title.Length));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetPageEmpty())
            .GreaterThanOrEqualTo(PostConfigurations.PageMinValue)
            .WithMessage(q => PostErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(PostConfigurations.PageMaxValue)
            .WithMessage(q => PostErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetPageSizeEmpty())
            .GreaterThanOrEqualTo(PostConfigurations.PageSizeMinValue)
            .WithMessage(q => PostErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(PostConfigurations.PageSizeMaxValue)
            .WithMessage(q => PostErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
