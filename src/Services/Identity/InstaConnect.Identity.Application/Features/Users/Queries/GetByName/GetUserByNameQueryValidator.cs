namespace InstaConnect.Identity.Application.Features.Users.Queries.GetByName;

public class GetUserByNameQueryValidator : AbstractValidator<GetUserByNameQuery>
{
    public GetUserByNameQueryValidator()
    {
        RuleFor(q => q.UserName)
            .NotEmpty()
            .MinimumLength(UserConfigurations.NameMinLength)
            .MaximumLength(UserConfigurations.NameMaxLength);
        ;
    }
}
