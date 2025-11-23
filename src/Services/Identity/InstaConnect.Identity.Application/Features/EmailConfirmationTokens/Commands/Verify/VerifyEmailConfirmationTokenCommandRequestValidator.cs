namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
public class VerifyEmailConfirmationTokenCommandRequestValidator : AbstractValidator<VerifyEmailConfirmationTokenCommandRequest>
{
    public VerifyEmailConfirmationTokenCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.Value)
            .NotEmptyWithMessage()
            .EmailConfirmationTokenValueMinLengthWithMessage()
            .EmailConfirmationTokenValueMaxLengthWithMessage();
    }
}
