namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public class GetAllPostCommentLikesQueryRequestValidator : AbstractValidator<GetAllPostCommentLikesQueryRequest>
{
    public GetAllPostCommentLikesQueryRequestValidator()
    {
        RuleFor(r => r.Filter.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Filter.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Filter.Id.Length));

        RuleFor(r => r.Filter.CommentId)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetIdEmpty())
            .MinimumLength(PostCommentConfigurations.IdMinLength)
            .WithMessage(r => PostCommentErrorMessages.GetIdTooShort(r.Filter.CommentId.Length))
            .MaximumLength(PostCommentConfigurations.IdMaxLength)
            .WithMessage(r => PostCommentErrorMessages.GetIdTooLong(r.Filter.CommentId.Length));

        RuleFor(c => c.Filter.UserName)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(q => UserErrorMessages.GetNameTooLong(q.Filter.UserName.Length));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(PostCommentLikeErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .NotEmpty()
            .WithMessage(PostCommentLikeErrorMessages.GetPageEmpty())
            .GreaterThanOrEqualTo(PostCommentLikeConfigurations.PageMinValue)
            .WithMessage(q => PostCommentLikeErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(PostCommentLikeConfigurations.PageMaxValue)
            .WithMessage(q => PostCommentLikeErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .NotEmpty()
            .WithMessage(PostCommentLikeErrorMessages.GetPageSizeEmpty())
            .GreaterThanOrEqualTo(PostCommentLikeConfigurations.PageSizeMinValue)
            .WithMessage(q => PostCommentLikeErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(PostCommentLikeConfigurations.PageSizeMaxValue)
            .WithMessage(q => PostCommentLikeErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
