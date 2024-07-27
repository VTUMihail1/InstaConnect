namespace InstaConnect.Posts.Write.Web.Models.Binding.PostComments;

public class UpdatePostCommentBindingModel
{
    public UpdatePostCommentBindingModel(string content)
    {
        Content = content;
    }

    public string Content { get; set; }
}
