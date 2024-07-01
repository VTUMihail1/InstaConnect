using FluentValidation;
using InstaConnect.Identity.Business.Queries.User.GetUserById;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
