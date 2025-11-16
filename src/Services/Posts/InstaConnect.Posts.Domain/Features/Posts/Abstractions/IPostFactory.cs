namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostFactory
{
    public Post Create(UserId userId, string title, string content);
}
