using FluentValidation;
using InstaConnect.Identity.Business.Queries.User.GetCurrentUserDetailed;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetCurrentUserDetailedQueryValidator : AbstractValidator<GetCurrentUserDetailedQuery>
{
    public GetCurrentUserDetailedQueryValidator()
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty();

        RuleFor(q => q.Key)
            .NotEmpty();

        RuleFor(q => q.Expiration)
            .NotEmpty();
    }
}
