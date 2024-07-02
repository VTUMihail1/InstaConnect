using FluentValidation;

namespace InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllPostCommentLikes;

public class GetAllPostCommentLikesQueryValidator : AbstractValidator<GetAllPostCommentLikesQuery>
{
    public GetAllPostCommentLikesQueryValidator()
    {
        RuleFor(q => q.Offset)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.Limit)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty()
            .IsInEnum();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}
