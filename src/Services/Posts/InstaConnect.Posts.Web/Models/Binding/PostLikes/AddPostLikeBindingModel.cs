namespace InstaConnect.Posts.Write.Web.Models.Binding.PostLikes;

public class AddPostLikeBindingModel
{
    public AddPostLikeBindingModel(string postId)
    {
        PostId = postId;
    }

    public string PostId { get; set; }
}
