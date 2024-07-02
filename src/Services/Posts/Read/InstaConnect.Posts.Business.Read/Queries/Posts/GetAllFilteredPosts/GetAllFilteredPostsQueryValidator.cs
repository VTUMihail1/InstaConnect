using FluentValidation;
using InstaConnect.Posts.Business.Read.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetAllFilteredPosts;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetAllFilteredPostsQueryValidator : AbstractValidator<GetAllFilteredPostsQuery>
{
    public GetAllFilteredPostsQueryValidator()
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
