using FluentValidation;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllFilteredPostComments;

public class GetAllFilteredPostCommentsQueryValidator : AbstractValidator<GetAllFilteredPostCommentsQuery>
{
    public GetAllFilteredPostCommentsQueryValidator()
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
