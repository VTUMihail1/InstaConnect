namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Builders;

public class DeleteCurrentRefreshTokenCommandRequestBuilderFactory
{
    public DeleteCurrentRefreshTokenCommandRequestBuilder Create(RefreshToken refreshToken)
    {
        return new(refreshToken);
    }
}
