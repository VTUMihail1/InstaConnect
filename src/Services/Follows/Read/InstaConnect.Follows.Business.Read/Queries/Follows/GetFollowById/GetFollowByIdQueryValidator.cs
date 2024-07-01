using FluentValidation;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetFollowById;

namespace InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFilteredFollows;
public class GetFollowByIdQueryValidator : AbstractValidator<GetFollowByIdQuery>
{
    public GetFollowByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
