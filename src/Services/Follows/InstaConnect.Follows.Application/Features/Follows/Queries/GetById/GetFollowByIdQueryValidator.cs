using FluentValidation;
using InstaConnect.Follows.Common.Features.Follows.Utilities;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
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
