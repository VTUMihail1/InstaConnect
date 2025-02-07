using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;
namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUserDetailed;

public class GetCurrentDetailedUserQueryValidator : AbstractValidator<GetCurrentDetailedUserQuery>
{
    public GetCurrentDetailedUserQueryValidator()
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(q => q.Key)
            .NotEmpty();

        RuleFor(q => q.ExpirationSeconds)
            .NotEmpty();
    }
}
