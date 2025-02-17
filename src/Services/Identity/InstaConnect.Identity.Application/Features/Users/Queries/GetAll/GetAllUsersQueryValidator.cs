using FluentValidation;

using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Validators;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(c => c.UserName)
            .NotEmpty()
            .MinimumLength(UserConfigurations.NameMinLength)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .When(q => !string.IsNullOrEmpty(q.UserName));

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(UserConfigurations.FirstNameMinLength)
            .MaximumLength(UserConfigurations.FirstNameMaxLength)
            .When(q => !string.IsNullOrEmpty(q.FirstName));

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(UserConfigurations.LastNameMinLength)
            .MaximumLength(UserConfigurations.LastNameMaxLength)
            .When(q => !string.IsNullOrEmpty(q.LastName));

        RuleFor(q => q.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<User>);
    }
}
