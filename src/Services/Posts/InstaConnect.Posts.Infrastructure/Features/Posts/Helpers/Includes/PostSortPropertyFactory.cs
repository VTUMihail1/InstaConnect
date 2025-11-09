namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includes;
internal class PostIncludePropertyFactory : IPostIncludePropertyFactory
{
    private readonly IEnumerable<IPostIncludeProperty> _postIncludeProperty;

    public PostIncludePropertyFactory(IEnumerable<IPostIncludeProperty> postIncludeProperty)
    {
        _postIncludeProperty = postIncludeProperty;
    }

    public IEnumerable<IPostIncludeProperty> Create(ICollection<PostIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new PostIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
