using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;

public class GetUserByNameQueryValidator : AbstractValidator<GetUserByNameQuery>
{
    public GetUserByNameQueryValidator()
    {
        RuleFor(q => q.UserName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.USER_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.USER_NAME_MAX_LENGTH);
        ;
    }
}
