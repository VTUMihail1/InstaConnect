namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public class GetAllPostCommentsQueryRequestValidator : AbstractValidator<GetAllPostCommentsQueryRequest>
{
    public GetAllPostCommentsQueryRequestValidator()
    {
        RuleFor(c => c.Filter.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Filter.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Filter.Id.Length));

        RuleFor(c => c.Filter.UserId)
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(q => UserErrorMessages.GetIdTooLong(q.Filter.UserId.Length));

        RuleFor(c => c.Filter.UserName)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(q => UserErrorMessages.GetNameTooLong(q.Filter.UserName.Length));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetPageEmpty())
            .GreaterThanOrEqualTo(PostCommentConfigurations.PageMinValue)
            .WithMessage(q => PostCommentErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(PostCommentConfigurations.PageMaxValue)
            .WithMessage(q => PostCommentErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetPageSizeEmpty())
            .GreaterThanOrEqualTo(PostCommentConfigurations.PageSizeMinValue)
            .WithMessage(q => PostCommentErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(PostCommentConfigurations.PageSizeMaxValue)
            .WithMessage(q => PostCommentErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
