using FluentValidation;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllPostComments;

public class GetAllPostCommentsQueryValidator : AbstractValidator<GetAllPostCommentsQuery>
{
    public GetAllPostCommentsQueryValidator()
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
