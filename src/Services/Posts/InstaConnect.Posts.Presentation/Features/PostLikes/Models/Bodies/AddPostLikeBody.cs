namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Bodies;

public class AddPostLikeBody
{
    public AddPostLikeBody(string postId)
    {
        PostId = postId;
    }

    public string PostId { get; set; }
}
