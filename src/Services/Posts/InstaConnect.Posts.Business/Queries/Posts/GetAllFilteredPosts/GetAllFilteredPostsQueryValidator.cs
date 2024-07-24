using FluentValidation;

namespace InstaConnect.Posts.Read.Business.Queries.Posts.GetAllFilteredPosts;

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
