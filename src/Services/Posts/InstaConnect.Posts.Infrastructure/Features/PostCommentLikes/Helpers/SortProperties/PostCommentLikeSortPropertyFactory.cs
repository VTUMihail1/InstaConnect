namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortProperties;
internal class PostCommentLikeSortPropertyFactory : IPostCommentLikeSortPropertyFactory
{
    private readonly IEnumerable<IPostCommentLikeSortProperty> _postCommentLikeSortProperties;

    public PostCommentLikeSortPropertyFactory(IEnumerable<IPostCommentLikeSortProperty> postCommentLikeSortProperties)
    {
        _postCommentLikeSortProperties = postCommentLikeSortProperties;
    }

    public IPostCommentLikeSortProperty Create(PostCommentLikeSortProperty sortProperty)
    {
        var property = _postCommentLikeSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostCommentLikeSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
