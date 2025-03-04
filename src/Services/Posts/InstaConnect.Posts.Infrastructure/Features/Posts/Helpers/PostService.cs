namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers;
internal class PostService : IPostService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostService(
        IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public void Update(Post post, string title, string content)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        post.Update(title, content, utcNow);
    }
}
