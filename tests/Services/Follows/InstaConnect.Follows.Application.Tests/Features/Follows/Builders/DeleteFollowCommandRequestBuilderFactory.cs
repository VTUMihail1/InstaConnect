namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class DeleteFollowCommandRequestBuilderFactory
{
    public DeleteFollowCommandRequestBuilder Create(Follow follow)
    {
        return new(follow);
    }
}
