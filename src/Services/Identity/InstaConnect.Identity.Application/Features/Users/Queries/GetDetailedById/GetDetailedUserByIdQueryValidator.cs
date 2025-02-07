using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetUserDetailedById;

public class GetDetailedUserByIdQueryValidator : AbstractValidator<GetDetailedUserByIdQuery>
{
    public GetDetailedUserByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
    }
}
