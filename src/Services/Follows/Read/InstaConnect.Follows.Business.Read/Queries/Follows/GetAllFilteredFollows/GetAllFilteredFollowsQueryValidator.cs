using FluentValidation;

namespace InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFilteredFollows;
public class GetAllFilteredFollowsQueryValidator : AbstractValidator<GetAllFilteredFollowsQuery>
{
    public GetAllFilteredFollowsQueryValidator()
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
