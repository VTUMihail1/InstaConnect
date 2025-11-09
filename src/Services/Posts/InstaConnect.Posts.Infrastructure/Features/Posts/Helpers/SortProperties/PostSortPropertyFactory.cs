namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortProperties;
internal class PostSortPropertyFactory : IPostSortPropertyFactory
{
    private readonly IEnumerable<IPostSortProperty> _postSortProperties;

    public PostSortPropertyFactory(IEnumerable<IPostSortProperty> postSortProperties)
    {
        _postSortProperties = postSortProperties;
    }

    public IPostSortProperty Create(PostSortProperty sortProperty)
    {
        var property = _postSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
