using FluentValidation;

namespace InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllFilteredPostLikes;

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
