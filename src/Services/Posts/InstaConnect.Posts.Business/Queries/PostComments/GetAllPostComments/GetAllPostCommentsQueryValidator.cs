using FluentValidation;

namespace InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllPostComments;

public class GetAllPostCommentsQueryValidator : AbstractValidator<GetAllPostCommentsQuery>
{
    public GetAllPostCommentsQueryValidator()
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
