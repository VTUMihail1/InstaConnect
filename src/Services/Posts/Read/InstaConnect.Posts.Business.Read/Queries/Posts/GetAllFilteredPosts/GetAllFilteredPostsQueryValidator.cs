using FluentValidation;

namespace InstaConnect.Posts.Business.Read.Queries.Posts.GetAllFilteredPosts;

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
