using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

internal class PostFactory : IPostFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public Post Create(string userId, string title, string content)
    {
        var id = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var post = new Post(
            id,
            title,
            content,
            userId,
            utcNow,
            utcNow);

        return post;
    }
}
