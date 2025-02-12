using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;
namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
        ;
    }
}
