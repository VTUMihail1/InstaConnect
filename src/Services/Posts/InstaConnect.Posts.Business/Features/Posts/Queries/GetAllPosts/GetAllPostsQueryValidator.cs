using FluentValidation;

namespace InstaConnect.Posts.Business.Features.Posts.Queries.GetAllPosts;

public class GetAllPostsQueryValidator : AbstractValidator<GetAllPostsQuery>
{
    public GetAllPostsQueryValidator()
    {
        RuleFor(q => q.Page)
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
