namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class GetAllFollowsApiRequestBuilderFactory
{
    public GetAllFollowsApiRequestBuilder Create(Follow follow)
    {
        return new(follow);
    }
}
