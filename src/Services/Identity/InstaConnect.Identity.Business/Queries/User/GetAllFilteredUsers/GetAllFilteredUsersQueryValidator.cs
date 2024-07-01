using FluentValidation;
using InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetAllFilteredUsersQueryValidator : AbstractValidator<GetAllFilteredUsersQuery>
{
    public GetAllFilteredUsersQueryValidator()
    {
        RuleFor(q => q.Offset)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.Limit)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty()
            .IsInEnum();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}
