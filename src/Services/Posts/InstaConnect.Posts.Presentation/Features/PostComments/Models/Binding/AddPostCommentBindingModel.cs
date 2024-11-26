namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Binding;

public class AddPostCommentBindingModel
{
    public AddPostCommentBindingModel(string postId, string content)
    {
        PostId = postId;
        Content = content;
    }

    public string PostId { get; set; }

    public string Content { get; set; }
}
