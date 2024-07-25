using FluentValidation;
using InstaConnect.Messages.Business.Utilities;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetFollowById;
public class GetFollowByIdQueryValidator : AbstractValidator<GetFollowByIdQuery>
{
    public GetFollowByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(FollowBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.ID_MAX_LENGTH);
    }
}
