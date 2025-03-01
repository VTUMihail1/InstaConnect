using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
public interface IPostCommentService
{
    public void Update(PostComment postComment, string content);
}
