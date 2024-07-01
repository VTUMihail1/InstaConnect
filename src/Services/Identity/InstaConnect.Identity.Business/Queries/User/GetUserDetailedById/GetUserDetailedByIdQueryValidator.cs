using FluentValidation;
using InstaConnect.Identity.Business.Queries.User.GetUserDetailedById;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetUserDetailedByIdQueryValidator : AbstractValidator<GetUserDetailedByIdQuery>
{
    public GetUserDetailedByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
