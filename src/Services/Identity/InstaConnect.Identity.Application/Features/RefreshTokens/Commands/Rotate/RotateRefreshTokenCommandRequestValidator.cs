namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
public class RotateRefreshTokenCommandRequestValidator : AbstractValidator<RotateRefreshTokenCommandRequest>
{
    public RotateRefreshTokenCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.Value)
            .NotEmptyWithMessage()
            .RefreshTokenValueMinLengthWithMessage()
            .RefreshTokenValueMaxLengthWithMessage();
    }
}
