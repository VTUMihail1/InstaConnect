using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Validators;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetAllFilteredUsers;

public class GetAllFilteredUsersQueryValidator : AbstractValidator<GetAllFilteredUsersQuery>
{
    public GetAllFilteredUsersQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(c => c.UserName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.USER_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.USER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserName));

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.FIRST_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.FIRST_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.FirstName));

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.LAST_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.LAST_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.LastName));

        RuleFor(q => q.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<User>);
    }
}
