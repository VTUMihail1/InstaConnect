using FluentValidation;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;

public class GetAllFilteredPostCommentsQueryValidator : AbstractValidator<GetAllFilteredPostCommentsQuery>
{
    public GetAllFilteredPostCommentsQueryValidator()
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
