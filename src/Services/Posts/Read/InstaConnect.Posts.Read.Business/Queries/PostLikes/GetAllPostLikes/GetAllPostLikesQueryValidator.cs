using FluentValidation;

namespace InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllPostLikes;

public class GetAllPostLikesQueryValidator : AbstractValidator<GetAllPostLikesQuery>
{
    public GetAllPostLikesQueryValidator()
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
