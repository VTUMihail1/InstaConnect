using FluentValidation;

namespace InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllFilteredPostLikes;

public class GetAllFilteredPostLikesQueryValidator : AbstractValidator<GetAllFilteredPostLikesQuery>
{
    public GetAllFilteredPostLikesQueryValidator()
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
