namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortProperties;
internal class PostLikeSortPropertyFactory : IPostLikeSortPropertyFactory
{
    private readonly IEnumerable<IPostLikeSortProperty> _postLikeSortProperties;

    public PostLikeSortPropertyFactory(IEnumerable<IPostLikeSortProperty> postLikeSortProperties)
    {
        _postLikeSortProperties = postLikeSortProperties;
    }

    public IPostLikeSortProperty Create(PostLikeSortProperty sortProperty)
    {
        var property = _postLikeSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostLikeSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
