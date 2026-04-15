namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;

public class DeleteCurrentRefreshTokenApiRequestBuilderFactory
{
    public DeleteCurrentRefreshTokenApiRequestBuilder Create(RefreshToken refreshToken)
    {
        return new(refreshToken);
    }
}
