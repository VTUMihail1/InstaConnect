namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includes;
internal class PostCommentIncludePropertyFactory : IPostCommentIncludePropertyFactory
{
    private readonly IEnumerable<IPostCommentIncludeProperty> _postCommentIncludeProperty;

    public PostCommentIncludePropertyFactory(IEnumerable<IPostCommentIncludeProperty> postCommentIncludeProperty)
    {
        _postCommentIncludeProperty = postCommentIncludeProperty;
    }

    public IEnumerable<IPostCommentIncludeProperty> Create(ICollection<PostCommentIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postCommentIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new PostCommentIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
