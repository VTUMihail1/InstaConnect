using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;
namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUserDetailed;

public class GetCurrentUserDetailedQueryValidator : AbstractValidator<GetCurrentUserDetailedQuery>
{
    public GetCurrentUserDetailedQueryValidator()
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(q => q.Key)
            .NotEmpty();

        RuleFor(q => q.ExpirationSeconds)
            .NotEmpty();
    }
}
