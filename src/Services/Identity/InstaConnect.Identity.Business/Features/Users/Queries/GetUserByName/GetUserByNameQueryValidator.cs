using FluentValidation;
using InstaConnect.Identity.Business.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;

public class GetUserByNameQueryValidator : AbstractValidator<GetUserByNameQuery>
{
    public GetUserByNameQueryValidator()
    {
        RuleFor(q => q.UserName)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.USER_NAME_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.USER_NAME_MAX_LENGTH);
        ;
    }
}
