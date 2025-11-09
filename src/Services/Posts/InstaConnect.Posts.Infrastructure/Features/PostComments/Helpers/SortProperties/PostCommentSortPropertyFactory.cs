namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortProperties;
internal class PostCommentSortPropertyFactory : IPostCommentSortPropertyFactory
{
    private readonly IEnumerable<IPostCommentSortProperty> _postCommentSortProperties;

    public PostCommentSortPropertyFactory(IEnumerable<IPostCommentSortProperty> postCommentSortProperties)
    {
        _postCommentSortProperties = postCommentSortProperties;
    }

    public IPostCommentSortProperty Create(PostCommentSortProperty sortProperty)
    {
        var property = _postCommentSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostCommentSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
