namespace InstaConnect.Posts.Write.Web.Models.Binding.PostCommentLikes;

public class AddPostCommentLikeBindingModel
{
    public AddPostCommentLikeBindingModel(string postId)
    {
        PostId = postId;
    }

    public string PostId { get; set; }
}
