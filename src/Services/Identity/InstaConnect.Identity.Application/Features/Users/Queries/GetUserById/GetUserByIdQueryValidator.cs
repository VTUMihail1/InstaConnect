using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;
namespace InstaConnect.Identity.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.ID_MAX_LENGTH);
        ;
    }
}
