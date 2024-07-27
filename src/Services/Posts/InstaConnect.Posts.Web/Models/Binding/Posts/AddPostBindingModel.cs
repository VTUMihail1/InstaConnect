namespace InstaConnect.Posts.Write.Web.Models.Binding.Posts;

public class AddPostBindingModel
{
    public AddPostBindingModel(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public string Title { get; set; }

    public string Content { get; set; }
}
