namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailedById;

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
