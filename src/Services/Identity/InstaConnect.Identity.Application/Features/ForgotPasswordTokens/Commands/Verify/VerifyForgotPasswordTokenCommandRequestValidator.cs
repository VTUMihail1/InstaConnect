namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
public class VerifyForgotPasswordTokenCommandRequestValidator : AbstractValidator<VerifyForgotPasswordTokenCommandRequest>
{
    public VerifyForgotPasswordTokenCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.Value)
            .NotEmptyWithMessage()
            .ForgotPasswordTokenValueMinLengthWithMessage()
            .ForgotPasswordTokenValueMaxLengthWithMessage();

        RuleFor(r => r.Password)
            .NotEmptyWithMessage()
            .UserPasswordMinLengthWithMessage()
            .UserPasswordMaxLengthWithMessage();

        RuleFor(r => r.ConfirmPassword)
            .EqualWithMessage(r => r.Password);
    }
}
