namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

public class PostCommentLikeIncludeBuilderFactory : IPostCommentLikeIncludeBuilderFactory
{
    private readonly IPostCommentLikeIncludeDescriptorFactory _descriptorFactory;

    public PostCommentLikeIncludeBuilderFactory(IPostCommentLikeIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public PostCommentLikeIncludeBuilder Create()
    {
        return new PostCommentLikeIncludeBuilder([], _descriptorFactory);
    }
}
