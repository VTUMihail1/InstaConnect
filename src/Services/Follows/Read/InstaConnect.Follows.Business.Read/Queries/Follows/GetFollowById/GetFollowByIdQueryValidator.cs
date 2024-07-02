using FluentValidation;

namespace InstaConnect.Follows.Business.Read.Queries.Follows.GetFollowById;
public class GetFollowByIdQueryValidator : AbstractValidator<GetFollowByIdQuery>
{
    public GetFollowByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
