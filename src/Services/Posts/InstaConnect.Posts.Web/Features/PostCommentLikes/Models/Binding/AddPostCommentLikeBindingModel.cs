namespace InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Binding;

public class AddPostCommentLikeBindingModel
{
    public AddPostCommentLikeBindingModel(string postId)
    {
        PostId = postId;
    }

    public string PostId { get; set; }
}
