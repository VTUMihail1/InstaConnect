namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Binding;

public class AddPostLikeBody
{
    public AddPostLikeBody(string postId)
    {
        PostId = postId;
    }

    public string PostId { get; set; }
}
