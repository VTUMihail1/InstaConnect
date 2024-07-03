using FluentValidation;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetFollowById;
public class GetFollowByIdQueryValidator : AbstractValidator<GetFollowByIdQuery>
{
    public GetFollowByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
