namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentFactory
{
    public PostComment Create(string id, string userId, string content);
}
