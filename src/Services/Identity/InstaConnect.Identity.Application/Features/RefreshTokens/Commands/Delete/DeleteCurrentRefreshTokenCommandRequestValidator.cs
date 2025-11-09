namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;
public class DeleteCurrentRefreshTokenCommandRequestValidator : AbstractValidator<DeleteCurrentRefreshTokenCommandRequest>
{
    public DeleteCurrentRefreshTokenCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(r => r.Value)
            .NotEmpty()
            .WithMessage(RefreshTokenErrorMessages.GetValueEmpty())
            .MinimumLength(RefreshTokenConfigurations.ValueMinLength)
            .WithMessage(r => RefreshTokenErrorMessages.GetValueTooShort(r.Value.Length))
            .MaximumLength(RefreshTokenConfigurations.ValueMaxLength)
            .WithMessage(r => RefreshTokenErrorMessages.GetValueTooLong(r.Value.Length));
    }
}
