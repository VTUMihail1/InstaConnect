using FluentValidation;

namespace InstaConnect.Posts.Business.Features.Posts.Queries.GetAllFilteredPosts;

public class GetAllFilteredPostsQueryValidator : AbstractValidator<GetAllFilteredPostsQuery>
{
    public GetAllFilteredPostsQueryValidator()
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
