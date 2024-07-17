using FluentValidation;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;
public class GetAllFilteredFollowsQueryValidator : AbstractValidator<GetAllFilteredFollowsQuery>
{
    public GetAllFilteredFollowsQueryValidator()
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
