using FluentValidation;
using InstaConnect.Identity.Business.Queries.User.GetAllUsers;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
        RuleFor(q => q.Offset)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.Limit)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}
