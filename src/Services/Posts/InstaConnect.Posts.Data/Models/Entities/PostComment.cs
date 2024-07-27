using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Read.Data.Models.Entities;

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
