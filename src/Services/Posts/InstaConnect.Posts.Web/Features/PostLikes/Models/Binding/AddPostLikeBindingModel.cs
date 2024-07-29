namespace InstaConnect.Posts.Web.Features.PostLikes.Models.Binding;

public class AddPostLikeBindingModel
{
    public AddPostLikeBindingModel(string postId)
    {
        PostId = postId;
    }

    public string PostId { get; set; }
}
