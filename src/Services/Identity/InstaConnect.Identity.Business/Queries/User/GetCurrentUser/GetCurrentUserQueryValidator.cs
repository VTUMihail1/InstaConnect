using FluentValidation;
using InstaConnect.Identity.Business.Queries.User.GetCurrentUser;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetCurrentUserQueryValidator : AbstractValidator<GetCurrentUserQuery>
{
    public GetCurrentUserQueryValidator()
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty();

        RuleFor(q => q.Key)
            .NotEmpty();

        RuleFor(q => q.Expiration)
            .NotEmpty();
    }
}
