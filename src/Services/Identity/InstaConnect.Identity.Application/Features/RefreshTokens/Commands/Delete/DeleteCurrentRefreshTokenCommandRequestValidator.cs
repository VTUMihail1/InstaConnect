namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;

public class DeleteCurrentRefreshTokenCommandRequestValidator : AbstractValidator<DeleteCurrentRefreshTokenCommandRequest>
{
    public DeleteCurrentRefreshTokenCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Value)
            .NotEmptyWithMessage()
            .RefreshTokenValueMinLengthWithMessage()
            .RefreshTokenValueMaxLengthWithMessage();
    }
}
