namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;
public class DeleteCurrentRefreshTokenCommandRequestValidator : AbstractValidator<DeleteCurrentRefreshTokenCommandRequest>
{
    public DeleteCurrentRefreshTokenCommandRequestValidator()
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
