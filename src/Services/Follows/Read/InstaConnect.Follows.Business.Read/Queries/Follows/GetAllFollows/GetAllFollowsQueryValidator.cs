using FluentValidation;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFollows;

namespace InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFilteredFollows;
public class GetAllFollowsQueryValidator : AbstractValidator<GetAllFollowsQuery>
{
    public GetAllFollowsQueryValidator()
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
