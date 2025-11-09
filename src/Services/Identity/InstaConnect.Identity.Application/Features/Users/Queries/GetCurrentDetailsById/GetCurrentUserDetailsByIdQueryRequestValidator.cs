namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

public class GetCurrentUserDetailsByIdQueryRequestValidator : AbstractValidator<GetCurrentUserDetailsByIdQueryRequest>
{
    public GetCurrentUserDetailsByIdQueryRequestValidator()
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
