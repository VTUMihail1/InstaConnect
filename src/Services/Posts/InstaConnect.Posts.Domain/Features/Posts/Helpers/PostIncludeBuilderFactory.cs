namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

public class PostIncludeBuilderFactory : IPostIncludeBuilderFactory
{
	private readonly IPostIncludeDescriptorFactory _descriptorFactory;

	public PostIncludeBuilderFactory(IPostIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public PostIncludeBuilder Create()
	{
		return new PostIncludeBuilder([], _descriptorFactory);
	}
}
