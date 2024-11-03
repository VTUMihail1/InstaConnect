using FluentValidation;
using InstaConnect.Follows.Common.Features.Follows.Utilities;

namespace InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
public class GetFollowByIdQueryValidator : AbstractValidator<GetFollowByIdQuery>
{
    public GetFollowByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(FollowConfigurations.IdMinLength)
            .MaximumLength(FollowConfigurations.IdMaxLength);
    }
}
