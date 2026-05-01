namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

public class PostLikeIncludeBuilderFactory : IPostLikeIncludeBuilderFactory
{
	private readonly IPostLikeIncludeDescriptorFactory _descriptorFactory;

	public PostLikeIncludeBuilderFactory(IPostLikeIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public PostLikeIncludeBuilder Create()
	{
		return new PostLikeIncludeBuilder([], _descriptorFactory);
	}
}
