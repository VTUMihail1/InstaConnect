using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetUserDetailedById;

public class GetUserDetailedByIdQueryValidator : AbstractValidator<GetUserDetailedByIdQuery>
{
    public GetUserDetailedByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.ID_MAX_LENGTH);
    }
}
