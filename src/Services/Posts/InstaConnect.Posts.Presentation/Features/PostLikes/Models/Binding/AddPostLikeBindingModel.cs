namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Binding;

public class AddPostLikeBindingModel
{
    public AddPostLikeBindingModel(string postId)
    {
        PostId = postId;
    }

    public string PostId { get; set; }
}
