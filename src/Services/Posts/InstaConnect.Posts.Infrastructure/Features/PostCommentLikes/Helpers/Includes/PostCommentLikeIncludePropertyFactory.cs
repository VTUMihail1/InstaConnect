namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includes;
internal class PostCommentLikeIncludePropertyFactory : IPostCommentLikeIncludePropertyFactory
{
    private readonly IEnumerable<IPostCommentLikeIncludeProperty> _postCommentLikeIncludeProperty;

    public PostCommentLikeIncludePropertyFactory(IEnumerable<IPostCommentLikeIncludeProperty> postCommentLikeIncludeProperty)
    {
        _postCommentLikeIncludeProperty = postCommentLikeIncludeProperty;
    }

    public IEnumerable<IPostCommentLikeIncludeProperty> Create(ICollection<PostCommentLikeIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postCommentLikeIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new PostCommentLikeIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
