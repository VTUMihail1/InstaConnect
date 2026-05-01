namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

public class PostCommentIncludeBuilderFactory : IPostCommentIncludeBuilderFactory
{
	private readonly IPostCommentIncludeDescriptorFactory _descriptorFactory;

	public PostCommentIncludeBuilderFactory(IPostCommentIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public PostCommentIncludeBuilder Create()
	{
		return new PostCommentIncludeBuilder([], _descriptorFactory);
	}
}
