using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.ID_MAX_LENGTH);
        ;
    }
}
