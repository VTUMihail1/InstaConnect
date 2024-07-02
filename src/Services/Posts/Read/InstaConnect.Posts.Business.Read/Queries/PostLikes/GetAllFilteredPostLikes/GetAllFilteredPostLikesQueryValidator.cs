using FluentValidation;

namespace InstaConnect.Posts.Business.Read.Queries.PostLikes.GetAllFilteredPostLikes;

public class GetAllFilteredPostLikesQueryValidator : AbstractValidator<GetAllFilteredPostLikesQuery>
{
    public GetAllFilteredPostLikesQueryValidator()
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
