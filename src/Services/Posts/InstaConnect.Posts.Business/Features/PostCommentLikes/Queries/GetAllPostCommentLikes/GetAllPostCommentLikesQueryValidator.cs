using FluentValidation;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;

public class GetAllPostCommentLikesQueryValidator : AbstractValidator<GetAllPostCommentLikesQuery>
{
    public GetAllPostCommentLikesQueryValidator()
    {
        RuleFor(q => q.Page)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.PageSize)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty()
            .IsInEnum();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}
