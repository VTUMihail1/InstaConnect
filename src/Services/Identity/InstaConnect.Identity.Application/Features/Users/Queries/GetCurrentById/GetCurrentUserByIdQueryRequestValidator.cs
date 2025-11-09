namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;

public class GetCurrentUserByIdQueryRequestValidator : AbstractValidator<GetCurrentUserByIdQueryRequest>
{
    public GetCurrentUserByIdQueryRequestValidator()
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
