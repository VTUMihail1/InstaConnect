namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

public class GetUserDetailsByIdQueryRequestValidator : AbstractValidator<GetUserDetailsByIdQueryRequest>
{
    public GetUserDetailsByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Id.Length));
    }
}
