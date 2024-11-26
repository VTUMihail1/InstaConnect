using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Validators;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(c => c.UserName)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.USER_NAME_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.USER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserName));

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.FirstName));

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.LAST_NAME_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.LastName));

        RuleFor(q => q.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<User>);
    }
}
