namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includes;
internal class PostLikeIncludePropertyFactory : IPostLikeIncludePropertyFactory
{
    private readonly IEnumerable<IPostLikeIncludeProperty> _postLikeIncludeProperty;

    public PostLikeIncludePropertyFactory(IEnumerable<IPostLikeIncludeProperty> postLikeIncludeProperty)
    {
        _postLikeIncludeProperty = postLikeIncludeProperty;
    }

    public IEnumerable<IPostLikeIncludeProperty> Create(ICollection<PostLikeIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postLikeIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new PostLikeIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
