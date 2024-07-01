using FluentValidation;
using InstaConnect.Identity.Business.Queries.User.GetUserByName;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetUserByNameQueryValidator : AbstractValidator<GetUserByNameQuery>
{
    public GetUserByNameQueryValidator()
    {
        RuleFor(q => q.UserName)
            .NotEmpty();
    }
}
