using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;

public class GetCurrentUserDetailedQueryValidator : AbstractValidator<GetCurrentUserDetailedQuery>
{
    public GetCurrentUserDetailedQueryValidator()
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(q => q.Key)
            .NotEmpty();

        RuleFor(q => q.Expiration)
            .NotEmpty();
    }
}
