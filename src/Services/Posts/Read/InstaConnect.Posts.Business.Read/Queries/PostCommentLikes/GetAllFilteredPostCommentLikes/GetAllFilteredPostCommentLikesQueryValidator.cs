using FluentValidation;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetAllFilteredPostCommentLikesQueryValidator : AbstractValidator<GetAllFilteredPostCommentLikesQuery>
{
    public GetAllFilteredPostCommentLikesQueryValidator()
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
