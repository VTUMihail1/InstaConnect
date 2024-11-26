namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Binding;

public class UpdatePostCommentBindingModel
{
    public UpdatePostCommentBindingModel(string content)
    {
        Content = content;
    }

    public string Content { get; set; }
}
