namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class GetAllFollowsForFollowingApiRequestBuilderFactory
{
    public GetAllFollowsForFollowingApiRequestBuilder Create(Follow follow)
    {
        return new(follow);
    }
}
