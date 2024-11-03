namespace InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Binding;

public class AddPostCommentLikeBindingModel
{
    public AddPostCommentLikeBindingModel(string postCommentId)
    {
        PostCommentId = postCommentId;
    }

    public string PostCommentId { get; set; }
}
