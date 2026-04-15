namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class DeleteFollowApiRequestBuilderFactory
{
    public DeleteFollowApiRequestBuilder Create(Follow follow)
    {
        return new(follow);
    }
}
