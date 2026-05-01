namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class GetFollowByIdApiRequestBuilderFactory
{
	public GetFollowByIdApiRequestBuilder Create(Follow follow)
	{
		return new(follow);
	}
}
