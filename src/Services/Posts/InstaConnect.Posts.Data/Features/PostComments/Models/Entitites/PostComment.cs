using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;

public class PostComment : BaseEntity
{
    public PostComment(
        string userId,
        string postId,
        string content)
    {
        UserId = userId;
        PostId = postId;
        Content = content;
    }

    public string UserId { get; }

    public string PostId { get; }

    public string Content { get; set; }

    public User? User { get; set; }

    public Post? Post { get; set; }
}
